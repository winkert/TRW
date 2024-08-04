using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio.Streaming
{
    public class AudioSample
    {
        private readonly byte[] _sample;

        public AudioSample(short channels, params byte[] sampleBytes)
        {
            NumberOfChannels = channels;
            _sample = new byte[channels];
            for(int i = 0; i < channels; i++)
            {
                _sample[i] = sampleBytes[i];
            }
        }

        public short NumberOfChannels { get; }

        public byte[] GetSample() { return _sample; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for(short i = 0; i < NumberOfChannels; i++)
            {
                builder.Append(_sample[i]);
            }

            return builder.ToString();
        }
    }
}
