using System;
using System.Collections.Generic;

namespace TRW.CommonLibraries.ProceduralAlgorithms
{
    public class CellularAutomataRule<R> : Tuple<int, R>, IComparable<CellularAutomataRule<R>> where R : IComparable<R>
    {
        public CellularAutomataRule(int item1, R item2, R newState) : base(item1, item2)
        {
            this.NewState = newState;
        }

        public int AliveNeighbors { get { return this.Item1; } }
        public R CurrentState { get { return this.Item2; } }
        public R NewState { get; private set; }

        public int CompareTo(CellularAutomataRule<R> other)
        {
            if(other == null)
                return 1;
            int compare = this.AliveNeighbors.CompareTo(other.AliveNeighbors);
            if (compare == 0)
                compare = this.CurrentState.CompareTo(other.CurrentState);

            return compare;
        }

        public bool Equals(int aliveNeighbors, R currentState)
        {
            return (this.AliveNeighbors.Equals(aliveNeighbors) && this.CurrentState.Equals(currentState));
        }

        public override bool Equals(object obj)
        {
            return obj is CellularAutomataRule<R> rule &&
                   base.Equals(obj) &&
                   AliveNeighbors == rule.AliveNeighbors &&
                   EqualityComparer<R>.Default.Equals(CurrentState, rule.CurrentState);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), AliveNeighbors, CurrentState);
        }
    }
}
