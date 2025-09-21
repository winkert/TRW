using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TRW.CommonLibraries.Core;

namespace TRW.CommonLibraries.ProceduralAlgorithms.Test
{
    [TestClass]
    public class ProcedualAlgorithmBaseTest : UnitTesting.UnitTestBase
    {
        internal class Cell : ICell, IEquatable<Cell>
        {
            private object _content;
            private Position _position;

            public Cell() { _position = new Position(0, 0); }
            internal Cell(object content, int x, int y)
            {
                _content = content;
                _position = new Position(x, y);
            }

            public object Content { get => _content; set => _content = value; }

            public Position Position => _position;

            public bool OnNorthEdge => false;

            public bool OnEastEdge => false;

            public bool OnSouthEdge => false;

            public bool OnWestEdge => false;

            public ICell NorthNeighbor => new Cell();

            public ICell NorthEastNeighbor => new Cell();

            public ICell EastNeighbor => new Cell();

            public ICell SouthEastNeighbor => new Cell();

            public ICell SouthNeighbor => new Cell();

            public ICell SouthWestNeighbor => new Cell();

            public ICell WestNeighbor => new Cell();

            public ICell NorthWestNeighbor => new Cell();

            public bool Equals(Cell other)
            {
                return true;
            }

            public ICell GetNeighborByVector(Vector vector)
            {
                Position newPos = this.Position + vector;


                return null;
            }

            public int GetNeighborsByValue(object value)
            {
                return 1;
            }

            public int GetNeighborsWithValue()
            {
                int activeNeighbors = 0;
                if (NorthNeighbor != null && (NorthNeighbor).Content != null)
                    activeNeighbors++;
                if (NorthEastNeighbor != null && (NorthEastNeighbor).Content != null)
                    activeNeighbors++;
                if (EastNeighbor != null && (EastNeighbor).Content != null)
                    activeNeighbors++;
                if (SouthEastNeighbor != null && (SouthEastNeighbor).Content != null)
                    activeNeighbors++;
                if (SouthNeighbor != null && (SouthNeighbor).Content != null)
                    activeNeighbors++;
                if (SouthWestNeighbor != null && (SouthWestNeighbor).Content != null)
                    activeNeighbors++;
                if (WestNeighbor != null && (WestNeighbor).Content != null)
                    activeNeighbors++;
                if (NorthWestNeighbor != null && (NorthWestNeighbor).Content != null)
                    activeNeighbors++;

                return activeNeighbors;
            }
        }

        [TestMethod]
        public void ValidateParametersTests()
        {
            RectangularCollection<Cell> map = new RectangularCollection<Cell>(5, 5);
            ProceduralAlgorithms.DiamondSquareAlgorithm<RectangularCollection<Cell>, Cell> ds = new ProceduralAlgorithms.DiamondSquareAlgorithm<RectangularCollection<Cell>, Cell>(this, map, 5, 5);
            DoValidParametersTest(ds, [1, 1.0m], true);
            DoValidParametersTest(ds, [false], false);
            DoValidParametersTest(ds, [1, 1, true, true], false);

            ProceduralAlgorithms.RandomWalkAlgorithm<RectangularCollection<Cell>, Cell> rw = new ProceduralAlgorithms.RandomWalkAlgorithm<RectangularCollection<Cell>, Cell>(this, map, 5, 5);
            DoValidParametersTest(rw, [new TRW.CommonLibraries.Core.Position(1, 1), 1, false, false], true);
            DoValidParametersTest(rw, [false], false);
            DoValidParametersTest(rw, [1, new TRW.CommonLibraries.Core.Position(1, 1), false], false);

            ProceduralAlgorithms.CellularAutomataAlgorithm<RectangularCollection<Cell>, Cell> ca = new ProceduralAlgorithms.CellularAutomataAlgorithm<RectangularCollection<Cell>, Cell>(this, map, 5, 5);
            DoValidParametersTest(ca, [new CellularAutomataRulesSet<bool>(), 1, true, false], true);
            DoValidParametersTest(ca, [false], false);
            DoValidParametersTest(ca, [true, false, 1, new CellularAutomataRulesSet<bool>()], false);

            ProceduralAlgorithms.PerlinNoiseAlgorithm<RectangularCollection<Cell>, Cell> pn = new ProceduralAlgorithms.PerlinNoiseAlgorithm<RectangularCollection<Cell>, Cell>(this, map, 5, 5);
            DoValidParametersTest(pn, [16, 0.5m, 8m, 128m, false], true);
            DoValidParametersTest(pn, [false], false);
            DoValidParametersTest(pn, [1, 1, 1, 1, new CellularAutomataRulesSet<bool>()], false);
        }

        private void DoValidParametersTest(ProceduralAlgorithmBase<RectangularCollection<Cell>, Cell> alg, object[] args, bool expected)
        {
            System.Reflection.MethodInfo? method = alg.GetType().GetMethod("ValidParameters", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            Assert.IsNotNull(method);
            // I hear you like argument arrays so I put an argument array in your argument array
            bool paramsValid = Convert.ToBoolean(method.Invoke(alg, [args]));
            
            Assert.AreEqual(expected, paramsValid, $"{alg.GetType()} failed. Expected [{expected}] Actual [{paramsValid}]");
        }

        [TestMethod]
        public void DoAlgorithmTests()
        {
            RectangularCollection<Cell> map = new RectangularCollection<Cell>(5, 5);
            map.Fill();
            ProceduralAlgorithms.DiamondSquareAlgorithm<RectangularCollection<Cell>, Cell> ds = new ProceduralAlgorithms.DiamondSquareAlgorithm<RectangularCollection<Cell>, Cell>(this, map, 5, 5);
            ds.DoAlgorithm(1, 1.0m);

            ProceduralAlgorithms.RandomWalkAlgorithm<RectangularCollection<Cell>, Cell> rw = new ProceduralAlgorithms.RandomWalkAlgorithm<RectangularCollection<Cell>, Cell>(this, map, 5, 5);
            rw.DoAlgorithm(new TRW.CommonLibraries.Core.Position(1, 1), 1, false, false);

            ProceduralAlgorithms.CellularAutomataAlgorithm<RectangularCollection<Cell>, Cell> ca = new ProceduralAlgorithms.CellularAutomataAlgorithm<RectangularCollection<Cell>, Cell>(this, map, 5, 5);
            ca.DoAlgorithm(new CellularAutomataRulesSet<bool>(), 1, true, false);

            ProceduralAlgorithms.PerlinNoiseAlgorithm<RectangularCollection<Cell>, Cell> pn = new PerlinNoiseAlgorithm<RectangularCollection<Cell>, Cell>(this, map, 5, 5);
            pn.DoAlgorithm(2, .5m, 8m, 128m, false);

        }

        private class AlgorithmHelperClass : ProceduralAlgorithmBase<RectangularCollection<Cell>, Cell>
        {
            public AlgorithmHelperClass(object sender, RectangularCollection<Cell> grid, int xDim, int yDim) : base(sender, grid, xDim, yDim)
            {
            }
            public override ProceduralAlgorithmParameterCollection Parameters => new ProceduralAlgorithmParameterCollection(0);
            protected override void DoAlgorithmInternal(params object[] args)
            {
                // Do nothing
            }
            public bool TestValidParameters(params object[] args)
            {
                return ValidParameters(args);
            }
        }
    }
}

