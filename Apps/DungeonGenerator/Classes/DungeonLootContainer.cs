using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGenerator
{
    public class DungeonLootContainer : IDungeonComponentBase, ISerializable
    {
        private Guid _uniqueId;

        public DungeonLootContainer()
        {
            _uniqueId = Guid.NewGuid();
            Items = new DungeonLootCollection();
        }

        public string Name { get; set; }

        public ComponentType ComponentType => ComponentType.Container;

        public Guid UniqueIdentifier => _uniqueId;

        internal DungeonLootCollection Items { get; }

        public int Capacity { get; set; }

        public bool Add(DungeonLoot loot)
        {
            if (Items.Count + 1 >= Capacity)
                return false;

            Items.Add(loot);
            return true;
        }

        public void Clear()
        {
            Items.Clear();
        }

        public void Deserialize(string serialized)
        {
            string[] objs = serialized.Split('|');
            Name = objs[0];
            string guidString = objs[1];
            _uniqueId = new Guid(guidString);
            Capacity = int.Parse(objs[2]);
        }

        public string Serialize()
        {
            string serialized = $"{Name}|{UniqueIdentifier}|{Capacity}";

            return serialized;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Info", Serialize());
            info.AddValue("Items", Items);
        }

        protected DungeonLootContainer(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            Deserialize(serializationInfo.GetString("Info"));
            Items = (DungeonLootCollection)serializationInfo.GetValue("Items", typeof(DungeonLootCollection));
        }

    }
}
