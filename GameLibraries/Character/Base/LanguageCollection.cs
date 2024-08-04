using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.GameLibraries.Character
{
    [Serializable]
    public class LanguageCollection : ProficiencyCollection<LanguageProficiency>
    {
        #region Constructors
        public LanguageCollection(int totalProficienciesAllowed, params LanguageProficiency[] proficiencies)
            : base(totalProficienciesAllowed, proficiencies)
        {
            _proficiencies = new List<LanguageProficiency>();
        }

        public LanguageCollection(LanguageCollection clone)
            : base(clone)
        {

        }

        public LanguageCollection()
            : base()
        {
            _proficiencies = new List<LanguageProficiency>();
        }
        #endregion

        #region Properties
        public new int Count => _proficiencies.Count;

        public new bool IsReadOnly => ((ICollection<Languages>)_proficiencies).IsReadOnly;
        #endregion

        #region Public Methods
        
        public new void Clear()
        {
            ((ICollection<LanguageProficiency>)_proficiencies).Clear();
        }

        public new IEnumerator<LanguageProficiency> GetEnumerator()
        {
            return ((ICollection<LanguageProficiency>)_proficiencies).GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder proficiencyList = new StringBuilder();
            for (int i = 0; i < _proficiencies.Count; i++)
            {
                proficiencyList.AppendFormat("{0}{1}", _proficiencies[i].ToString(), ((i + 1) >= _proficiencies.Count ? "" : ", "));
            }

            if (_totalProficienciesAllowed > 0 && _totalProficienciesAllowed < _proficiencies.Count)
                return string.Format("Choose {0} from {1}", _totalProficienciesAllowed, proficiencyList);
            else
                return proficiencyList.ToString();
        }
        #endregion

        #region Private Methods
        protected override void InitializeCollection(IEnumerable<LanguageProficiency> proficiencies)
        {
            _proficiencies = new List<LanguageProficiency>();
            if (proficiencies != null)
            {
                foreach (LanguageProficiency prof in proficiencies)
                    _proficiencies.Add(prof);
            }
        }
        #endregion
    }
}
