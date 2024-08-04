using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TRW.GameLibraries.Maps.Test
{
    [TestClass]
    public class MapComponentsTest : TRW.UnitTesting.UnitTestBase
    {
        [TestMethod, Ignore]
        public void IntersectsAndContainsTest()
        {
            Map map = new Map(20, 20);
            Room room1 = new Room(map, CommonLibraries.Core.Position.Create(0, 0), 4, 2);
            Room room2 = new Room(map, CommonLibraries.Core.Position.Create(1, -1), 2, 2);

            Assert.IsTrue(room1.Intersects(room2));

            Room room3 = new Room(map, CommonLibraries.Core.Position.Create(-2, 1), 2, 2);
            Assert.IsTrue(room1.Intersects(room3), "Room1 should intersect Room3");
            Assert.IsTrue(room3.Intersects(room2), "Room3 should touch Room2 which is treated as intersecting"); // they touch but don't cross
            Assert.IsFalse(room3.Intersects(room2, true), "Room3 should touch Room2 which is not treated as intersecting when ignoring adjecent"); // they touch but don't cross

            Room room4 = new Room(map, CommonLibraries.Core.Position.Create(0, 0), 8, 8);
            Assert.IsFalse(room4.Intersects(room1), "Room4 should not intersect Room1");
            Assert.IsFalse(room4.Intersects(room2), "Room4 should not intersect Room2");
            Assert.IsFalse(room4.Intersects(room3), "Room4 should not intersect Room3");

            Assert.IsTrue(room4.Contains(room1), "Room4 should contain Room1");
            Assert.IsTrue(room4.Contains(room2), "Room4 should contain Room2");
            Assert.IsTrue(room4.Contains(room3), "Room4 should contain Room3");

            Assert.IsFalse(room1.Contains(room2), "Room1 should not contain Room2");
            Assert.IsFalse(room1.Contains(room3), "Room1 should not contain Room3");
            Assert.IsFalse(room1.Contains(room4), "Room1 should not contain Room4");

            Assert.IsFalse(room2.Contains(room1), "Room2 should not contain Room1");
            Assert.IsFalse(room2.Contains(room3), "Room2 should not contain Room3");
            Assert.IsFalse(room2.Contains(room4), "Room2 should not contain Room4");

            Assert.IsFalse(room3.Contains(room1), "Room3 should not contain Room1");
            Assert.IsFalse(room3.Contains(room2), "Room3 should not contain Room2");
            Assert.IsFalse(room3.Contains(room4), "Room3 should not contain Room4");
        }
    }
}
