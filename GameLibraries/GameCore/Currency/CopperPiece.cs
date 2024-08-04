using System;
using System.Runtime.Serialization;

namespace TRW.GameLibraries.GameCore
{
    [Serializable]
    public class CopperPiece : Coin
    {
        public override int BaseValue => 1;

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
