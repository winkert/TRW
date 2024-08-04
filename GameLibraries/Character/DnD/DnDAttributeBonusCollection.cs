using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.GameLibraries.Character
{
    [Serializable]
    public class DnDAttributeBonusCollection : ICollection<DnDAttributeBonus>
    {
        #region Fields
        private List<DnDAttributeBonus> _attributeBonuses;
        private int _totalBonuses;

        #endregion

        #region Constructors
        public DnDAttributeBonusCollection(int totalBonuses)
        {
            _totalBonuses = totalBonuses;
            _attributeBonuses = new List<DnDAttributeBonus>();
        }
        #endregion

        #region Properties
        public int Count => ((ICollection<DnDAttributeBonus>)_attributeBonuses).Count;

        public bool IsReadOnly => ((ICollection<DnDAttributeBonus>)_attributeBonuses).IsReadOnly;

        public int TotalBonuses => _totalBonuses;

        public int UnusedAttributePoints => _attributeBonuses.Where(a => a.Attribute == Attributes.Players_Choice).Count();
        #endregion

        #region Public Methods
        public void Add(DnDAttributeBonus item)
        {
            ((ICollection<DnDAttributeBonus>)_attributeBonuses).Add(item);
        }

        public void Clear()
        {
            ((ICollection<DnDAttributeBonus>)_attributeBonuses).Clear();
        }

        public bool Contains(DnDAttributeBonus item)
        {
            return ((ICollection<DnDAttributeBonus>)_attributeBonuses).Contains(item);
        }

        public void CopyTo(DnDAttributeBonus[] array, int arrayIndex)
        {
            ((ICollection<DnDAttributeBonus>)_attributeBonuses).CopyTo(array, arrayIndex);
        }

        public IEnumerator<DnDAttributeBonus> GetEnumerator()
        {
            return ((ICollection<DnDAttributeBonus>)_attributeBonuses).GetEnumerator();
        }

        public bool Remove(DnDAttributeBonus item)
        {
            return ((ICollection<DnDAttributeBonus>)_attributeBonuses).Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<DnDAttributeBonus>)_attributeBonuses).GetEnumerator();
        }

        public override string ToString()
        {
            if (_totalBonuses < _attributeBonuses.Count)
            {
                StringBuilder proficiencyList = new StringBuilder();
                List<DnDAttributeBonus> requiredProficiencies = new List<DnDAttributeBonus>();
                List<DnDAttributeBonus> notRequiredProficiencies = new List<DnDAttributeBonus>();
                foreach (DnDAttributeBonus bonus in _attributeBonuses)
                {
                    if (bonus.Requried)
                        requiredProficiencies.Add(bonus);
                    else
                        notRequiredProficiencies.Add(bonus);
                }
                if (requiredProficiencies.Count > 0)
                    proficiencyList.AppendFormat("{0}{1}", string.Join(",", requiredProficiencies), notRequiredProficiencies.Count > 0 ? " and " : "");
                if (notRequiredProficiencies.Count > 0)
                    proficiencyList.AppendFormat("Choose {0} from {1}", _totalBonuses - requiredProficiencies.Count, string.Join(",", notRequiredProficiencies));
                return proficiencyList.ToString();
            }
            else
                return string.Join(",", _attributeBonuses);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
