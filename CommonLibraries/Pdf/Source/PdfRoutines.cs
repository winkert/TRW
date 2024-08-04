using System;
using PdfSharpCore.Pdf;
using Font = PdfSharpCore.Drawing.XFont;

namespace TRW.CommonLibraries.Pdf
{
    public static class PdfRoutines
    {
        public static Font HeaderTNR = new Font("Times New Roman", 16, PdfSharpCore.Drawing.XFontStyle.Bold);
        public static Font BodyTNR = new Font("Times New Roman", 12);

        public static Font GetBodyFont(PdfSharpCore.Drawing.XFontStyle style)
        {
            return new Font("Times New Roman", 12, style);
        }

        /// <summary>
        /// Split out set pages from a Pdf in to a new Pdf
        /// </summary>
        /// <param name="inFile"></param>
        /// <param name="outFile"></param>
        /// <param name="startPage"></param>
        /// <param name="endPage"></param>
        public static void SplitPdf(string inFile, string outFile, int startPage, int endPage)
        {
            if (endPage < startPage)
                throw new ArgumentException("End Page is not after Start Page!", "endPage"); ;

            PdfDocument document = new PdfDocument(inFile);
            PdfDocument newDocument = new PdfDocument();

            // safety check; I choose to allow this rather than blow up in this case
            if (endPage >= document.Pages.Count)
                endPage = document.Pages.Count - 1;

            for (int i = 0; i < startPage - endPage; i++)
            {
                // copy page from document to new document
                PdfPage page = document.Pages[i];
                newDocument.AddPage(page);
            }
            newDocument.Save(outFile);
        }

        /// <summary>
        /// Save the PdfDocument as a file at the specified location
        /// </summary>
        /// <param name="document"></param>
        /// <param name="outFile"></param>
        public static void FinalizePdf(PdfDocument document, string outFile)
        {
            document.Save(outFile);
        }

        /// <summary>
        /// Create a PdfDocument
        /// </summary>
        /// <returns></returns>
        public static PdfDocument InitializePdf()
        {
            PdfDocument document = new PdfDocument();

            return document;
        }

    }
}
