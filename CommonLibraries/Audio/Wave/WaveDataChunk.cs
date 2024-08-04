using System;
using System.Collections.Generic;
using System.Text;
using TRW.CommonLibraries.Audio.Exceptions;
using TRW.CommonLibraries.Audio.Streaming;
using TRW.CommonLibraries.Core;
using TRW.CommonLibraries.Serialization;

namespace TRW.CommonLibraries.Audio
{
    public class WaveDataChunk : DataChunk
    {
        private readonly byte[] _data;

        public WaveDataChunk(byte[] id, byte[] size, byte[] data, short channels)
        {
            DataChunkId = ToString(id);
            DataChunkSize = BitConverter.ToInt32(size, 0);
            _data = data;

            Bytes = id.AppendBytes(size).AppendBytes(data);

            Samples = new AudioSamples(channels);
            // DataChunkSize = Number of Samples
            // Data.Length = Number of Samples * Channels
            if (_data.Length != (DataChunkSize * channels))
            {
                // error
                throw new AudioDataException($"Samples [{DataChunkSize}] Channels [{channels}] Sample Bytes [{_data.Length}] Total Bytes [{Bytes.Length}]");
            }

            int i = 0;
            while (true)
            {
                if (TryGetSample(channels, i++, out byte[] sample))
                {
                    Samples.Add(sample);
                }
                else
                {
                    break;
                }
            }
        }

        public string DataChunkId { get; }
        public int DataChunkSize { get; }

        public byte[] GetData()
        {
            return _data;
        }

        public AudioSamples Samples { get; }

        public bool TryGetSample(short numberOfChannels, int sampleNumber, out byte[] sample)
        {
            sample = new byte[numberOfChannels];

            try
            {
                sample = GetSample(numberOfChannels, sampleNumber);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }

        public byte[] GetSample(short numberOfChannels, int sampleNumber)
        {
            byte[] sample = new byte[numberOfChannels];
            int start = sampleNumber * numberOfChannels;
            Array.Copy(_data, start, sample, 0, numberOfChannels);

            return sample;
        }
    }
}
