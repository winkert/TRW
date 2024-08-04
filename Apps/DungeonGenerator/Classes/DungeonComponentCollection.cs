using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGenerator
{
    [Serializable]
    public class DungeonComponentCollection<T> : List<T>, ISerializable where T : IDungeonComponentBase, new()
    {
        protected Random _r = new Random();

        public DungeonComponentCollection() : base() { }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Count", this.Count);
            for (int i = 0; i < Count; i++)
            {
                info.AddValue($"Item{i}", this[i].Serialize());
            }
        }

        protected DungeonComponentCollection(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            int count = serializationInfo.GetInt32("Count");
            for (int i = 0; i < count; i++)
            {
                T obj = new T();
                obj.Deserialize(serializationInfo.GetString($"Item{i}"));
                this.Add(obj);
            }
        }
    }
    [Serializable]
    internal class DungeonLootCollection : DungeonComponentCollection<DungeonLoot>
    {
        public DungeonLootCollection() : base() { }
        protected DungeonLootCollection(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }

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
        protected DungeonNpcCollection(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }

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
