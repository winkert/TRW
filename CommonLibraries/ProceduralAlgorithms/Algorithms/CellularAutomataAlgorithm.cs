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
        public CellularAutomataAlgorithm(object sender, M grid, int xDim, int yDim) : base(sender, grid, xDim, yDim)
        {
        }

        private static ProceduralAlgorithmParameterCollection _parameters;
        public override ProceduralAlgorithmParameterCollection Parameters
        {
            get
            {
                if (_parameters == null)
                {
                    _parameters = new ProceduralAlgorithmParameterCollection(4)
                    {
                        new ProceduralAlgorithmParameter<CellularAutomataRulesSet<bool>>(CellularAutomataRulesParamName),
                        new ProceduralAlgorithmParameter<int>(IterationsParamName),
                        new ProceduralAlgorithmParameter<bool>(AvoidEdgesParamName),
                        new ProceduralAlgorithmParameter<bool>(MakeSquareParamName)
                    };
                }
                return _parameters;
            }
        }

        protected override void DoAlgorithmInternal(params object[] args)
        {
            CellularAutomataRulesSet<bool> neighborhoodRules = Parameters.GetParameterValue<CellularAutomataRulesSet<bool>>(args, CellularAutomataRulesParamName);
            int iterations = Parameters.GetParameterValue<int>(args, IterationsParamName);
            bool avoidEdges = Parameters.GetParameterValue<bool>(args, AvoidEdgesParamName);
            bool makeSquare = Parameters.GetParameterValue<bool>(args, MakeSquareParamName);
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
