using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRW.CommonLibraries.Core;

namespace TRW.CommonLibraries.ProceduralAlgorithms
{
    public class DiamondSquareAlgorithm<M, C> : ProceduralAlgorithmBase<M, C> where C : ICell where M : IMatrix<C>
    {
        private readonly Type[] parameterTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(decimal) };

        public DiamondSquareAlgorithm(object sender, M grid, int xDim, int yDim) : base(sender, grid, xDim, yDim)
        {

        }

        public override int NumberOfParamters => 4;
        public override Type[] TypesOfParameters => parameterTypes;

        protected override void DoAlgorithmInternal(params object[] args)
        {
            int cx = Convert.ToInt32(args[0]);
            int cy = Convert.ToInt32(args[1]);
            int step = Convert.ToInt32(args[2]);
            decimal spread = Convert.ToDecimal(args[3]);

            if (cx > _xDimension || cy > _yDimension)
                return;

            if (step < 1)
                return;

            DoDiamondSquare(cx - step, cy - step, step, spread);
            DoDiamondSquare(cx - step, cy + step, step, spread);
            DoDiamondSquare(cx + step, cy - step, step, spread);
            DoDiamondSquare(cx + step, cy + step, step, spread);
        }

        private void DoDiamondSquare(int cx, int cy, int step, decimal spread)
        {
            DoSquare(cx, cy, step, spread);
            DoDiamond(cx, cy, step, spread);

            DoAlgorithm(cx, cy, step / 2, spread * 0.75m);
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
            //AVG([CX - Step, CY - Step], [CX + Step, CY - Step], [CX - Step, CY + Step], [CX + Step, CY + Step])
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
                value /= cells;

            return value;
        }

        private void DoDiamond(int cx, int cy, int step, decimal spread)
        {
            if (_grid.CellExists(cx, cy - step))
            {
                _grid[cx, cy - step].Content = GetAverageDiamond(cx, cy - step, step) + GetNextDecimal(spread);
            }
            if (_grid.CellExists(cx - step, cy))
            {
                _grid[cx - step, cy].Content = GetAverageDiamond(cx - step, cy, step) + GetNextDecimal(spread);
            }
            if (_grid.CellExists(cx, cy + step))
            {
                _grid[cx, cy + step].Content = GetAverageDiamond(cx, cy + step, step) + GetNextDecimal(spread);
            }
            if (_grid.CellExists(cx + step, cy))
            {
                _grid[cx + step, cy].Content = GetAverageDiamond(cx + step, cy, step) + GetNextDecimal(spread);
            }
        }

        private decimal GetAverageDiamond(int cx, int cy, int step)
        {
            //AVG([CX, CY - Step], [CX + Step, CY], [CX, CY + Step], [CX - Step, CY])
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
                value /= cells;

            return value;
        }
    }
}
