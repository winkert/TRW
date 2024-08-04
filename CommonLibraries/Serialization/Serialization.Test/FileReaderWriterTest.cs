using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Serialization.Test
{
    [TestClass]
    public class FileReaderWriterTest:UnitTesting.UnitTestBase
    {
        [TestMethod]
        public void TestFileWriterReadBackFile()
        {
            string targetPath = System.IO.Path.Combine(UnitTestTempFolder, "test.bin");

            using(FileWriter writer = new FileWriter(targetPath))
            {
                writer.WriteString("Test");
                writer.WriteChar(' ');
                writer.Write(87, 65, 86, 69);
                writer.Write(10);
                writer.WriteString("NewString");
                writer.Write(0);
                writer.WriteChars(new char[] { 'f', 'm', 't' }, 4);
            }

            Assert.IsTrue(System.IO.File.Exists(targetPath));

            using(FileReader reader = new FileReader(targetPath))
            {
                char c = reader.ReadNextChar();
                Assert.AreEqual('T', c);
                c = reader.ReadNextChar();
                Assert.AreEqual('e', c);
                c = reader.ReadNextChar();
                Assert.AreEqual('s', c);
                c = reader.ReadNextChar();
                Assert.AreEqual('t', c);
                c = reader.ReadNextChar();
                Assert.AreEqual(' ', c);
                Assert.AreEqual("WAVE", reader.ReadNextString());
                Assert.AreEqual(10, reader.ReadNext());
                Assert.AreEqual("NewString", reader.ReadNextString());
                Assert.AreEqual((byte)0, reader.ReadNext());
                byte[] bytes = reader.ReadNext(4);
                Assert.AreEqual(102, bytes[0]);
                Assert.AreEqual(109, bytes[1]);
                Assert.AreEqual(116, bytes[2]);
                Assert.AreEqual(0, bytes[3]);
            }
        }
    }
}
