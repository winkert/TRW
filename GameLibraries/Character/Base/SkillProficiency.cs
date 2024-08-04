using System;
using System.Collections.Generic;
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
        #endregion

        #region Private Methods

        #endregion
    }
}
