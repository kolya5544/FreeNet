using System;
using System.IO;
using System.Text;

namespace ImageRecoder
{
    /// <summary>
    /// A class to work with raw BMP
    /// </summary>
    public static class Baker
    {
        private readonly static byte[] IDField = { 0x42, 0x4D }; //"BM"
        private readonly static byte[] DataOffset = { 0x36, 0x00, 0x00, 0x00 }; //54.
        private readonly static byte[] DIBNumber = { 0x28, 0x00, 0x00, 0x00 }; //40.
        private readonly static byte[] DIB_MagicBytes_1 = {
            0x01, 0x00,//plane amount
            0x18, 0x00,//Bits per pixel.
            0x00, 0x00, 0x00, 0x00 //zero compression
        };
        private static readonly byte[] DIB_MagicBytes_2 =
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
            byte[] wBytes = BitConverter.GetBytes(w);
            byte[] hBytes = BitConverter.GetBytes(h);
            s.Write(wBytes);
            s.Write(hBytes);
            s.Write(DIB_MagicBytes_1);
            int padding = w % 4;
            byte[] RawBitmapSize = BitConverter.GetBytes((w * 3 + padding) * h);
            s.Write(RawBitmapSize);
            s.Write(DIB_MagicBytes_2);
        }
    }
}
