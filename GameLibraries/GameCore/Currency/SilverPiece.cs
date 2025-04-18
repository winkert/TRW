using System;
using System.IO;
using System.Runtime.Serialization;

namespace TRW.GameLibraries.GameCore
{
    [Serializable]
    public class SilverPiece : Coin
    {
        public override int BaseValue => 10;

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
