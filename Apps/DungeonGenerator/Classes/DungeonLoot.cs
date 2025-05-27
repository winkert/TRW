using System;
using System.IO;
using TRW.GameLibraries.GameCore;

namespace DungeonGenerator
{
    [Serializable]
    public class DungeonLoot : ItemBase, IDungeonComponentBase
    {
        private Guid _uniqueId;


        public DungeonLoot()
            : base(string.Empty, string.Empty, 0m)
        {
            _uniqueId = Guid.NewGuid();
        }

        public DungeonLoot(string name, string description, decimal weight)
            :base(name, description, weight)
        {

        }

        public DungeonLoot(string name, string description, decimal weight, decimal value)
            : base(name, description, weight)
        {
            Value = value;
        }

        public ComponentType ComponentType { get => ComponentType.Loot; }
        public Guid UniqueIdentifier => _uniqueId;
        public decimal Value { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public void Deserialize(string serialized)
        {
            string[] objs = serialized.Split('|');
            Name = objs[0];
            string guidString = objs[1];
            _uniqueId = new Guid(guidString);
            Description = objs[2];
            Weight = decimal.Parse(objs[3]);
            Value = decimal.Parse(objs[4]);
        }

        public string Serialize()
        {
            string serialized = $"{Name}|{UniqueIdentifier}|{Description}|{Weight}|{Value}";

            return serialized;
        }

        protected override void DeserializeObject(BinaryReader reader)
        {
            Deserialize(reader.ReadString());
        }

        protected override void SerializeObject(BinaryWriter writer)
        {
            writer.Write(Serialize());
        }

    }
}
