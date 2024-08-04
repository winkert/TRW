using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Serialization.Test
{
    [TestClass]
    public class DataChunkTest:UnitTesting.UnitTestBase
    {
        [TestMethod]
        public void TestStringToBytes()
        {
            var wave = DataChunk.StringToBytes("WAVE");
            var buffered = DataChunk.StringToBytes("fmt", 4);
            var unbuffered = DataChunk.StringToBytes("fmt");

            Assert.AreNotEqual(buffered, unbuffered);

            Assert.AreEqual(4, wave.Length);
            Assert.AreEqual(87, wave[0]);
            Assert.AreEqual(65, wave[1]);
            Assert.AreEqual(86, wave[2]);
            Assert.AreEqual(69, wave[3]);

            Assert.AreEqual(102, buffered[0]);
            Assert.AreEqual(109, buffered[1]);
            Assert.AreEqual(116, buffered[2]);
            Assert.AreEqual(0, buffered[3]);
        }

        [TestMethod]
        public void TestDataChunkConver()
        {
            DataChunk target = new DataChunk();
            target.Bytes = new byte[] { 65 }; //A
            Assert.AreEqual("A", target.ToString());

            int i = 3200;

            target.Bytes = BitConverter.GetBytes(i);
            Assert.AreEqual(i, target.ToInt());
        }

    }
}
