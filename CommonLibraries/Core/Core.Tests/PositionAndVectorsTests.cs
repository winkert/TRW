using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Core.Tests
{
    [TestClass]
    public class PositionAndVectorsTests : TRW.UnitTesting.UnitTestBase
    {
        [TestMethod]
        public void PositionOperatorsTests()
        {
            Position a = new Position(0, 0);
            Position b = new Position(0, 1);

            Assert.IsFalse(a == b);
            Assert.IsTrue(a != b);

            Assert.IsTrue(b > a);
            Assert.IsFalse(a > b);
            Assert.IsTrue(a < b);
            Assert.IsFalse(b < a);

            var adb = a - b;
            Assert.AreEqual(0, adb.Dx);
            Assert.AreEqual(-1, adb.Dy);
            Assert.AreEqual(a, b + adb);
            Assert.AreEqual(b, a - adb);

            var bda = b - a;
            Assert.AreEqual(0, bda.Dx);
            Assert.AreEqual(1, bda.Dy);
            Assert.AreEqual(a, b - bda);
            Assert.AreEqual(b, a + bda);


        }

        [TestMethod]
        public void PositionBetweenTests()
        {
            Position p0 = new Position(0, 0);
            Position x = new Position(1, 1);
            Position a = new Position(-1, 1);
            Position b = new Position(2, 1);

            Assert.IsTrue(x.Between(a, b));
            Assert.IsTrue(x.Between(b, a));
            Assert.IsTrue(p0.Between(a, b));
            Assert.IsTrue(p0.Between(b, a));
            Assert.IsTrue(p0.Between(a, x));
            Assert.IsTrue(p0.Between(x, a));

            a.UpdatePosition(-1, 3);
            b.UpdatePosition(2, -1);

            Assert.IsTrue(x.Between(a, b));
            Assert.IsTrue(x.Between(b, a));
            Assert.IsTrue(p0.Between(a, b));
            Assert.IsTrue(p0.Between(b, a));
            Assert.IsTrue(p0.Between(a, x));
            Assert.IsTrue(p0.Between(x, a));

            x.UpdatePosition(-1, 2);

            Assert.IsTrue(x.Between(a, b));
            Assert.IsTrue(x.Between(b, a));
            Assert.IsFalse(p0.Between(a, x));
            Assert.IsFalse(p0.Between(x, a));

            b.UpdatePosition(-3, 2);

            Assert.IsTrue(x.Between(a, b));
            Assert.IsTrue(x.Between(b, a));
            Assert.IsFalse(p0.Between(a, b));
            Assert.IsFalse(p0.Between(b, a));
            Assert.IsFalse(p0.Between(a, x));
            Assert.IsFalse(p0.Between(x, a));
        }

        [TestMethod]
        public void PositionWithinTests()
        {
            Position p0 = new Position(0, 0);
            Position x = new Position(1, 1);
            Position onLine = new Position(2, 1);
            Position outside = new Position(3, 1);
            Position[] plots = new Position[]
            {
                Position.Create(2, 2),
                Position.Create(2, -2),
                Position.Create(-2, -2),
                Position.Create(-2, 2)
            };

            Assert.IsTrue(Position.Within(p0, plots, false));
            Assert.IsTrue(Position.Within(x, plots, false));
            Assert.IsFalse(Position.Within(onLine, plots, false));
            Assert.IsTrue(Position.Within(onLine, plots, true));
            Assert.IsFalse(Position.Within(outside, plots, true));
        }

        [TestMethod]
        public void TestGetLine()
        {
            RunPositionGetLineTest(10, 20, 0, 22);
            RunPositionGetLineTest(-3, 12, 3, 12);
            RunPositionGetLineTest(0, 15, 0, 22);
            RunPositionGetLineTest(10, 20, 10, -3);

            RunPositionGetLineTest(-11, 6, -15, -16);
            RunPositionGetLineTest(-15, 6, -11, -16);
            RunPositionGetLineTest(-11, -16, -15, 6);
            RunPositionGetLineTest(-15, -16, -11, 6);

            Random r = new Random();
            for(int i = 0; i < 100; i++)
                RunPositionGetLineTest(r.Next(-20, 20), r.Next(-20, 20), r.Next(-20,20), r.Next(-20,20));
        }

        private void RunPositionGetLineTest(int aX, int aY, int bX, int bY)
        {
            Position a = new Position(aX, aY);
            Position b = new Position(bX, bY);

            var target = Position.GetLine(a, b);

            int maxX = aX > bX ? aX : bX;
            int minX = aX < bX ? aX : bX;
            int maxY = aY > bY ? aY : bY;
            int minY = aY < bY ? aY : bY;

            foreach (Position p in target)
            {
                AssertPositionOnLine(p, maxX, minX, maxY, minY);
            }
        }

        private void AssertPositionOnLine(Position p, int xMax, int xMin, int yMax, int yMin)
        {
            Assert.IsTrue(p.X <= xMax, $"Position [{p}] does not appear to be on expected line: xMax [{xMax}] xMin [{xMin}] yMax [{yMax}] yMin [{yMin}]");
            Assert.IsTrue(p.X >= xMin, $"Position [{p}] does not appear to be on expected line: xMax [{xMax}] xMin [{xMin}] yMax [{yMax}] yMin [{yMin}]");
            Assert.IsTrue(p.Y <= yMax, $"Position [{p}] does not appear to be on expected line: xMax [{xMax}] xMin [{xMin}] yMax [{yMax}] yMin [{yMin}]");
            Assert.IsTrue(p.Y >= yMin, $"Position [{p}] does not appear to be on expected line: xMax [{xMax}] xMin [{xMin}] yMax [{yMax}] yMin [{yMin}]");
        }
    }
}
