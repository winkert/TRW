using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.ProceduralAlgorithms
{
    public class CellularAutomataRulesSet<R> where R : IComparable<R>
    {

        private readonly CellularAutomataRuleCollection<R> _rules;

        public CellularAutomataRulesSet()
        {
            _rules = new CellularAutomataRuleCollection<R>();
        }

        public void Add(int aliveNeighbors, R currentState, R newState)
        {
            this.Add(new CellularAutomataRule<R>(aliveNeighbors, currentState, newState));
        }

        public void Add(CellularAutomataRule<R> rule)
        {
            _rules.Add(rule);
        }

        public R GetCellState(int aliveNeighbors, R currentState)
        {
            if (_rules[aliveNeighbors, currentState] != null)
                return _rules[aliveNeighbors, currentState];

            throw new Exception(string.Format("Rule does not exists: AliveNeighbors: [{0}] CurrentState [{1}]", aliveNeighbors, currentState));
        }

        /// <summary>
        /// Creates a default rule set for boolean cellular automata.
        /// </summary>
        /// <returns></returns>
        public static CellularAutomataRulesSet<bool> DefaultRuleSetBool()
        {
            CellularAutomataRulesSet<bool> rules = new CellularAutomataRulesSet<bool>();
            rules.Add(0, true, false);
            rules.Add(0, false, false);
            rules.Add(1, true, false);
            rules.Add(1, false, false);
            rules.Add(2, false, false);
            rules.Add(4, true, false);
            rules.Add(4, false, false);
            rules.Add(5, true, false);
            rules.Add(5, false, false);
            rules.Add(6, true, false);
            rules.Add(6, false, false);
            rules.Add(7, true, false);
            rules.Add(7, false, false);
            rules.Add(8, true, false);
            rules.Add(8, false, false);
            rules.Add(2, true, true);
            rules.Add(3, true, true);
            rules.Add(3, false, true);
            //rules.Add(4, true, true);
            //rules.Add(4, false, true);

            return rules;
        }
    }
}
