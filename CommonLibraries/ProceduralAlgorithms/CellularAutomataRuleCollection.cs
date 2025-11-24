using System;
using System.Collections;
using System.Collections.Generic;

namespace TRW.CommonLibraries.ProceduralAlgorithms
{
    public class CellularAutomataRuleCollection<R> : ICollection<CellularAutomataRule<R>> where R : IComparable<R>
    {
        private HashSet<CellularAutomataRule<R>> _rules;

        public CellularAutomataRuleCollection()
        {
            _rules = new HashSet<CellularAutomataRule<R>>();
        }

        public int Count => (_rules).Count;

        public bool IsReadOnly => true;

        public R this[int aliveNeighbors, R currentState]
        {
            get
            {
                var searchKey = new CellularAutomataRule<R>(aliveNeighbors, currentState, default(R));
                if(_rules.TryGetValue(searchKey, out var rule))
                {
                    return rule.NewState;
                }

                return default(R);
            }
        }

        public void Add(CellularAutomataRule<R> item)
        {
            _rules.Add(item);
        }

        public void Clear()
        {
            (_rules).Clear();
        }

        public bool Contains(CellularAutomataRule<R> item)
        {
            return (_rules).Contains(item);

        }

        public void CopyTo(CellularAutomataRule<R>[] array, int arrayIndex)
        {
            (_rules).CopyTo(array, arrayIndex);
        }

        public IEnumerator<CellularAutomataRule<R>> GetEnumerator()
        {
            return (_rules).GetEnumerator();

        }

        public bool Remove(CellularAutomataRule<R> item)
        {
            return (_rules).Remove(item);

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (_rules).GetEnumerator();
        }
    }
}
