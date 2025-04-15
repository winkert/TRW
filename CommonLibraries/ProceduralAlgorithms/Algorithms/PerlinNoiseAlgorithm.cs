using System;
using TRW.CommonLibraries.Core;

namespace TRW.CommonLibraries.ProceduralAlgorithms
{
    public class PerlinNoiseAlgorithm<M, C> : ProceduralAlgorithmBase<M, C> where C : ICell where M : IMatrix<C>
    {
        public PerlinNoiseAlgorithm(object sender, M grid, int xDim, int yDim) : base(sender, grid, xDim, yDim)
        {
        }

        private static ProceduralAlgorithmParameterCollection _parameters;
        public override ProceduralAlgorithmParameterCollection Parameters
        {
            get
            {
                if (_parameters == null)
                {
                    _parameters = new ProceduralAlgorithmParameterCollection(5)
                    {
                        new ProceduralAlgorithmParameter<int>(OctavesParamName),
                        new ProceduralAlgorithmParameter<decimal>(PersistenceParamName),
                        new ProceduralAlgorithmParameter<decimal>(FrequencyParamName),
                        new ProceduralAlgorithmParameter<decimal>(AmplitudeParamName),
                        new ProceduralAlgorithmParameter<bool>(UseComplexGridParamName)
                    };
                }
                return _parameters;
            }
        }

        internal int[] Permutations { get; set; }

        internal static decimal[][] GradientGrid { get; private set; }

        private static decimal[][] _gradientGridComplex;
        /// <summary>
        /// In Perlin noise, gradient vectors represent the direction of change at each grid point.
        /// </summary>
        internal static decimal[][] GradientGridComplex
        {
            get
            {
                if (_gradientGridComplex == null)
                {
                    _gradientGridComplex = new decimal[][] {
                        new decimal[] { 0, 1 },     // up
                        new decimal[] { 1, 0 },     // right
                        new decimal[] { -1, 0 },    // down
                        new decimal[] { 0, -1 },    // left
                        new decimal[] { 0.707106781m, 0.707106781m },       // diagonal intermediate vector
                        new decimal[] { 0.707106781m, -0.707106781m },      // diagonal intermediate vector
                        new decimal[] { -0.707106781m, 0.707106781m },      // diagonal intermediate vector
                        new decimal[] { -0.707106781m, -0.707106781m },      // diagonal intermediate vector
                        new decimal[] { 0.230219016m, 0.230219016m },       // diagonal intermediate vector
                        new decimal[] { 0.230219016m, -0.230219016m },      // diagonal intermediate vector
                        new decimal[] { -0.230219016m, 0.230219016m },      // diagonal intermediate vector
                        new decimal[] { -0.230219016m, -0.230219016m }      // diagonal intermediate vector
                    };
                }
                return _gradientGridComplex;
            }
        }

        private static decimal[][] _gradientGridSimple;
        internal static decimal[][] GradientGridSimple
        {
            get
            {
                if (_gradientGridSimple == null)
                {
                    _gradientGridSimple = new decimal[][] {
                        new decimal[] { 0, 1 },     // up
                        new decimal[] { 1, 0 },     // right
                        new decimal[] { -1, 0 },    // down
                        new decimal[] { 0, -1 }    // left
                    };
                }
                return _gradientGridSimple;
            }
        }

        /// <summary>
        /// The number of iterations to do - impacts smoothness
        /// </summary>
        internal int Octaves { get; set; }

        /// <summary>
        /// 0 to 1 value indicating how the slope changes between iterations (octaves)
        /// </summary>
        internal decimal Persistence { get; set; }
        /// <summary>
        /// The frequency determines how rapidly the noise oscillates or repeats.
        /// </summary>
        internal decimal Frequency { get; set; }
        /// <summary>
        /// The amplitude represents the strength or magnitude of the noise.
        /// </summary>
        internal decimal Amplitude { get; set; }

        protected override void DoAlgorithmInternal(params object[] args)
        {
            Octaves = Parameters.GetParameterValue<int>(args, OctavesParamName);
            Persistence = Parameters.GetParameterValue<decimal>(args, PersistenceParamName);
            Frequency = Parameters.GetParameterValue<decimal>(args, FrequencyParamName);
            Amplitude = Parameters.GetParameterValue<decimal>(args, AmplitudeParamName);

            bool useComplexGrid = Parameters.GetParameterValue<bool>(args, UseComplexGridParamName);
            if (useComplexGrid)
                GradientGrid = GradientGridComplex;
            else
                GradientGrid = GradientGridSimple;

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
                _grid.Current.Content = Math.Abs((int)(GetNoise(_grid.Current.Position.X, _grid.Current.Position.Y, Frequency, Amplitude) * 255m));
            } while (_grid.Next());
        }

        private decimal GetNoise(int x, int y, decimal frequency, decimal amplitude)
        {
            decimal pX = x / 100m;
            decimal pY = y / 100m;

            decimal total = 0;
            decimal maxAmplitude = 0;

            for (int i = 0; i < Octaves; i++)
            {
                total += InterpolateNoise(pX * frequency, pY * frequency) * amplitude;
                maxAmplitude += amplitude;
                amplitude *= Persistence;
                frequency *= 2;
            }

            return total / maxAmplitude;
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
