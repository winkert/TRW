using System;
using System.Runtime.Serialization;

namespace TRW.GameLibraries.GameCore
{
    [Serializable]
    public class ElectrumPiece : Coin
    {
        public override int BaseValue => 50;

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
