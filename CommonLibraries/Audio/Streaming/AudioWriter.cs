using System;
using System.Collections.Generic;
using System.Text;
using TRW.CommonLibraries.Serialization;

namespace TRW.CommonLibraries.Audio.Streaming
{
    public abstract class AudioWriter : FileWriter
    {
        public AudioWriter(string writePath) : base(writePath)
        {
        }

    }
}
