using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.GameLibraries.Character
{
    [Serializable]
    public class SkillCollection : ProficiencyCollection<SkillProficiency>
    {
        #region Constructors
        public SkillCollection(int totalProficienciesAllowed, params SkillProficiency[] proficiencies)
            : base(totalProficienciesAllowed, proficiencies)
        {
            _proficiencies = new List<SkillProficiency>();
        }

        public SkillCollection()
            :base()
        {
            _proficiencies = new List<SkillProficiency>();
        }

        #endregion

        #region Properties
        public new int Count => _proficiencies.Count;

        public new bool IsReadOnly => ((ICollection<Skills>)_proficiencies).IsReadOnly;
        #endregion

        #region Public Methods
        public new void Clear()
        {
            ((ICollection<SkillProficiency>)_proficiencies).Clear();
        }

        public new IEnumerator<SkillProficiency> GetEnumerator()
        {
            return ((ICollection<SkillProficiency>)_proficiencies).GetEnumerator();
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
        protected override void InitializeCollection(IEnumerable<SkillProficiency> proficiencies)
        {
            _proficiencies = new List<SkillProficiency>();
            if (proficiencies != null)
            {
                foreach (SkillProficiency prof in proficiencies)
                    _proficiencies.Add(prof);
            }
        }
        #endregion
    }
}
