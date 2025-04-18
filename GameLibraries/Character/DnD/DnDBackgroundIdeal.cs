using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.GameLibraries.Character.DnD
{
    [Serializable]
    public class DnDBackgroundIdeal : CharacterPropertyBase
    {
        public DnDBackgroundIdeal():base() { }
        public DnDBackgroundIdeal(string name, string description) : base(name, description)
        {
        }

        public override CharacterPropertyBase Clone()
        {
            throw new NotImplementedException();
        }

        public override void ReadFrom(BinaryReader reader)
        {
            ReadFromBase(reader);
        }

        public override void WriteTo(BinaryWriter writer)
        {
            WriteToBase(writer);
        }
    }
}
