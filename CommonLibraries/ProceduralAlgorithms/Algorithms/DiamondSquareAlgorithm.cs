using System;
using TRW.CommonLibraries.Core;

namespace TRW.CommonLibraries.ProceduralAlgorithms
{
    public class DiamondSquareAlgorithm<M, C> : ProceduralAlgorithmBase<M, C> where C : ICell where M : IMatrix<C>
    {
        public DiamondSquareAlgorithm(object sender, M grid, int xDim, int yDim) : base(sender, grid, xDim, yDim)
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
                        new ProceduralAlgorithmParameter<int>(StepParamName),
                        new ProceduralAlgorithmParameter<decimal>(SpreadParamName)
                    };
                }
                return _parameters;
            }
        }

        /*
         * Start with a grid of size 2^n + 1, where n is the number of iterations.
         * Assign random values to the corners of the grid.
         * Diamond step
         *      Get the average of the four sides and add a random value based on the spread factor.
         * Square step
         *      Get the average of the four corners and add a random value based on the spread factor.
         */


        protected override void DoAlgorithmInternal(params object[] args)
        {
            int step = Parameters.GetParameterValue<int>(args, StepParamName);
            decimal spread = Parameters.GetParameterValue<decimal>(args, SpreadParamName);

            _grid[0, _yDimension - 1].Content = GetNextDecimal(spread);
            _grid[_xDimension - 1, 0].Content = GetNextDecimal(spread);
            _grid[_xDimension - 1, _yDimension - 1].Content = GetNextDecimal(spread);
            _grid[0, 0].Content = GetNextDecimal(spread);

            DoDiamondSquare(0, 0, _xDimension - 1, _yDimension - 1, spread);
        }

        private void DoDiamondSquare(int x1, int y1, int x2, int y2, decimal spread)
        {
            int step = x2 - x1;
            if (step < 2)
                return;
            int halfStep = step / 2;
            int midX = (x1 + x2) / 2;
            int midY = (y1 + y2) / 2;
            int cx = x1 + halfStep;
            int cy = y1 + halfStep;
            
            // Diamond step for the four edge centers (N, E, S, W)
            DoDiamond(cx, y1, halfStep, spread); // top edge center
            DoDiamond(x2, cy, halfStep, spread); // right edge center
            DoDiamond(cx, y2, halfStep, spread); // bottom edge center
            DoDiamond(x1, cy, halfStep, spread); // left edge center

            // Square step for the center
            DoSquare(cx, cy, halfStep, spread);

            // Attenuate spread (use same factor as other overload for smoother falloff)
            decimal newSpread = spread * 0.6m;
            DoDiamondSquare(x1, y1, midX, midY, newSpread);
            DoDiamondSquare(midX, y1, x2, midY, newSpread);
            DoDiamondSquare(x1, midY, midX, y2, newSpread);
            DoDiamondSquare(midX, midY, x2, y2, newSpread);
        }

        private void DoSquare(int cx, int cy, int step, decimal spread)
        {
            if (_grid.CellExists(cx, cy))
            {
                _grid[cx, cy].Content = GetAverageSquare(cx, cy, step) + GetNextDecimal(spread);
            }
        }

        private decimal GetAverageSquare(int cx, int cy, int step)
        {
            /*AVG([CX - Step, CY - Step], [CX + Step, CY - Step], [CX - Step, CY + Step], [CX + Step, CY + Step])
             *     |     |     |     |
             *     |  4  |     |  3  |
             *     |     |CX,CY|     |
             *     |  1  |     |  2  |
             *     |     |     |     |
             */
            decimal value = 0;
            int cells = 0;
            if (_grid.CellExists(cx - step, cy - step))
            {
                cells++;
                value += Convert.ToDecimal(_grid[cx - step, cy - step].Content);
            }
            if (_grid.CellExists(cx + step, cy - step))
            {
                cells++;
                value += Convert.ToDecimal(_grid[cx + step, cy - step].Content);
            }
            if (_grid.CellExists(cx - step, cy + step))
            {
                cells++;
                value += Convert.ToDecimal(_grid[cx - step, cy + step].Content);
            }
            if (_grid.CellExists(cx + step, cy + step))
            {
                cells++;
                value += Convert.ToDecimal(_grid[cx + step, cy + step].Content);
            }

            if (cells > 0)
                value = value / (decimal)cells;

            if(cells == 0)
                Console.WriteLine($"Found 0 neighbors at [{cx},{cy}] Step = [{step}");

            return value;
        }

        private void DoDiamond(int cx, int cy, int step, decimal spread)
        {
            if (_grid.CellExists(cx, cy))
            {
                _grid[cx, cy].Content = GetAverageDiamond(cx, cy, step) + GetNextDecimal(spread);
            }
        }

        private decimal GetAverageDiamond(int cx, int cy, int step)
        {
            /*AVG([CX, CY - Step], [CX + Step, CY], [CX, CY + Step], [CX - Step, CY])
             *     |     |     |     |
             *     |     |  3  |     |
             *     |  2  |CX,CY|  4  |
             *     |     |  1  |     |
             *     |     |     |     |
             */
            decimal value = 0;
            int cells = 0;
            if (_grid.CellExists(cx, cy - step))
            {
                cells++;
                value += Convert.ToDecimal(_grid[cx, cy - step].Content);
            }
            if (_grid.CellExists(cx + step, cy))
            {
                cells++;
                value += Convert.ToDecimal(_grid[cx + step, cy].Content);
            }
            if (_grid.CellExists(cx, cy + step))
            {
                cells++;
                value += Convert.ToDecimal(_grid[cx, cy + step].Content);
            }
            if (_grid.CellExists(cx - step, cy))
            {
                cells++;
                value += Convert.ToDecimal(_grid[cx - step, cy].Content);
            }

            if (cells > 0)
                value = value / (decimal)cells;

            if (cells == 0)
                Console.WriteLine($"Found 0 neighbors at [{cx},{cy}] Step = [{step}");

            return value;
        }
    }
}
