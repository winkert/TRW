using System;
using System.IO;

namespace TRW.CommonLibraries.Serialization
{
    public class FileReader : IDisposable
    {
        protected FileStream _byteReader;

        public FileReader(string sourceFile)
        {
            _byteReader = new FileStream(sourceFile, FileMode.Open);
        }

        public bool AlphaNumericOnly { get; set; }

        #region IDisposable
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_byteReader != null)
                    {
                        _byteReader.Dispose();
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~AudioReader()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion

        public bool GoTo(long position)
        {
            if (_byteReader.Length >= position)
            {
                _byteReader.Position = position;
                return true;
            }

            return false;
        }

        public byte Peek()
        {
            byte val;
            long currentPos = _byteReader.Position;
            int read = _byteReader.ReadByte();
            if (read == -1)
                val = default;
            else
                val = (byte)read;
            _byteReader.Position = currentPos;
            return val;
        }

        public byte ReadNext()
        {
            int value = _byteReader.ReadByte();
            if (value == -1)
            {
                return default;
            }
            return (byte)value;
        }

        public byte[] ReadNext(int size)
        {
            byte[] read = new byte[size];
            int totalRead = _byteReader.Read(read, 0, size);
            if (totalRead != size)
                throw new IndexOutOfRangeException();

            return read;
        }

        public char ReadNextChar()
        {
            return ReadNextChar(out _, out _);
        }

        public char ReadNextChar(out byte byteValue, out bool endOfFile)
        {
            endOfFile = false;
            int value = _byteReader.ReadByte();
            if (value == -1)
            {
                endOfFile = true;
                byteValue = default;
                return default;
            }

            byteValue = (byte)value;
            char c = (char)byteValue;
            if (AlphaNumericOnly && !char.IsLetterOrDigit(c))
            {
                c = ' ';
            }

            return c;
        }

        public string ReadNextString()
        {
            string builder = string.Empty;

            while (true)
            {
                char c = (char)Peek();
                if (!char.IsLetterOrDigit(c))
                    break;
                builder += ReadNextChar();
            }

            return builder;
        }
    }
}
