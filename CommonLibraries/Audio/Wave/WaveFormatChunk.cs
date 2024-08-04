using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TRW.CommonLibraries.Serialization;
using TRW.CommonLibraries.Core;

namespace TRW.CommonLibraries.Audio
{
    public class WaveFormatChunk : DataChunk
    {
        public WaveFormatChunk(byte[] id, byte[] size, byte[] format, byte[] channels, byte[] sampleRate, byte[] byteRate, byte[] blockAlign, byte[] bitsPerSample)
            : this(id, size, format, channels, sampleRate, byteRate, blockAlign, bitsPerSample, null, null)
        { }

        public WaveFormatChunk(byte[] id, byte[] size, byte[] format, byte[] channels, byte[] sampleRate, byte[] byteRate, byte[] blockAlign, byte[] bitsPerSample, byte[] extraParamSize, byte[] extraParams)
        {
            SubChunkId = ToString(id);
            SubChunkSize = BitConverter.ToInt32(size, 0);
            AudioFormat = BitConverter.ToInt16(format, 0);
            Channels = BitConverter.ToInt16(channels, 0);
            SampleRate = BitConverter.ToInt32(sampleRate, 0);
            ByteRate = BitConverter.ToInt32(byteRate, 0);
            BlockAlign = BitConverter.ToInt16(blockAlign, 0);
            BitsPerSample = BitConverter.ToInt16(bitsPerSample, 0);

            Bytes = id.AppendBytes(size).AppendBytes(format).AppendBytes(channels).AppendBytes(sampleRate).AppendBytes(byteRate).AppendBytes(blockAlign).AppendBytes(bitsPerSample);
            if (extraParamSize != null)
            {
                ExtraParamSize = BitConverter.ToInt32(extraParamSize, 0);
                ExtraParams = extraParams;
                Bytes = Bytes.AppendBytes(extraParamSize).AppendBytes(extraParams);
            }

        }

        public string SubChunkId { get; }
        public int SubChunkSize { get; }
        public short AudioFormat { get; }
        public short Channels { get; }
        public int SampleRate { get; }
        public int ByteRate { get; } // => SampleRate * Channels * BitsPerSample / 8;
        public short BlockAlign { get; } // => Channels * BitsPerSample / 8;
        public short BitsPerSample { get; }
        public int ExtraParamSize { get; }
        public byte[] ExtraParams { get; }

    }
}
