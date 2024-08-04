using System;

namespace TRW.CommonLibraries.ProceduralAlgorithms
{
    public class CellularAutomataRule<R> : Tuple<int, R>
    {
        public CellularAutomataRule(int item1, R item2, R newState) : base(item1, item2)
        {
            this.NewState = newState;
        }

        public int AliveNeighbors { get { return this.Item1; } }
        public R CurrentState { get { return this.Item2; } }
        public R NewState { get; private set; }

        public bool Equals(int aliveNeighbors, R currentState)
        {
            return (this.AliveNeighbors.Equals(aliveNeighbors) && this.CurrentState.Equals(currentState));
        }
    }
}
