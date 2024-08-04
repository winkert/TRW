using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.GameLibraries.Character
{
    [Serializable]
    public class ProficiencyCollection : ProficiencyCollection<Proficiency>
    {
        public ProficiencyCollection()
        {
        }

        public ProficiencyCollection(ProficiencyCollection<Proficiency> clone) 
            : base(clone)
        {
        }

        public ProficiencyCollection(int totalProficienciesAllowed, params Proficiency[] proficiencies) 
            : base(totalProficienciesAllowed, proficiencies)
        {
        }
    }

    [Serializable]
    public class ProficiencyCollection<T> : ICollection<T> where T : Proficiency
    {
        #region Fields
        protected List<T> _proficiencies;
        protected int _totalProficienciesAllowed;
        #endregion

        #region Constructors
        public ProficiencyCollection(int totalProficienciesAllowed, params T[] proficiencies)
        {
            _totalProficienciesAllowed = totalProficienciesAllowed;
            InitializeCollection(proficiencies);
        }

        public ProficiencyCollection(ProficiencyCollection<T> clone)
        {
            _totalProficienciesAllowed = clone._totalProficienciesAllowed;
            InitializeCollection(clone._proficiencies);
        }

        public ProficiencyCollection()
        {
            InitializeCollection(null);
        }
        #endregion

        #region Properties
        public int Count => ((ICollection<Proficiency>)_proficiencies).Count;

        public bool IsReadOnly => ((ICollection<Proficiency>)_proficiencies).IsReadOnly;

        public int TotalProficiencies => _totalProficienciesAllowed;
        #endregion

        #region Public Methods
        public void Add(T item)
        {
            _proficiencies.Add(item);
        }

        public void AddRange(ICollection<T> items)
        {
            _proficiencies.AddRange(items);
        }

        public void Clear()
        {
            ((ICollection<Proficiency>)_proficiencies).Clear();
        }

        public bool Contains(T item)
        {
            return _proficiencies.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _proficiencies.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _proficiencies.GetEnumerator();
        }

        public bool Remove(T item)
        {
            return _proficiencies.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _proficiencies.GetEnumerator();
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
        protected virtual void InitializeCollection(IEnumerable<T> proficiencies)
        {
            _proficiencies = new List<T>();
            if (proficiencies != null)
            {
                foreach (T prof in proficiencies)
                    _proficiencies.Add(prof);
            }
        }
        #endregion
    }
}
