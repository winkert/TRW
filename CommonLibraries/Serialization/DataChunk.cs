using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Serialization
{
    /// <summary>
    /// 
    /// </summary>
    public class DataChunk
    {
        public DataChunk()
        {

        }

        public DataChunk(byte[] bytes)
            : this()
        {
            Bytes = bytes;
        }

        public DataChunk(Stream stream, int offset, int length)
            : this()
        {
            Bytes = new byte[length];
            stream.Read(Bytes, offset, length);
        }

        public byte[] Bytes { get; set; }

        public override string ToString()
        {
            return ToString(Encoding.Default.GetDecoder());
        }

        public string ToString(Decoder decoder)
        {
            char[] charArray = new char[Bytes.Length];
            decoder.GetChars(Bytes, 0, Bytes.Length, charArray, 0);
            return new string(charArray);
        }

        public int ToInt()
        {
            return BitConverter.ToInt32(Bytes, 0);
        }

        public void Write(Stream stream)
        {
            Write(stream, 0);
        }

        public void Write(Stream stream, int offset)
        {
            stream.Write(Bytes, offset, Bytes.Length);
        }

        public static string ToString(byte[] bytes)
        {
            string builder = string.Empty;
            int i = 0;
            while (true)
            {
                byte byteValue = bytes[i++];
                char c = (char)byteValue;
                if (!char.IsLetterOrDigit(c))
                    c = ' ';
                builder += c;

                if (i >= bytes.Length)
                    break;
            }

            return builder;
        }

        public static byte[] StringToBytes(string input)
        {
            return StringToBytes(input, Encoding.Default, input.Length);
        }

        public static byte[] StringToBytes(string input, int charLength)
        {
            return StringToBytes(input, Encoding.Default, charLength);
        }

        public static byte[] StringToBytes(string input, Encoding encoder, int charLength)
        {
            byte[] returnBytes = new byte[charLength];
            Array.Copy(encoder.GetBytes(input), 0, returnBytes, 0, Math.Min(input.Length, charLength));
            return returnBytes;
        }

        public static DataChunk Read(Stream stream)
        {
            return Read(stream, 0, (int)stream.Length);
        }

        public static DataChunk Read(Stream stream, int start, int length)
        {
            DataChunk chunk = new DataChunk(stream, start, length);

            return chunk;
        }
    }
}
