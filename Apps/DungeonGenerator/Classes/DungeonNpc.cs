using System;
using System.IO;
using TRW.CommonLibraries.Serialization;
using TRW.GameLibraries.GameCore;

namespace DungeonGenerator
{
    [Serializable]
    public class DungeonNpc : IDungeonComponentBase, IBinarySerializable
    {
        private Guid _uniqueId;

        public DungeonNpc()
        {
            _uniqueId = Guid.NewGuid();
        }

        public string Name { get; set; }
        public ComponentType ComponentType { get => ComponentType.NonPlayerCharacter; }
        public Guid UniqueIdentifier => _uniqueId;

        public string Race { get; set; }
        public string Class { get; set; }
        public decimal ChallengeRating { get; set; }
        public HostilityRatings Hostility { get; set; }
        public string Notes { get; set; }
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
            Race = objs[2];
            Class = objs[3];
            ChallengeRating = decimal.Parse(objs[4]);
            int hostilityInt = int.Parse(objs[5]);
            Hostility = (HostilityRatings)hostilityInt;
            Notes = objs[6];
        }

        public string Serialize()
        {
            string serialized = $"{Name}|{UniqueIdentifier}|{Race}|{Class}|{ChallengeRating}|{(int)Hostility}|{Notes}";

            return serialized;
        }

        public void WriteTo(BinaryWriter writer)
        {
            writer.Write(Serialize());
        }
        public void ReadFrom(BinaryReader reader)
        {
            Deserialize(reader.ReadString());
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

        public static DungeonNpc GenerateRandom()
        {
            return new DungeonNpc();
        }

    }
}
