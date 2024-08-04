using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio.Streaming
{
    public struct AudioDetails
    {
        internal const short BitDivider = 8;

        public AudioDetails(string fileFormat, short audioFormat, short numberOfChannels, int sampleRate, short bitsPerSample) : this()
        {
            FileFormat = fileFormat;
            AudioFormat = audioFormat;
            NumberOfChannels = numberOfChannels;
            SampleRate = sampleRate;
            BitsPerSample = bitsPerSample;
            Samples = new AudioSamples(NumberOfChannels);
        }

        public string FileFormat { get; set; }
        /// <summary>
        /// PCM = 1
        /// </summary>
        public short AudioFormat { get; set; }

        public short NumberOfChannels { get; set; }

        public int SampleRate { get; set; }

        public short BitsPerSample { get; set; }

        public int ByteRate => SampleRate * NumberOfChannels * (BitsPerSample / BitDivider);

        public short BlockAlign => (short)(NumberOfChannels * (BitsPerSample / BitDivider));

        public AudioSamples Samples { get; set; }
    }
}
