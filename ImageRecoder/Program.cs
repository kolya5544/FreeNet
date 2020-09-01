using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace ImageRecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: program.exe <input> <output> <type> [meta]");
                Console.WriteLine();
                Console.WriteLine("Types:");
                Console.WriteLine("1 - Takes the picture and saves it, removing most of metadata or byte hidden contents.");
                Console.WriteLine("2 - Takes the picture and saves it to raw BMP HEX, removing all the sensitive information stored in a file");
                Console.WriteLine();
                Console.WriteLine("Metas:");
                Console.WriteLine("1 - 1/5 colour equalization to remove a bit of hidden contents.");
                Console.WriteLine("2 - 1/10 colour equalization to remove some of hidden contents.");
                Console.WriteLine("3 - 1/20 colour equalization to remove most of hidden contents.");
                Console.WriteLine("4 - 1/40 colour equalization to remove hidden contents at the cost of bad quality.");
                Console.WriteLine("5 - 1/80 color equalization. You can't be serious. Hope they dont find you.");
            } else
            {
                Console.WriteLine("Started...");
                string Input = args[0];
                string Output = args[1];
                int Type = int.Parse(args[2]);
                int Meta = 0;
                if (args.Length == 4)
                {
                    Meta = int.Parse(args[3]);
                }

                Bitmap inp = new Bitmap(Input);
                object outp;
                switch (Type)
                {
                    case 1:
                        outp = SimpleRecode(inp, Meta);
                        Console.WriteLine("Successfully recoded and removed metadata. Saving...");
                        ((Bitmap)outp).Save(Output);
                        break;
                    case 2:
                        outp = BMPRecode(inp, Meta);
                        Console.WriteLine("Successfully recoded to raw RGB Bitmap with no metadata. Saving...");
                        File.WriteAllBytes(Output, (byte[])outp);
                        break;
                    default:
                        Console.WriteLine("Unknown type!");
                        break;
                }
            }
        }

        public static Bitmap SimpleRecode(Bitmap bmp, int meta)
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

        public static byte[] BMPRecode(Bitmap bmp, int meta)
        {
            MemoryStream ms = new MemoryStream();
            Baker.BMHeader(ms);
            int PixelAmount = bmp.Width * bmp.Height;
            int BMPSize = PixelAmount * 3 + //1 pixel = 3 bytes.
                                bmp.Height * (bmp.Width % 4) + //Total length of padding
                                54; //54 bytes is the length of the whole header part.
            Baker.FileSizeHeader(ms, BMPSize);
            //Application specific header. It will be...
            Baker.IKTMHeader(ms, "IKTM"); //IKTM
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

        private static void ApplyMeta(ref Color c, int meta)
        {
            if (meta == 0) return;
            int Ratio = 0;
            switch (meta)
            {
                case 1:
                    Ratio = 5; break;
                case 2:
                    Ratio = 10; break;
                case 3:
                    Ratio = 20; break;
                case 4:
                    Ratio = 40; break;
                case 5:
                    Ratio = 80; break;
            }
            int R = c.R;
            int G = c.G;
            int B = c.B;
            int NewR = (R / Ratio) * Ratio;
            int NewG = (G / Ratio) * Ratio;
            int NewB = (B / Ratio) * Ratio;
            c = Color.FromArgb(c.A, NewR, NewG, NewB);
        }
    }
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
