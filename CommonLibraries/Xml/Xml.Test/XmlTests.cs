using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using TRW.CommonLibraries.Xml;


namespace TRW.CommonLibraries.Xml.Test
{
    [TestClass]
    public class XmlTests : UnitTesting.UnitTestBase
    {
        [TestMethod]
        public void XmlParserTest()
        {
            string firstFile = CreateTestXmlFile("first", "firstFile.xml");
            string secondFile = CreateTestXmlFile("first", "secondFile.xml");
            string thirdFile = CreateTestXmlFile("second", "thirdFile.xml");

            XmlParser firstParser = new XmlParser();
            firstParser.LoadXml(firstFile);
            XmlParser secondParser = new XmlParser();
            secondParser.LoadXml(secondFile);
            XmlParser thirdParser = new XmlParser();
            thirdParser.LoadXml(thirdFile);

            // first file should be identical to second file
            Assert.AreEqual(0, firstParser.RootElement.CompareTo(secondParser.RootElement));
            // third file should be different
            Assert.AreNotEqual(0, firstParser.RootElement.CompareTo(thirdParser.RootElement));

        }

        [TestMethod]
        public void XmlBuilderTest()
        {
            string newXmlFilePath = System.IO.Path.Combine(UnitTestTempFolder, "test.xml");
            using (XmlBuilder builder = new XmlBuilder(newXmlFilePath))
            {
                builder.OpenElement("TestRoot");
                builder.AddAttribute("Test", true);
                builder.AddAttribute("Runs", 1);
                builder.AddAttribute("TestValue", "Test");
                builder.OpenElement("TestElement");
                builder.AddAttribute("IsTest", true);
                builder.WriteString("ElementValue");
                builder.FinalizeDocument();
            }
            Assert.IsTrue(System.IO.File.Exists(newXmlFilePath), "File not created");
            using (XmlParser parser = new XmlParser(newXmlFilePath))
            {
                Assert.AreEqual("TestRoot", parser.RootElement.Name);
                XmlDocumentElement root = parser.RootElement;
                Assert.IsTrue(root.HasAttribute("Test"));
                Assert.AreEqual(true, Convert.ToBoolean((object)root.Attributes["Test"].Value));
                Assert.IsTrue(root.HasAttribute("Runs"));
                Assert.AreEqual(1, Convert.ToInt32((object)root.Attributes["Runs"].Value));
                Assert.IsTrue(root.HasAttribute("TestValue"));
                Assert.AreEqual("Test", root.Attributes["TestValue"].Value);
            }
        }

        [TestMethod]
        public void XmlElementEnumeratorTest()
        {
            string firstFile = CreateTestXmlFile("seekme", "firstFile.xml");
            XmlParser parser = new XmlParser(firstFile);
            Assert.IsTrue(parser.RootElement.SeekElement("seekme"));
        }
        [TestMethod]
        public void XmlElementEnumeratorAttributeTest()
        {
            string file = CreateTestXmlFile("seekme", "file.xml");
            XmlParser parser = new XmlParser(file);
            Assert.IsTrue(parser.RootElement.SeekElement("seekme"));
            XmlDocumentElement sought = parser.RootElement.CurrentChild;
            Assert.IsTrue(sought.HasAttribute("ChildAttribute"));
            Assert.AreEqual("Child", sought.GetAttributeString("ChildAttribute"));
        }

        private string CreateTestXmlFile(string childElementName, string fileName)
        {
            string newXmlFilePath = System.IO.Path.Combine(UnitTestTempFolder, fileName);
            using (XmlWriter writer = XmlWriter.Create(newXmlFilePath))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("RootNode");
                writer.WriteStartElement(childElementName);
                writer.WriteAttributeString("ChildAttribute", "Child");
                writer.WriteString("ElementText");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            return newXmlFilePath;
        }
    }
}
