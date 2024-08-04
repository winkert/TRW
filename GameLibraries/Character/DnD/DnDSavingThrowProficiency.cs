using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.GameLibraries.Character.DnD
{
    [Serializable]
    public class DnDSavingThrowProficiency : Proficiency
    {
        private Attributes _saveAttribute;

        public DnDSavingThrowProficiency(Attributes attribute) : base(attribute.ToString(), ProficiencyTypes.Saving_Throws)
        {
            _saveAttribute = attribute;
        }

        public Attributes SavingThrowAttribute => _saveAttribute;
    }
}
