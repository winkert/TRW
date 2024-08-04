using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Serialization
{
    public class FileWriter : IDisposable
    {
        protected FileStream _byteWriter;

        public FileWriter(string writePath)
        {
            _byteWriter = new FileStream(writePath, FileMode.OpenOrCreate, FileAccess.Write);
        }

        #region IDisposable
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_byteWriter != null)
                    {
                        _byteWriter.Dispose();
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
            if (_byteWriter.Length >= position)
            {
                _byteWriter.Position = position;
                return true;
            }

            return false;
        }

        public void WriteChar(char c)
        {
            _byteWriter.WriteByte((byte)c);
        }

        public void WriteString(string s)
        {
            WriteChars(s.ToCharArray());
        }

        public void WriteChars(params char[] c)
        {
            WriteChars(c, c.Length);
        }

        public void WriteChars(char[] c, int count)
        {
            byte[] bytes = new byte[count];
            for (int i = 0; i < count; i++)
            {
                if (c.Length > i)
                    bytes[i] = (byte)c[i];
            }

            Write(bytes, 0, count);
        }

        public void Write(params byte[] bytes)
        {
            Write(bytes, 0, bytes.Length);
        }

        public void Write(byte[] bytes, int offset, int count)
        {
            _byteWriter.Write(bytes, offset, count);
        }

    }
}
