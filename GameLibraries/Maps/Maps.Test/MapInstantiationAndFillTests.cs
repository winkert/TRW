using System;
using TRW.CommonLibraries.Core;

namespace TRW.GameLibraries.Maps.Test
{
    [TestClass]
    public class MapInstantiationAndFillTests
    {
        private const int MapSize = 50;

        [TestMethod]
        public void FillDiamondSquareTest()
        {
            Map map = new Map(MapSize);

            map.FillDiamondSquare(40, 0.5m);

            Assert.IsNotNull(map);
            Assert.AreEqual(MapSize, map.Dimensions.Item1);
            Assert.AreEqual(MapSize, map.Dimensions.Item2);

        }

        [TestMethod]
        public void FillRandomWalkTest()
        {
            Map map = new Map(MapSize);

            map.FillRandomWalk(40, false);

            Assert.IsNotNull(map);
            Assert.AreEqual(MapSize, map.Dimensions.Item1);
            Assert.AreEqual(MapSize, map.Dimensions.Item2);

        }

        [TestMethod]
        public void FillCellularAutomataTest()
        {
            Map map = new Map(MapSize);

            TRW.CommonLibraries.ProceduralAlgorithms.CellularAutomataRulesSet<bool> rules = new CommonLibraries.ProceduralAlgorithms.CellularAutomataRulesSet<bool>();
            rules.Add(2, false, true);
            rules.Add(1, true, false);
            rules.Add(4, true, false);

            map.FillCellAutomata(rules, 10);

            Assert.IsNotNull(map);
            Assert.AreEqual(MapSize, map.Dimensions.Item1);
            Assert.AreEqual(MapSize, map.Dimensions.Item2);

        }

        [TestMethod]
        public void DrawLinesTest()
        {
            Map map = new Map(50);

            map.FillMap(false);
            Position a = new Position(0, 0);
            Position b = new Position(10, 10);
            map.Grid.ConnectPoints(a, b, true);
            for (int i = 0; i < 11; i++)
            {
                Assert.IsTrue(map.Grid.Cells[i, i].BitState, $"{i},{i} not TRUE");
            }


            map.FillMap(false);
            a = new Position(3, 6);
            b = new Position(2, 12);
            map.Grid.ConnectPoints(a, b, true);
            Assert.IsTrue(map.Grid.Cells[3, 6].BitState, $"3,6 not TRUE. State of 3,5: {map.Grid.Cells[3, 5].BitState} 3,7: {map.Grid.Cells[3, 7].BitState}");
            Assert.IsTrue(map.Grid.Cells[2, 10].BitState, $"2,10 not TRUE. State of 2,9: {map.Grid.Cells[2, 9].BitState} 3,10: {map.Grid.Cells[3, 10].BitState}");
            Assert.IsTrue(map.Grid.Cells[2, 12].BitState, $"2,12 not TRUE. State of 2,11: {map.Grid.Cells[2, 11].BitState} 2,12: {map.Grid.Cells[3, 12].BitState}");


            map.FillMap(false);
            a = new Position(4, 10);
            b = new Position(20, 10);
            map.Grid.ConnectPoints(a, b, true);
            for (int i = 4; i <= 20; i++)
            {
                Assert.IsTrue(map.Grid.Cells[i, 10].BitState, $"{i},10 not TRUE");
            }

            map.FillMap(false);
            a = new Position(30, 30);
            b = new Position(20, 15);
            map.Grid.ConnectPoints(a, b, true);
            Assert.IsTrue(map.Grid.Cells[20, 15].BitState, $"20,15 not TRUE. State of 20,16: {map.Grid.Cells[20, 16].BitState} 20,14: {map.Grid.Cells[20, 14].BitState}");
            Assert.IsTrue(map.Grid.Cells[24, 21].BitState, $"24,21 not TRUE. State of 24,20: {map.Grid.Cells[24, 20].BitState} 25,22: {map.Grid.Cells[25, 22].BitState}");
            Assert.IsTrue(map.Grid.Cells[30, 30].BitState, $"30,30 not TRUE. State of 30,31: {map.Grid.Cells[30, 31].BitState} 30,29: {map.Grid.Cells[20, 29].BitState}");

            map.FillMap(false);
            a = new Position(25, 25);
            b = new Position(25, 10);
            map.Grid.ConnectPoints(a, b, true);
            for (int i = 10; i <= 25; i++)
            {
                Assert.IsTrue(map.Grid.Cells[25, i].BitState, $"25,{i} not TRUE");
            }

        }

        [TestMethod, Ignore]
        public void DrawShapesTest()
        {
            Map map = new Map(50);
            map.FillMap(false);
            map.AddSquare(25, 25, 10, true);
            Assert.IsTrue(map.Grid.Cells[20, 25].BitState, $"Expected TRUE on Cell 20,25; got FALSE");
            Assert.IsTrue(map.Grid.Cells[25, 20].BitState, $"Expected TRUE on Cell 25,20; got FALSE");
            Assert.IsTrue(map.Grid.Cells[30, 25].BitState, $"Expected TRUE on Cell 30,25; got FALSE");
            Assert.IsTrue(map.Grid.Cells[25, 30].BitState, $"Expected TRUE on Cell 25,30; got FALSE");

            // test how we handle out of bounds
            map.FillMap(false);
            map.AddSquare(10, 10, 25, true);
            Assert.IsTrue(map.Grid.Cells[0, 10].BitState, $"Expected TRUE on Cell 0,10; got FALSE");
            Assert.IsTrue(map.Grid.Cells[10, 0].BitState, $"Expected TRUE on Cell 10,0; got FALSE");
            Assert.IsTrue(map.Grid.Cells[22, 10].BitState, $"Expected TRUE on Cell 22,10; got FALSE");
            Assert.IsTrue(map.Grid.Cells[10, 22].BitState, $"Expected TRUE on Cell 10,22; got FALSE");

            map.AddSquare(40, 40, 25, true);
            Assert.IsTrue(map.Grid.Cells[28, 40].BitState, $"Expected TRUE on Cell 28,40; got FALSE");
            Assert.IsTrue(map.Grid.Cells[40, 28].BitState, $"Expected TRUE on Cell 40,28; got FALSE");
            Assert.IsTrue(map.Grid.Cells[28, 49].BitState, $"Expected TRUE on Cell 28,49; got FALSE");
            Assert.IsTrue(map.Grid.Cells[49, 28].BitState, $"Expected TRUE on Cell 49,28; got FALSE");

        }
    }
}