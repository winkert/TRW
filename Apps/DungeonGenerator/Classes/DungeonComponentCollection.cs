using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TRW.CommonLibraries.Serialization;

namespace DungeonGenerator
{
    [Serializable]
    public class DungeonComponentCollection<T> : List<T>, IBinarySerializable where T : IDungeonComponentBase, IBinarySerializable, new()
    {
        protected Random _r = new Random();

        public DungeonComponentCollection() : base() { }

        public void WriteTo(BinaryWriter writer)
        {
            BinarySerializationRoutines.WriteCollection(writer, this.Count, this);
        }
        public void ReadFrom(BinaryReader reader)
        {
            BinarySerializationRoutines.ReadCollection(reader, reader.ReadInt32(), this);
        }

        public byte[] ToByteArray()
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms))
            {
                WriteTo(bw);
                return ms.ToArray();
            }
        }

    }
    [Serializable]
    internal class DungeonLootCollection : DungeonComponentCollection<DungeonLoot>
    {
        public DungeonLootCollection() : base() { }
        

        public DungeonLoot GetRandom(decimal maxValue = decimal.MaxValue)
        {
            var tempList = this.Where(l => l.Value <= maxValue);
            if (tempList.Count() > 1)
            {
                return tempList.ToArray()[_r.Next(0, tempList.Count() - 1)];
            }

            if (tempList.Count() == 0)
                return null;

            return tempList.FirstOrDefault();

        }
    }
    [Serializable]
    internal class DungeonNpcCollection : DungeonComponentCollection<DungeonNpc>
    {
        public DungeonNpcCollection() : base() { }

        public DungeonNpc GetRandom(int maxCR = int.MaxValue)
        {
            var tempList = this.Where(n => n.ChallengeRating <= maxCR);
            if (tempList.Count() > 1)
            {
                return tempList.ToArray()[_r.Next(0, tempList.Count() - 1)];
            }

            if (tempList.Count() == 0)
                return null;

            return tempList.FirstOrDefault();

        }
    }
}
