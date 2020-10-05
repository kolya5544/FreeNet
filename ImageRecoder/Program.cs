using CommandLine;
using CommandLine.Text;
using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace ImageRecoder
{
    class Program
    {
        public static Random rng = new Random();

        static void Main(string[] args)
        {
            var parser = new Parser(with => with.HelpWriter = null);
            var result = parser.ParseArguments<Options>(args);

            result
                .WithParsed(Run)
                .WithNotParsed(_ => DisplayHelp(result));
        }

        private static void DisplayHelp(ParserResult<Options> result)
        {
            var helpText = HelpText.AutoBuild(result, helpText =>
            {
                helpText.AddPreOptionsLine("Usage: program.exe <input> <output> --type <type> [-- meta <meta>]");
                helpText.AddPostOptionsLine("Program source code: https://github.com/kolya5544/FreeNet/tree/master/ImageRecoder");
                return HelpText.DefaultParsingErrorsHandler(result, helpText);
            }, e => e);

            Console.WriteLine(helpText);
        }

        private static void Run(Options options)
        {
            Console.WriteLine("Started...");

            Bitmap inp = new Bitmap(options.Input);

            if (options.Meta == Meta.RandomResize)
            {
                ApplyRandomResize(ref inp);
            }

            object outp;
            switch (options.Type)
            {
                case ProcessingType.One:
                    outp = SimpleRecode(inp, options.Meta);
                    Console.WriteLine("Successfully recoded and removed metadata. Saving...");
                    ((Bitmap)outp).Save(options.Output);
                    break;
                case ProcessingType.Two:
                    outp = BMPRecode(inp, options.Meta);
                    Console.WriteLine("Successfully recoded to raw RGB Bitmap with no metadata. Saving...");
                    File.WriteAllBytes(options.Output, (byte[])outp);
                    break;
                default:
                    Console.WriteLine("Unknown type!");
                    break;
            }
        }

        /// <summary>
        /// Applies a random resize ranging from -20 to +20 percent off original size (N = N + N * Perc, where Perc is [-0.20, 0.20) ).
        /// </summary>
        /// <param name="inp">Bitmap to apply a resize to</param>
        private static void ApplyRandomResize(ref Bitmap inp)
        {
            int NewW, NewH;

            double WPerc = (double)rng.Next(-20, 20) / 100; double HPerc = (double)rng.Next(-20, 20) / 100;

            NewW = (int)Math.Round(inp.Width + inp.Width * WPerc); NewH = (int)Math.Round(inp.Height + inp.Height * HPerc);

            Bitmap bmp = new Bitmap(NewW, NewH);
            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;

            g.DrawImage(inp, new Rectangle(Point.Empty, new Size(NewW, NewH)));

            inp = new Bitmap(bmp);
            bmp.Dispose();
        }

        /// <summary>
        /// Manually copies all the pixels to the new Bitmap, applying a chosen meta
        /// </summary>
        /// <param name="bmp">Bitmap to copy pixels from</param>
        /// <param name="meta">Meta to apply</param>
        /// <returns>New bitmap with meta applied to every pixel.</returns>
        public static Bitmap SimpleRecode(Bitmap bmp, Meta meta)
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
        public static byte[] BMPRecode(Bitmap bmp, Meta meta)
        {
            MemoryStream ms = new MemoryStream();
            Baker.BMHeader(ms);
            int PixelAmount = bmp.Width * bmp.Height;
            int BMPSize = PixelAmount * 3 + //1 pixel = 3 bytes.
                                bmp.Height * (bmp.Width % 4) + //Total length of padding
                                54; //54 bytes is the length of the whole header part.
            Baker.FileSizeHeader(ms, BMPSize);
            //Application specific header. It will be...
            Baker.IKTMHeader(ms, new byte[] { 0x00, 0x00, 0x00, 0x00 }); //There was an "IKTM" header but now just zeroes
                                                                         //Static offset of pixel data.
            Baker.PixelOffsetHeader(ms);
            //DIB header, fully handled by one function (it's mostly static.)
            Baker.DIB(ms, bmp.Width, bmp.Height);
            int Padding = bmp.Width % 4;
            for (int y = bmp.Height - 1; y >= 0; y--)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    ApplyMeta(ref c, meta);
                    ms.Write(new byte[] { c.B, c.G, c.R });
                }
                ms.Write(new byte[Padding]);
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
                int Ratio = meta switch
                {
                    Meta.OneFifth => 5,
                    Meta.OneTenth => 10,
                    Meta.OneTwentieth => 20,
                    Meta.OneFortieth => 40,
                    Meta.OneEightieth => 80,
                    _ => throw new ApplicationException($"Meta value {meta} hasn't been implemented, please contact @kolya5544")
                };

                int R = c.R;
                int G = c.G;
                int B = c.B;
                int NewR = (R / Ratio) * Ratio;
                int NewG = (G / Ratio) * Ratio;
                int NewB = (B / Ratio) * Ratio;
                c = Color.FromArgb(c.A, NewR, NewG, NewB);
            }
            else
            {
                double Colour = c.R * 0x10000 + c.G * 0x100 + c.B;
                double BWpercentage = Colour / 0xFFFFFF;
                int BW = (int)Math.Round(BWpercentage * 255);

                c = Color.FromArgb(BW, BW, BW);
            }
        }
    }

    /// <summary>
    /// A class to work with raw BMP
    /// </summary>
    public class Baker
    {
        private static byte[] IDField = { 0x42, 0x4D }; //"BM"
        private static byte[] DataOffset = { 0x36, 0x00, 0x00, 0x00 }; //54.
        private static byte[] DIBNumber = { 0x28, 0x00, 0x00, 0x00 }; //40.
        private static byte[] DIB_MagicBytes_1 = {
            0x01, 0x00,//plane amount
            0x18, 0x00,//Bits per pixel.
            0x00, 0x00, 0x00, 0x00 //zero compression
        };
        private static byte[] DIB_MagicBytes_2 =
        {
            0x13, 0x0B, 0x00, 0x00, //Printing details =======
            0x13, 0x0B, 0x00, 0x00, //========================
            0x00, 0x00, 0x00, 0x00, //colors amount
            0x00, 0x00, 0x00, 0x00 // all colors are important
        };

        /// <summary>
        /// Adds "BM" header to the file.
        /// </summary>
        /// <param name="s"></param>
        public static void BMHeader(Stream s)
        {
            s.Write(IDField);
        }
        /// <summary>
        /// Adds BMP size header to the file.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="BMPSize"></param>
        public static void FileSizeHeader(Stream s, int BMPSize)
        {
            byte[] Bytes = BitConverter.GetBytes(BMPSize);
            s.Write(Bytes);
        }
        /// <summary>
        /// Adds program-specific unused value to the file.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="header"></param>
        public static void IKTMHeader(Stream s, string header)
        {
            IKTMHeader(s, Encoding.UTF8.GetBytes(header));
        }
        public static void IKTMHeader(Stream s, byte[] header)
        {
            if (header.Length == 4)
            {
                s.Write(header);
            }
            else
            {
                throw new ArgumentException("Header length should be 4 bytes.");
            }
        }
        /// <summary>
        /// Writes offset to pixel array to the file.
        /// </summary>
        /// <param name="s"></param>
        public static void PixelOffsetHeader(Stream s)
        {
            s.Write(DataOffset);
        }
        /// <summary>
        /// Manages DIB header creation
        /// </summary>
        /// <param name="s"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        public static void DIB(Stream s, int w, int h)
        {
            s.Write(DIBNumber);
            byte[] WBytes = BitConverter.GetBytes(w);
            byte[] HBytes = BitConverter.GetBytes(h);
            s.Write(WBytes);
            s.Write(HBytes);
            s.Write(DIB_MagicBytes_1);
            int padding = w % 4;
            byte[] RawBitmapSize = BitConverter.GetBytes((w * 3 + padding) * h);
            s.Write(RawBitmapSize);
            s.Write(DIB_MagicBytes_2);
        }
    }
}
