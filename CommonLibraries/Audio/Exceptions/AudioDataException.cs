using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio.Exceptions
{
    public class AudioDataException : Exception
    {
        public AudioDataException()
            : base("Invalid Audio Data")
        {
        }

        public AudioDataException(string message) 
            : base($"Invalid Audio Data: {message}")
        {
        }
    }
}
