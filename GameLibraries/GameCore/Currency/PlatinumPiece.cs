using System;
using System.IO;
using System.Runtime.Serialization;

namespace TRW.GameLibraries.GameCore
{
    [Serializable]
    public class PlatinumPiece : Coin
    {
        public override int BaseValue => 1000;

        protected override void DeserializeObject(BinaryReader reader)
        {
            // add any serialized properties here
        }

        protected override void SerializeObject(BinaryWriter writer)
        {
            // add any serialized properties here
        }
    }
}
