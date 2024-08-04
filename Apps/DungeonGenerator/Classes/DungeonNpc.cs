using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TRW.GameLibraries.GameCore;

namespace DungeonGenerator
{
    [Serializable]
    public class DungeonNpc : IDungeonComponentBase, ISerializable
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SerializedInfo", Serialize());
        }

        public string Serialize()
        {
            string serialized = $"{Name}|{UniqueIdentifier}|{Race}|{Class}|{ChallengeRating}|{(int)Hostility}|{Notes}";

            return serialized;
        }

        protected DungeonNpc(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            Deserialize(serializationInfo.GetString("SerializedInfo"));
        }

        public static DungeonNpc GenerateRandom()
        {
            return new DungeonNpc();
        }

    }
}
