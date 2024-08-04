using System;
using System.Collections.Generic;
using System.Text;
using TRW.CommonLibraries.Serialization;
using TRW.CommonLibraries.Core;

namespace TRW.CommonLibraries.Audio
{
    public class WaveHeaderChunk : DataChunk
    {
        public WaveHeaderChunk(byte[] id, byte[] size, byte[] format)
        {
            ChunkId = ToString(id);
            ChunkSize = BitConverter.ToInt32(size, 0);
            ChunkFormat = ToString(format);
            Bytes = id.AppendBytes(size).AppendBytes(format);
        }

        public string ChunkId { get; }
        public int ChunkSize { get; }
        public string ChunkFormat { get; }
    }
}
