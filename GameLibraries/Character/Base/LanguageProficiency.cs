using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.GameLibraries.Character
{
    [Serializable]
    public class LanguageProficiency:Proficiency
    {
        #region Fields
        private Languages _language;
        #endregion

        #region Constructors
        public LanguageProficiency():base(string.Empty, ProficiencyTypes.Language)
        {

        }
        public LanguageProficiency(Languages language) : base(TRW.CommonLibraries.Core.EnumExtensions.GetDescription(language), ProficiencyTypes.Language)
        {
            _language = language;
        }
        #endregion

        #region Properties
        public Languages Language => _language;
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
