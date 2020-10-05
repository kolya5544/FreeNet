using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;

namespace ImageRecoder
{
    internal static class Processor
    {
        private static readonly Random Rng = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

        /// <summary>
        /// Processor entrypoint
        /// </summary>
        /// <param name="options"></param>
        internal static void Run(Options options)
        {
            Console.WriteLine("Started...");

            bool isFolder = Directory.Exists(options.Input);

            List<string> filesToProcess = new List<string>();

            if (isFolder)
            {
                filesToProcess = Directory.EnumerateFiles(options.Input, "*", SearchOption.AllDirectories).ToList();
                Console.Write($"A folder was chosen. {filesToProcess.Count} files were found. Do you want to continue? (Y/N):");
                bool answ = Console.ReadLine().ToUpper() == "Y";
                if (!answ) return;
            } else
            {
                filesToProcess.Add(options.Input);
            }

            foreach (string file in filesToProcess)
            {
                Bitmap inp = new Bitmap(file);

                if (options.Meta == Meta.RandomResize)
                {
                    ApplyRandomResize(ref inp);
                }

                string relativePath = Path.GetRelativePath(Environment.CurrentDirectory, file);
                string fileName = Path.GetFileName(relativePath);
                string outputFilename = isFolder ? $"{options.Output}\\{relativePath.Remove(0, options.Input.Length + 1)}" : $"{options.Output}";
                if (isFolder) Directory.CreateDirectory(Path.GetDirectoryName(outputFilename));

                object outp;
                switch (options.Type)
                {
                    case ProcessingType.One:
                        outp = SimpleRecode(inp, options.Meta);
                        Console.WriteLine($"Successfully recoded {relativePath} and removed metadata. Saving to {outputFilename}");
                        ((Bitmap)outp).Save(outputFilename);
                        break;
                    case ProcessingType.Two:
                        outp = BMPRecode(inp, options.Meta);
                        Console.WriteLine($"Successfully recoded {relativePath} to raw RGB Bitmap with no metadata. Saving to {outputFilename}");
                        File.WriteAllBytes(outputFilename, (byte[])outp);
                        break;
                    default:
                        Console.WriteLine("Unknown type!");
                        break;
                }
            }
        }

        /// <summary>
        /// Applies a random resize ranging from -20 to +20 percent off original size (N = N + N * Perc, where Perc is [-0.20, 0.20) ).
        /// </summary>
        /// <param name="inp">Bitmap to apply a resize to</param>
        private static void ApplyRandomResize(ref Bitmap inp)
        {
            double wPerc = (double)Rng.Next(-20, 20) / 100;
            double hPerc = (double)Rng.Next(-20, 20) / 100;

            int newW = (int)Math.Round(inp.Width + inp.Width * wPerc);
            int newH = (int)Math.Round(inp.Height + inp.Height * hPerc);

            using Bitmap bmp = new Bitmap(newW, newH);
            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.CompositingMode = CompositingMode.SourceCopy;

            g.DrawImage(inp, new Rectangle(Point.Empty, new Size(newW, newH)));

            inp = new Bitmap(bmp);
        }

        /// <summary>
        /// Manually copies all the pixels to the new Bitmap, applying a chosen meta
        /// </summary>
        /// <param name="bmp">Bitmap to copy pixels from</param>
        /// <param name="meta">Meta to apply</param>
        /// <returns>New bitmap with meta applied to every pixel.</returns>
        private static Bitmap SimpleRecode(Bitmap bmp, Meta meta)
        {
            var bitmap = new Bitmap(bmp.Width, bmp.Height);
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    ApplyMeta(ref c, meta);
                    bitmap.SetPixel(x, y, c);
                }
            }
            return bitmap;
        }

        /// <summary>
        /// Creates an RGB 24-bit no encoding BMP image as a byte array out of a Bitmap, applying meta to every pixel
        /// </summary>
        /// <param name="bmp">Bitmap to convert to raw BMP image</param>
        /// <param name="meta">Meta to apply to every pixel</param>
        /// <returns>Byte array representation of a BMP image</returns>
        private static byte[] BMPRecode(Bitmap bmp, Meta meta)
        {
            MemoryStream ms = new MemoryStream();
            Baker.BMHeader(ms);
            int pixelAmount = bmp.Width * bmp.Height;
            int bmpSize = pixelAmount * 3 + //1 pixel = 3 bytes.
                                bmp.Height * (bmp.Width % 4) + //Total length of padding
                                54; //54 bytes is the length of the whole header part.
            Baker.FileSizeHeader(ms, bmpSize);
            //Application specific header. It will be...
            Baker.IKTMHeader(ms, new byte[] { 0x00, 0x00, 0x00, 0x00 }); //There was an "IKTM" header but now just zeroes
                                                                         //Static offset of pixel data.
            Baker.PixelOffsetHeader(ms);
            //DIB header, fully handled by one function (it's mostly static.)
            Baker.DIB(ms, bmp.Width, bmp.Height);
            int padding = bmp.Width % 4;
            for (int y = bmp.Height - 1; y >= 0; y--)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    ApplyMeta(ref c, meta);
                    ms.Write(new byte[] { c.B, c.G, c.R });
                }
                ms.Write(new byte[padding]);
            }
            ms.Position = 0;
            byte[] o = new byte[ms.Length];
            ms.Read(o);
            return o;
        }

        /// <summary>
        /// Applies specified meta to a colour
        /// </summary>
        /// <param name="c">Colour to apply meta for</param>
        /// <param name="meta">Meta to apply</param>
        private static void ApplyMeta(ref Color c, Meta meta)
        {
            if (meta == Meta.NoPostProcessing || meta == Meta.RandomResize) return;

            if (meta != Meta.BlackWhite)
            {
                int ratio = meta switch
                {
                    Meta.OneFifth => 5,
                    Meta.OneTenth => 10,
                    Meta.OneTwentieth => 20,
                    Meta.OneFortieth => 40,
                    Meta.OneEightieth => 80,
                    _ => throw new ApplicationException($"Meta value {meta} hasn't been implemented, please contact @kolya5544")
                };

                int newR = (c.R / ratio) * ratio;
                int newG = (c.G / ratio) * ratio;
                int newB = (c.B / ratio) * ratio;
                c = Color.FromArgb(c.A, newR, newG, newB);
            }
            else
            {
                double colour = c.R * 0x10000 + c.G * 0x100 + c.B;
                double bwPercentage = colour / 0xFFFFFF;
                int bw = (int)Math.Round(bwPercentage * 255);

                c = Color.FromArgb(bw, bw, bw);
            }
        }
    }
}
