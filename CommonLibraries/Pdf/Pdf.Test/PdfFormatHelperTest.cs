using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;

namespace TRW.CommonLibraries.Pdf.Test
{
    [TestClass]
    public class PdfFormatHelperTest
    {
        const string loremipsum = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nec tincidunt praesent semper feugiat nibh sed pulvinar. Et malesuada fames ac turpis egestas integer eget aliquet nibh. Eget nunc lobortis mattis aliquam faucibus purus in massa. Ut tellus elementum sagittis vitae et. Dolor sit amet consectetur adipiscing elit duis tristique.
Senectus et netus et malesuada fames ac turpis. Non pulvinar neque laoreet suspendisse interdum consectetur libero. Amet consectetur adipiscing elit ut. Sed vulputate mi sit amet mauris. Sed vulputate mi sit amet mauris. Eget duis at tellus at urna condimentum mattis pellentesque id. Fermentum odio eu feugiat pretium. Tortor dignissim convallis aenean et tortor at.";

        const string segmented = "This is the first sentence of the string. This is the second sentence of the string. This is the third sentence of the string - around here we may reach the end of the page width.\r\nThis is a new line after a line break.";

        [TestMethod]
        public void TestWordWrap()
        {
            XFont font = new XFont("Times New Roman", 12);
            PdfDocument doc = new PdfDocument();
            using(PdfLayoutHelper helper = new PdfLayoutHelper(doc))
            {
                helper.WriteString("Test String", font, helper.LeftMargin);
                helper.NextLine(font);
                helper.WriteString(segmented, font, helper.LeftMargin);
                helper.NextLine(font);
                helper.WriteString(loremipsum, font, helper.LeftMargin);
            }

            string expectedFile = Path.Combine(Environment.CurrentDirectory, "test.pdf");
            doc.Save(expectedFile);

            FileInfo file = new FileInfo(expectedFile);
            Assert.IsTrue(file.Exists);
            Assert.AreEqual(35516, file.Length);

            File.Delete(expectedFile);
        }
    }
}