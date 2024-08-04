using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TRW.CommonLibraries.Html.Test
{
    [TestClass]
    public class HtmlTest:TRW.UnitTesting.UnitTestBase
    {
        private static string _testHtml;
        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _testHtml = System.IO.File.ReadAllText(MoveFileToCurrentWorkingDirectory("HTMLPage1.html"));
        }


        [TestMethod]
        public void TestParser()
        {
            using (Html.HtmlParser parser = new HtmlParser())
            {
                HtmlDoc doc = parser.ParseHtmlDocument(_testHtml);

                Assert.IsNotNull(doc.HtmlRoot);
                Assert.IsNotNull(doc.Head);
                Assert.IsNotNull(doc.Body);

                int metaInHead = 0;
                int metaInBody = 0;

                foreach (HtmlElement el in doc.FindElements("meta", ".*", HtmlTagSearchScope.HeadOnly))
                {
                    Assert.AreEqual("meta", el.Tag);
                    metaInHead++;
                }

                foreach (HtmlElement el in doc.FindElements("meta", ".*", HtmlTagSearchScope.BodyOnly))
                {
                    Assert.AreEqual("meta", el.Tag);
                    metaInBody++;
                }

                Assert.AreEqual(6, metaInHead);
                Assert.AreEqual(0, metaInBody);

                int scriptInHead = 0;
                int scriptInBody = 0;
                int scriptInAll = 0;

                foreach (HtmlElement el in doc.FindElements("script", ".*", HtmlTagSearchScope.All))
                {
                    Assert.AreEqual("script", el.Tag);
                    scriptInAll++;
                }

                foreach (HtmlElement el in doc.FindElements("script", ".*", HtmlTagSearchScope.HeadOnly))
                {
                    Assert.AreEqual("script", el.Tag);
                    scriptInHead++;
                }

                foreach (HtmlElement el in doc.FindElements("script", ".*", HtmlTagSearchScope.BodyOnly))
                {
                    Assert.AreEqual("script", el.Tag);
                    scriptInBody++;
                }

                Assert.AreEqual(2, scriptInAll);
                Assert.AreEqual(1, scriptInHead);
                Assert.AreEqual(1, scriptInBody);

                List<string> divInBody = new List<string>();
                int pInBody = 0;

                foreach (HtmlElement el in doc.FindElements("div", ".*", HtmlTagSearchScope.BodyOnly))
                {
                    Assert.AreEqual("div", el.Tag);
                    divInBody.Add($"{el.Tag} {el.Attributes}");
                }

                Assert.AreEqual(6, divInBody.Count, string.Join(",", divInBody));

                foreach (HtmlElement el in doc.FindElements("p", ".*", HtmlTagSearchScope.BodyOnly))
                {
                    Assert.AreEqual("p", el.Tag);
                    pInBody++;
                }

                Assert.AreEqual(2, pInBody);
            }
        }

        [TestMethod]
        public void TestCloneHtmlDoc()
        {
            HtmlDoc clone = null;
            int elementsInHtmlRoot = 0;
            int elementsInHead = 0;
            int elementsInBody = 0;
            using (Html.HtmlParser parser = new HtmlParser())
            {
                HtmlDoc doc = parser.ParseHtmlDocument(_testHtml);
                elementsInHtmlRoot = doc.HtmlRoot.Elements.Count;
                elementsInHead = doc.Head.Elements.Count;
                elementsInBody = doc.Body.Elements.Count;
                
                
                clone = doc.Clone() as HtmlDoc;

            }

            Assert.IsNotNull(clone);
            Assert.AreEqual(elementsInHtmlRoot, clone.HtmlRoot.Elements.Count);
            Assert.AreEqual(elementsInHead, clone.Head.Elements.Count);
            Assert.AreEqual(elementsInBody, clone.Body.Elements.Count);



        }
    }
}
