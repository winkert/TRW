using System;
using TRW.CommonLibraries.Core;

namespace TRW.CommonLibraries.ProceduralAlgorithms
{
    public class PerlinNoiseAlgorithm<M, C> : ProceduralAlgorithmBase<M, C> where C : ICell where M : IMatrix<C>
    {
        public PerlinNoiseAlgorithm(object sender, M grid, int xDim, int yDim) : base(sender, grid, xDim, yDim)
        {
        }

        public override int NumberOfParamters => 2;

        public override Type[] TypesOfParameters => new Type[] { typeof(int), typeof(decimal) };

        internal int[] Permutations { get; set; }
        internal readonly decimal[][] GradientGrid = new decimal[][] {
            new decimal[] { 0, 1 },
            new decimal[] { 1, 0 },
            new decimal[] { -1, 0 },
            new decimal[] { 0, -1 },
            new decimal[] { 0.707106781m, 0.707106781m },
            new decimal[] { 0.707106781m, -0.707106781m },
            new decimal[] { -0.707106781m, 0.707106781m },
            new decimal[] { -0.707106781m, -0.707106781m }
        };
        internal int Octaves { get; set; }
        internal decimal Persistence {  get; set; }

        protected override void DoAlgorithmInternal(params object[] args)
        {
            Octaves = Convert.ToInt32(args[0]);
            Persistence = Convert.ToDecimal(args[1]);

            // define the permutations at run time to use Random
            Permutations = new int[256];
            for (int i = 0; i < 256; i++)
            {
                Permutations[i] = R.Next(256);
            }

            GenerateNoise();
        }

        private void GenerateNoise()
        {
            // loop through entire _grid and apply noise
            // (follow pattern from CellularAutomata since this is the same idea)
            _grid.First();
            do
            {
                _grid.Current.Content = Math.Abs((int)(GetNoise(_grid.Current.Position) * 255m));
            } while (_grid.Next());
        }

        private decimal GetNoise(Position p)
        {
            decimal pX = p.X / 100m;
            decimal pY = p.Y / 100m;

            decimal total = 0;
            decimal frequency = 8;
            decimal amplitude = 128;
            decimal maxAmplitude = 0;

            for (int i = 0; i < Octaves; i++)
            {
                total += InterpolateNoise(pX * frequency, pY * frequency) * amplitude;
                maxAmplitude += amplitude;
                amplitude *= Persistence;
                frequency *= 2;
            }

            return total / maxAmplitude ;
        }

        private decimal InterpolateNoise(decimal x, decimal y)
        {
            int x0 = (int)Math.Floor(x);
            int x1 = x0 + 1;
            int y0 = (int)Math.Floor(y);
            int y1 = y0 + 1;

            decimal tx = x - x0;
            decimal ty = y - y0;

            decimal n0, n1, ix0, ix1, value;

            n0 = DotGridGradient(x0, y0, x, y);
            n1 = DotGridGradient(x1, y0, x, y);
            ix0 = Interpolate(n0, n1, tx);

            n0 = DotGridGradient(x0, y1, x, y);
            n1 = DotGridGradient(x1, y1, x, y);
            ix1 = Interpolate(n0, n1, tx);

            value = Interpolate(ix0, ix1, ty);
            return value;
        }

        private decimal DotGridGradient(int ix, int iy, decimal x, decimal y)
        {
            decimal dx = x - ix;
            decimal dy = y - iy;

            int index = Permutations[(ix + Permutations[iy & 255]) & 255];

            decimal[] gradient = GradientGrid[index % GradientGrid.Length];
            decimal dot = (dx * gradient[0]) + (dy * gradient[1]);

            return dot;
        }

        private decimal Interpolate(decimal a, decimal b, decimal x)
        {
            double ft = (double)x * Math.PI;
            decimal f = (decimal)((1 - Math.Cos(ft)) * 0.5);
            return a * (1 - f) + b * f;
        }
    }
}
