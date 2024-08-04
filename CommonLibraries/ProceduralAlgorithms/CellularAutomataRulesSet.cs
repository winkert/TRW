using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.ProceduralAlgorithms
{
    public class CellularAutomataRulesSet<R>
    {

        private readonly CellularAutomataRuleCollection<R> _rules;

        public CellularAutomataRulesSet()
        {
            _rules = new CellularAutomataRuleCollection<R>();
        }

        public void Add(int aliveNeighbors, R currentState, R newState)
        {
            _rules.Add(new CellularAutomataRule<R>(aliveNeighbors, currentState, newState));
        }


        public R GetCellState(int aliveNeighbors, R currentState)
        {
            if (_rules[aliveNeighbors, currentState] != null)
                return _rules[aliveNeighbors, currentState];

            throw new Exception(string.Format("Rule does not exists: AliveNeighbors: [{0}] CurrentState [{1}]", aliveNeighbors, currentState));
        }
    }
}
