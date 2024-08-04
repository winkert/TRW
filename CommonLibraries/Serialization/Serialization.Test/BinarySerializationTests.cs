using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TRW.UnitTesting;

namespace TRW.CommonLibraries.Serialization.Test
{
    [TestClass]
    public class BinarySerializationTests : UnitTestBase
    {
        [TestMethod]
        public void SerializeToStringTest()
        {
            TestClass target = new TestClass();
            target.AvailableString = "Test";
            string targetString = BinarySerializationRoutines.SerializeToString(target);

            TestClass copy = BinarySerializationRoutines.DeserializeFromString<TestClass>(targetString);

            Assert.AreEqual(target.AvailableString, copy.AvailableString);

            Assert.AreEqual(copy, target);
        }

        [TestMethod]
        public void SerializeObjectTest()
        {
            TestClass target = new TestClass();
            target.AvailableString = "Test";
            string targetPath = System.IO.Path.Combine(UnitTestTempFolder, "testClass.bin");
            BinarySerializationRoutines.SerializeToFile(target, targetPath);
            Assert.IsTrue(System.IO.File.Exists(targetPath));

            TestClass copy = BinarySerializationRoutines.DeserializeFromFile<TestClass>(targetPath);

            Assert.AreEqual(target.AvailableString, copy.AvailableString);

            Assert.AreEqual(copy, target);
        }

        [TestMethod]
        public void SerializeListTest()
        {
            List<TestClass> targets = new List<TestClass>();
            for(int i = 0; i < 100; i++)
            {
                targets.Add(new TestClass() { AvailableString = string.Format("String{0}", i) });
            }

            string targetPath = System.IO.Path.Combine(UnitTestTempFolder, "testClass.bin");
            BinarySerializationRoutines.SerializeListToFile(targets, targetPath);
            Assert.IsTrue(System.IO.File.Exists(targetPath));

            List<TestClass> copies = BinarySerializationRoutines.DeserializeListFromFile<TestClass>(targetPath);
            int index = 0;
            foreach (TestClass target in targets)
            {
                TestClass copy = copies[index++];
                Assert.AreEqual(target.AvailableString, copy.AvailableString);
                Assert.AreEqual(copy, target);
            }
        }

        [TestMethod]
        public void SerializeWithCompressionTest()
        {
            TestClass target = new TestClass();
            target.AvailableString = "Test";
            string targetPath = System.IO.Path.Combine(UnitTestTempFolder, "testClass.bin");
            BinarySerializationRoutines.SerializeToFile(target, targetPath, System.IO.FileMode.Create, true);
            Assert.IsTrue(System.IO.File.Exists(targetPath));

            TestClass copy = BinarySerializationRoutines.DeserializeFromFile<TestClass>(targetPath, true);

            Assert.AreEqual(target.AvailableString, copy.AvailableString);

            Assert.AreEqual(copy, target);
        }

        [TestMethod]
        public void SerializeCompressionCompressesTest()
        {
            List<TestClass> targets = new List<TestClass>();
            for (int i = 0; i < 100; i++)
            {
                targets.Add(new TestClass() { AvailableString = string.Format("String{0}", i) });
            }

            System.IO.FileInfo uncompressed = new System.IO.FileInfo(System.IO.Path.Combine(UnitTestTempFolder, "uncompressed.bin"));
            System.IO.FileInfo compressed = new System.IO.FileInfo(System.IO.Path.Combine(UnitTestTempFolder, "compressed.bin"));

            BinarySerializationRoutines.SerializeListToFile(targets, compressed.FullName, System.IO.FileMode.Create, true);
            BinarySerializationRoutines.SerializeListToFile(targets, uncompressed.FullName, System.IO.FileMode.Create, false);

            Assert.AreNotEqual(uncompressed.Length, compressed.Length);
            Assert.IsTrue(uncompressed.Length > compressed.Length);
        }
    }
}
