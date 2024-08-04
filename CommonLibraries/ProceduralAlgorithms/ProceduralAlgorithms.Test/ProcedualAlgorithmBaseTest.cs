using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            PrivateObject dsPO = new PrivateObject(ds, new PrivateType(typeof(ProceduralAlgorithms.ProceduralAlgorithmBase<RectangularCollection<Cell>, Cell>)));
            bool paramsValid = Convert.ToBoolean(dsPO.Invoke("ValidParameters", 1, 1, 1, 1.0m));
            Assert.IsTrue(paramsValid, "DiamondSquareAlgorithm failed");
            paramsValid = Convert.ToBoolean(dsPO.Invoke("ValidParameters", false));
            Assert.IsFalse(paramsValid, "DiamondSquareAlgorithm failed");
            paramsValid = Convert.ToBoolean(dsPO.Invoke("ValidParameters", 1, 1, true, true));
            Assert.IsFalse(paramsValid, "DiamondSquareAlgorithm failed");

            ProceduralAlgorithms.RandomWalkAlgorithm<RectangularCollection<Cell>, Cell> rw = new ProceduralAlgorithms.RandomWalkAlgorithm<RectangularCollection<Cell>, Cell>(this, map, 5, 5);
            PrivateObject rwPO = new PrivateObject(rw, new PrivateType(typeof(ProceduralAlgorithms.ProceduralAlgorithmBase<RectangularCollection<Cell>, Cell>)));
            paramsValid = Convert.ToBoolean(rwPO.Invoke("ValidParameters", new TRW.CommonLibraries.Core.Position(1, 1), 1, false, false));
            Assert.IsTrue(paramsValid, "RandomWalkAlgorithm failed");
            paramsValid = Convert.ToBoolean(rwPO.Invoke("ValidParameters", false));
            Assert.IsFalse(paramsValid, "RandomWalkAlgorithm failed");
            paramsValid = Convert.ToBoolean(rwPO.Invoke("ValidParameters", 1, new TRW.CommonLibraries.Core.Position(1, 1), false));
            Assert.IsFalse(paramsValid, "RandomWalkAlgorithm failed");

            ProceduralAlgorithms.CellularAutomataAlgorithm< RectangularCollection<Cell>, Cell> ca = new ProceduralAlgorithms.CellularAutomataAlgorithm<RectangularCollection<Cell>, Cell>(this, map, 5, 5);
            PrivateObject caPO = new PrivateObject(ca, new PrivateType(typeof(ProceduralAlgorithms.ProceduralAlgorithmBase<RectangularCollection<Cell>, Cell>)));
            paramsValid = Convert.ToBoolean(caPO.Invoke("ValidParameters", new CellularAutomataRulesSet<bool>(), 1, true, false));
            Assert.IsTrue(paramsValid, "CellularAutomataAlgorithm failed");
            paramsValid = Convert.ToBoolean(caPO.Invoke("ValidParameters", false));
            Assert.IsFalse(paramsValid, "CellularAutomataAlgorithm failed");
            paramsValid = Convert.ToBoolean(caPO.Invoke("ValidParameters", true, false, 1, new CellularAutomataRulesSet<bool>()));
            Assert.IsFalse(paramsValid, "CellularAutomataAlgorithm failed");

            ProceduralAlgorithms.PerlinNoiseAlgorithm<RectangularCollection<Cell>, Cell> pn = new ProceduralAlgorithms.PerlinNoiseAlgorithm<RectangularCollection<Cell>, Cell>(this, map, 5, 5);
            PrivateObject pnPO = new PrivateObject(pn, new PrivateType(typeof(ProceduralAlgorithms.ProceduralAlgorithmBase<RectangularCollection<Cell>, Cell>)));
            paramsValid = Convert.ToBoolean(pnPO.Invoke("ValidParameters", 16, 0.5m, 8m, 128m));
            Assert.IsTrue(paramsValid, "PerlinNoiseAlgorithm failed");
            paramsValid = Convert.ToBoolean(pnPO.Invoke("ValidParameters", false));
            Assert.IsFalse(paramsValid, "PerlinNoiseAlgorithm failed");
            paramsValid = Convert.ToBoolean(pnPO.Invoke("ValidParameters", true, false, 1, new CellularAutomataRulesSet<bool>()));
            Assert.IsFalse(paramsValid, "PerlinNoiseAlgorithm failed");
        }

        [TestMethod]
        public void DoAlgorithmTests()
        {
            RectangularCollection<Cell> map = new RectangularCollection<Cell>(5, 5);
            map.Fill();
            ProceduralAlgorithms.DiamondSquareAlgorithm<RectangularCollection<Cell>, Cell> ds = new ProceduralAlgorithms.DiamondSquareAlgorithm<RectangularCollection<Cell>, Cell>(this, map, 5, 5);
            ds.DoAlgorithm(1, 1, 1, 1.0m);
            
            ProceduralAlgorithms.RandomWalkAlgorithm<RectangularCollection<Cell>, Cell> rw = new ProceduralAlgorithms.RandomWalkAlgorithm<RectangularCollection<Cell>, Cell>(this, map, 5, 5);
            rw.DoAlgorithm(new TRW.CommonLibraries.Core.Position(1, 1), 1, false, false);

            ProceduralAlgorithms.CellularAutomataAlgorithm<RectangularCollection<Cell>, Cell> ca = new ProceduralAlgorithms.CellularAutomataAlgorithm<RectangularCollection<Cell>, Cell>(this, map, 5, 5);
            ca.DoAlgorithm(new CellularAutomataRulesSet<bool>(), 1, true, false);

            ProceduralAlgorithms.PerlinNoiseAlgorithm<RectangularCollection<Cell>, Cell> pn = new PerlinNoiseAlgorithm<RectangularCollection<Cell>, Cell>(this, map, 5, 5);
            pn.DoAlgorithm(2, .5m, 8m, 128m);

        }
    }
}
