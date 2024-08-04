using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio.Streaming
{
    public class WaveWriter : AudioWriter
    {
        internal long WaveDataStartPosition { get; private set; }
        internal long WaveDataLastPosition { get; private set; }

        public WaveWriter(string writePath) : base(writePath)
        {
        }

        public void WriteHeader()
        {
            GoTo(Wave.WaveGlobals.HeaderStartPosition);
            Write(Serialization.DataChunk.StringToBytes("RIFF"));
            GoTo(Wave.WaveGlobals.WaveIdPosition);
            Write(Serialization.DataChunk.StringToBytes("WAVE"));
        }

        public void WriteFormat(short channels, int samplesPerS, short sizeOfSamplesBytes)
        {
            GoTo(Wave.WaveGlobals.FormatStartPosition);
            Write(Serialization.DataChunk.StringToBytes("fmt", 4));
            Write(BitConverter.GetBytes(16));
            Write(BitConverter.GetBytes((short)1)); //"WAVE_FORMAT_PCM"
            Write(BitConverter.GetBytes(channels));
            Write(BitConverter.GetBytes(samplesPerS));
            Write(BitConverter.GetBytes(samplesPerS * sizeOfSamplesBytes * channels));
            Write(BitConverter.GetBytes((short)(sizeOfSamplesBytes * channels)));
            Write(BitConverter.GetBytes(sizeOfSamplesBytes * 8));
        }

        public void WriteSampleDataHeader(short channels, int numberOfBlocks, short sizeOfSamplesBytes)
        {
            int mcs = sizeOfSamplesBytes * channels * numberOfBlocks;
            GoTo(Wave.WaveGlobals.DataStartPosition);
            Write(Serialization.DataChunk.StringToBytes("data"));
            Write(BitConverter.GetBytes(mcs));

            WaveDataStartPosition = _byteWriter.Position;
            WaveDataLastPosition = _byteWriter.Position;
        }

        public void WriteSample(int samplesPerSecond, double frequency, int durationMs)
        {
            GoTo(WaveDataLastPosition);
            //Nc*Ns channel-interleaved M-byte samples
            double theta = frequency * Wave.WaveGlobals.TAU / samplesPerSecond;
            int samplesToWrite = (int)((decimal)samplesPerSecond * durationMs / 1000m);

            for (int step = 0; step < samplesToWrite; step++)
            {
                short s = (short)(Wave.WaveGlobals.BaseAmplitude * Math.Sin(theta * step));
                Write(BitConverter.GetBytes(s));
            }

            WaveDataLastPosition = _byteWriter.Position;
        }

        public void WriteSample(short channels, int samplesPerSecond, int durationMs, params double[] frequencies)
        {
            if (frequencies.Length != channels)
                throw new ArgumentException();

            GoTo(WaveDataLastPosition);
            //Nc*Ns channel-interleaved M-byte samples
            int samplesToWrite = (int)((decimal)samplesPerSecond * durationMs / 1000m);

            for (int step = 0; step < samplesToWrite; step++)
            {
                for (short c = 0; c < channels; c++)
                {
                    double frequency = frequencies[c];
                    double theta = frequency * Wave.WaveGlobals.TAU / samplesPerSecond;
                    short s = (short)(Wave.WaveGlobals.BaseAmplitude * Math.Sin(theta * step));
                    // for each channel, write a single short for each sample
                    Write(BitConverter.GetBytes(s));
                }
            }

            WaveDataLastPosition = _byteWriter.Position;
        }

        public void FinalizeSampleData(short channels, int numberOfBlocks, short sizeOfSamplesBytes)
        {
            int mcs = sizeOfSamplesBytes * channels * numberOfBlocks;
            GoTo(Wave.WaveGlobals.DataSizePosition);
            Write(BitConverter.GetBytes(mcs));

            GoTo(WaveDataLastPosition);
            if (mcs % 2 > 0)
                Write(1);

        }

        public void FinalizeWaveFile(short channels, int numberOfBlocks, short sizeOfSamplesBytes)
        {
            GoTo(Wave.WaveGlobals.ChunkSizePosition);
            int mcs = sizeOfSamplesBytes * channels * numberOfBlocks;
            int pad = mcs % 2 > 0 ? 1 : 0;
            int totalWaveSize = 4 + 24 + 8 + mcs + pad;

            // validation
            long writtenLength = _byteWriter.Length;
            if (totalWaveSize != writtenLength)
            {

            }

            Write(BitConverter.GetBytes(totalWaveSize));

        }
    }
}
