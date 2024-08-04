using System;
using System.Runtime.Serialization;

namespace TRW.GameLibraries.GameCore
{
    [Serializable]
    public class GoldPiece : Coin
    {
        public override int BaseValue => 100;

        protected override void DeserializeObject(SerializationInfo info)
        {
            // add any serialized properties here
        }

        protected override void SerializeObject(SerializationInfo info)
        {
            // add any serialized properties here
        }
    }
}
