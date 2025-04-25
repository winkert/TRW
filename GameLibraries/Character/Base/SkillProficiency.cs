using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.GameLibraries.Character
{
    [Serializable]
    public class SkillProficiency : Proficiency
    {
        #region Fields
        private Skills _skill;
        #endregion

        #region Constructors
        public SkillProficiency():base(string.Empty, ProficiencyTypes.Skill)
        {

        }
        public SkillProficiency(Skills skill) : base(TRW.CommonLibraries.Core.EnumExtensions.GetDescription(skill), ProficiencyTypes.Skill)
        {
            _skill = skill;
        }
        #endregion

        #region Properties
        public Skills Skill => _skill;
        #endregion

        #region Public Methods
        public override void WriteTo(BinaryWriter writer)
        {
            writer.Write((int)_skill);
            base.WriteTo(writer);
        }
        public override void ReadFrom(BinaryReader reader)
        {
            _skill = (Skills)reader.ReadInt32();
            base.ReadFrom(reader);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
