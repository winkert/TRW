using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRW.CommonLibraries.Core;

namespace TRW.CommonLibraries.ProceduralAlgorithms
{
    public class CellularAutomataAlgorithm<M, C> : ProceduralAlgorithmBase<M, C> where C : ICell where M : IMatrix<C>
    {
        private readonly Type[] parameterTypes = new Type[] { typeof(CellularAutomataRulesSet<bool>), typeof(int), typeof(bool), typeof(bool) };

        public CellularAutomataAlgorithm(object sender, M grid, int xDim, int yDim) : base(sender, grid, xDim, yDim)
        {
        }

        public override int NumberOfParamters => 4;

        public override Type[] TypesOfParameters => parameterTypes;

        protected override void DoAlgorithmInternal(params object[] args)
        {
            CellularAutomataRulesSet<bool> neighborhoodRules = args[0] as CellularAutomataRulesSet<bool>;
            int iterations = Convert.ToInt32(args[1]);
            bool avoidEdges = Convert.ToBoolean(args[2]);
            bool makeSquare = Convert.ToBoolean(args[3]);
            for (int i = 0; i < iterations; i++)
            {
                CellLifeCycle(neighborhoodRules, avoidEdges);
                InvokeCallback(0);
            }
            CellAutomataPostProcess(avoidEdges, makeSquare);
        }


        private void CellLifeCycle(CellularAutomataRulesSet<bool> neighborhoodRules, bool avoidEdges)
        {
            _grid.First();
            do
            {
                int activeNeighbors = _grid.Current.GetNeighborsByValue(true);
                bool val;
                if (avoidEdges && (_grid.Current.OnEastEdge || _grid.Current.OnNorthEdge || _grid.Current.OnSouthEdge || _grid.Current.OnWestEdge))
                    val = false;
                else
                    val = neighborhoodRules.GetCellState(activeNeighbors, Convert.ToBoolean(_grid.Current.Content));

                _grid.Current.Content = val;
            } while (_grid.Next());
        }

        private void CellAutomataPostProcess(bool avoidEdges, bool makeSquare)
        {

        }
    }
}
