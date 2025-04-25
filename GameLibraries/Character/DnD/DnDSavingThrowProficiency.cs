using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.GameLibraries.Character.DnD
{
    [Serializable]
    public class DnDSavingThrowProficiency : Proficiency
    {
        private Attributes _saveAttribute;

        public DnDSavingThrowProficiency() : base() { }
        public DnDSavingThrowProficiency(Attributes attribute) : base(attribute.ToString(), ProficiencyTypes.Saving_Throws)
        {
            _saveAttribute = attribute;
        }

        public Attributes SavingThrowAttribute => _saveAttribute;

        public override void ReadFrom(BinaryReader reader)
        {
            _saveAttribute = (Attributes)reader.ReadInt32();
            base.ReadFrom(reader);
        }

        public override void WriteTo(BinaryWriter writer)
        {
            writer.Write((int)_saveAttribute);
            base.WriteTo(writer);
        }
    }
}
