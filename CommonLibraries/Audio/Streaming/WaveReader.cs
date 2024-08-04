using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TRW.CommonLibraries.Serialization;

namespace TRW.CommonLibraries.Audio.Streaming
{
    public class WaveReader : AudioReader
    {
        public WaveReader(string sourceFile)
            : base(sourceFile) { }


        public override AudioDetails GetDetails()
        {
            WaveHeaderChunk header = ReadHeaderChunk();
            WaveFormatChunk format = ReadFormatChunk();
            WaveDataChunk data = ReadDataChunk(header, format);

            AudioDetails details = new AudioDetails(header.ChunkFormat, format.AudioFormat, format.Channels, format.SampleRate, format.BitsPerSample);
            int i = 0;
            while(true)
            {
                if(data.TryGetSample(format.Channels, i++, out byte[] sample))
                {
                    details.Samples.Add(sample);
                }
                else
                {
                    break;
                }
            }

            return details;
        }

        public WaveHeaderChunk ReadHeaderChunk()
        {
            GoTo(Wave.WaveGlobals.HeaderStartPosition);
            byte[] header = new byte[Wave.WaveGlobals.HeaderTotalBytes];
            _byteReader.Read(header, 0, (int)Wave.WaveGlobals.HeaderTotalBytes);

            byte[] chunkId = new byte[4] { header[0], header[1], header[2], header[3] };
            byte[] chunkSize = new byte[4] { header[4], header[5], header[6], header[7] };
            byte[] chunkFormat = new byte[4] { header[8], header[9], header[10], header[11] };

            WaveHeaderChunk chunk = new WaveHeaderChunk(chunkId, chunkSize, chunkFormat);

            return chunk;
        }

        public WaveFormatChunk ReadFormatChunk()
        {
            GoTo(Wave.WaveGlobals.FormatStartPosition);
            byte[] formatBytes = new byte[Wave.WaveGlobals.FormatTotalBytes];
            _byteReader.Read(formatBytes, 0, (int)Wave.WaveGlobals.FormatTotalBytes);
            byte[] id = new byte[4] { formatBytes[0], formatBytes[1], formatBytes[2], formatBytes[3] };
            byte[] size = new byte[4] { formatBytes[4], formatBytes[5], formatBytes[6], formatBytes[7] };
            byte[] format = new byte[2] { formatBytes[8], formatBytes[9] };
            byte[] channels = new byte[2] { formatBytes[10], formatBytes[11] };
            byte[] sampleRate = new byte[4] { formatBytes[12], formatBytes[13], formatBytes[14], formatBytes[15] };
            byte[] byteRate = new byte[4] { formatBytes[16], formatBytes[17], formatBytes[18], formatBytes[19] };
            byte[] blockAlign = new byte[2] { formatBytes[20], formatBytes[21] };
            byte[] bitsPerSample = new byte[2] { formatBytes[22], formatBytes[23] };

            WaveFormatChunk chunk = new WaveFormatChunk(id, size, format, channels, sampleRate, byteRate, blockAlign, bitsPerSample);

            return chunk;
        }

        public WaveDataChunk ReadDataChunk(WaveHeaderChunk header, WaveFormatChunk format)
        {
            GoTo(Wave.WaveGlobals.DataStartPosition);
            int bytesRemainingInFile = header.ChunkSize - (int)Wave.WaveGlobals.DataStartPosition + 8; // ChunkSize = All Bytes except the first 8 of the file so we want 
            byte[] dataBytes = new byte[bytesRemainingInFile];
            _byteReader.Read(dataBytes, 0, bytesRemainingInFile);
            byte[] id = new byte[4] { dataBytes[0], dataBytes[1], dataBytes[2], dataBytes[3] };
            byte[] size = new byte[4] { dataBytes[4], dataBytes[5], dataBytes[6], dataBytes[7] };
            int chunkSize = BitConverter.ToInt32(size, 0);
            byte[] data = new byte[chunkSize];
            Array.Copy(dataBytes, 8, data, 0, bytesRemainingInFile - 8);

            return new WaveDataChunk(id, size, data, format.Channels);
        }

    }

}
