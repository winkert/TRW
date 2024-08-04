using System;
using System.Collections.Generic;
using System.Text;
using PdfSharpCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace TRW.CommonLibraries.Pdf
{
    public class PdfLayoutHelper : IDisposable
    {
        private bool disposedValue;

        internal static HashSet<char> PhraseBreaks = new HashSet<char>()
        {
            ' ',
            ','
        };

        internal static HashSet<char> LineBreaks = new HashSet<char>()
        {
            (char)10,
            (char)13
        };

        internal const char LineFeed = (char)10;
        internal const char CarriageReturn = (char)13;

        public bool WordWrap { get; set; } = true;
        public bool AvoidOrphans { get; set; }
        public bool AvoidWidows { get; set; }
        public XUnit TopMargin { get; private set; }
        public XUnit BottomMargin { get; private set; }
        public XUnit LeftMargin { get; private set; }
        public XUnit RightMargin { get; private set; }

        public XUnit CurrentLine { get; private set; }

        public XGraphics Gfx { get; private set; }
        public PdfPage Page { get; private set; }
        public PdfDocument Document { get; private set; }

        public PdfLayoutHelper(PdfDocument document)
            : this(document, XUnit.FromInch(1), XUnit.FromInch(7.5))
        {

        }

        public PdfLayoutHelper(PdfDocument document, XUnit topPosition, XUnit bottomMargin)
            : this(document, topPosition, bottomMargin, XUnit.FromInch(1))
        {

        }

        public PdfLayoutHelper(PdfDocument document, XUnit topPosition, XUnit bottomMargin, XUnit leftMargin)
        {
            Document = document;
            TopMargin = topPosition;
            BottomMargin = bottomMargin;
            CurrentLine = TopMargin;
            LeftMargin = leftMargin;
            if (document.Pages.Count == 0)
                CreatePage();
            else
                Page = document.Pages[0];
        }

        public XUnit NextLine(XFont font)
        {
            return NextLine(XUnit.FromPoint(font.Height));
        }

        public XUnit NextLine(XUnit requestedHeight)
        {
            return NextLine(requestedHeight, -1f);
        }

        public XUnit NextLine(XUnit requestedHeight, XUnit requiredHeight)
        {
            if (Page == null)
                CreatePage();

            XUnit required = requiredHeight == -1f ? requestedHeight : requiredHeight;
            if (WithinPageHeight(CurrentLine + required))
            {
                CurrentLine += requestedHeight;
            }
            else
            {
                CreatePage();
            }

            return CurrentLine;
        }

        public XUnit PeekNextLine(XFont font, out bool newPage)
        {
            return PeekNextLine(XUnit.FromPoint(font.Height), out newPage);
        }

        public XUnit PeekNextLine(XUnit requestedHeight, out bool newPage)
        {
            newPage = false;
            if (WithinPageHeight(CurrentLine + requestedHeight))
            {
                return CurrentLine + requestedHeight;
            }
            else
            {
                newPage = true;
                return TopMargin;
            }
        }

        public void CreatePage()
        {
            Page = Document.AddPage();
            Page.Size = PageSize.Letter;
            Gfx = XGraphics.FromPdfPage(Page);
            CurrentLine = TopMargin;
            RightMargin = Page.Width - LeftMargin;
        }

        public bool WillFitOnPage(string value, XFont font)
        {
            XSize sizeOfBlock = MeasureTextBlock(value, font);
            PeekNextLine(sizeOfBlock.Height, out bool newPage);
            return !newPage;
        }

        public bool WithinPageMargins(XUnit x, XUnit y)
        {
            return WithinPageWidth(x) && WithinPageHeight(y);
        }

        public bool WithinPageWidth(string value, XFont font, XUnit startPosition)
        {
            return WithinPageWidth(startPosition + MeasureString(value, font));
        }

        public bool WithinPageWidth(XUnit x)
        {
            return x <= RightMargin;
        }

        public bool WithinPageHeight(XUnit y)
        {
            return y <= BottomMargin;
        }

        public double MeasureString(string text, XFont font)
        {
            XSize size = Gfx.MeasureString(text, font);
            return size.Width;
        }

        /// <summary>
        /// Provides an estimate of the number of lines a block of text will require
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        public XSize MeasureTextBlock(string text, XFont font)
        {
            return MeasureTextBlock(text, font, LeftMargin - RightMargin);
        }

        public XSize MeasureTextBlock(string text, XFont font, XUnit printableWidth)
        {
            XSize size = Gfx.MeasureString(text, font);
            if (WithinPageWidth(size.Width))
                return size;

            // determine how many lines we need for this block of text
            XUnit rawWidth = size.Width;

            int linesRequired = (int)Math.Ceiling(rawWidth / printableWidth);

            // account for /r/n
            if (text.IndexOf(LineFeed) > -1 || text.IndexOf(CarriageReturn) > -1)
            {
                string[] lines = text.Split(new[] { LineFeed, CarriageReturn }, StringSplitOptions.RemoveEmptyEntries);
                linesRequired += lines.Length;
            }

            return new XSize(printableWidth, size.Height * linesRequired);
        }

        /// <summary>
        /// Draw a string on the Graphics at a fixed location and a fixed width of space on either side
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fixedWidth"></param>
        /// <param name="font"></param>
        /// <param name="brush"></param>
        /// <param name="yPosition"></param>
        /// <param name="xPosition"></param>
        /// <param name="alignment"></param>
        /// <returns>New X position</returns>
        public XUnit WriteFixedWidthString(string value, XUnit fixedWidth, XFont font, XBrush brush, XUnit xPosition, StringAlignments alignment)
        {
            return WriteFixedWidthString(value, fixedWidth, font, brush, xPosition, CurrentLine, alignment);
        }

        public XUnit WriteFixedWidthString(string value, XUnit fixedWidth, XFont font, XBrush brush, XUnit xPosition, XUnit yPosition, StringAlignments alignment)
        {
            // first things first: does the string fit within the fixed width?
            XUnit stringWidth = MeasureString(value, font);
            if (stringWidth > fixedWidth)
                fixedWidth = stringWidth;

            // word wrap fixed width differently
            if (WordWrap && !WithinPageWidth(xPosition + fixedWidth))
            {
                yPosition = NextLine(font);
                xPosition = LeftMargin;
            }

            switch (alignment)
            {
                case StringAlignments.Left:
                    WriteString(value, font, brush, xPosition, yPosition);
                    break;
                case StringAlignments.Center:
                    WriteString(value, font, brush, xPosition + (fixedWidth - stringWidth) / 2, yPosition);
                    break;
                case StringAlignments.Right:
                    WriteString(value, font, brush, xPosition + (fixedWidth - stringWidth), yPosition);
                    break;
            }

            return xPosition + fixedWidth;
        }

        public XUnit WriteString(string value, XFont font, XUnit xPosition)
        {
            return WriteString(value, font, XBrushes.Black, xPosition);
        }

        public XUnit WriteString(string value, XFont font, XBrush brush)
        {
            return WriteString(value, font, brush, LeftMargin);
        }

        public XUnit WriteString(string value, XFont font, XBrush brush, XUnit xPosition)
        {
            return WriteString(value, font, brush, xPosition, CurrentLine);
        }

        /// <summary>
        /// Write a string on to a pdf.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="font"></param>
        /// <param name="brush"></param>
        /// <param name="xPosition"></param>
        /// <param name="yPosition"></param>
        /// <returns>Resulting XPosition</returns>
        public XUnit WriteString(string value, XFont font, XBrush brush, XUnit xPosition, XUnit yPosition)
        {
            XUnit resultingPosition = xPosition + MeasureString(value, font);
            if (WordWrap)
            {
                if (WithinPageWidth(value, font, xPosition))
                {
                    InternalWriteString(value, font, brush, xPosition, yPosition);
                }
                else
                {
                    string valueForThisLine = string.Empty;
                    XUnit currentXPosition = xPosition;
                    int lastBreak = -1;
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (PhraseBreaks.Contains(value[i]) || LineBreaks.Contains(value[i]))
                        {
                            lastBreak = i;
                        }

                        if (WithinPageWidth(valueForThisLine + value[i], font, currentXPosition))
                        {
                            valueForThisLine += value[i];
                        }
                        else
                        {
                            valueForThisLine = valueForThisLine.Substring(0, valueForThisLine.Length - (i - lastBreak));
                            InternalWriteString(valueForThisLine, font, brush, currentXPosition, yPosition);
                            yPosition = NextLine(font);
                            currentXPosition = LeftMargin;
                            i = lastBreak;
                            valueForThisLine = string.Empty;
                        }
                    }

                    resultingPosition = currentXPosition + MeasureString(valueForThisLine, font);
                    if (valueForThisLine.Length > 0)
                    {
                        InternalWriteString(valueForThisLine, font, brush, currentXPosition, yPosition);
                    }
                }
            }
            else
            {
                InternalWriteString(value, font, brush, xPosition, CurrentLine);
            }

            return resultingPosition;
        }

        public void DrawLine()
        {
            DrawLine(LeftMargin, CurrentLine, RightMargin, CurrentLine);
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            DrawLine(new XPoint(x1, y1), new XPoint(x2, y2));
        }

        public void DrawLine(XPoint start, XPoint end)
        {
            DrawLine(XPens.Black, start, end);
        }

        public void DrawLine(XPen pen, XPoint start, XPoint end)
        {
            Gfx.DrawLine(pen, start, end);
        }

        public void DrawCurvedLine(XPen pen, XPoint start, XPoint end, double depth)
        {
            // get average Y position
            double midY = ((end.Y + start.Y) / 2) + depth;
            double increment = (end.X - start.X) / 3;
            XPoint mid1 = new XPoint(start.X + increment, midY);
            XPoint mid2 = new XPoint(start.X + increment * 2, midY);
            DrawCurvedLine(pen, start, mid1, mid2, end);
        }

        /// <summary>
        /// The math isn't quite right on this method.
        /// TODO: Figure out the geometry on this to draw a curve based on start, end, total points, and arc height
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="resolution">Number of defined points in the Arc</param>
        /// <param name="depth">Height of the Arc</param>
        public void DrawCurvedLine(XPen pen, XPoint start, XPoint end, int resolution, double depth)
        {
            // the increment is the ratio of the distance between the points and the total number of points needed
            int increment;
            if(end.X > start.X)
                increment = (int)(end.X - start.X) / resolution;
            else
                increment = (int)(start.X - end.X) / resolution;

            XPoint[] points = new XPoint[resolution];
            points[0] = start;
            points[resolution - 1] = end;
            for (int i = 1; i < resolution - 1; i++)
            {
                // SIN(X / (ArcWidth/PI) ) * ArcHeight
                double arcIncreas = (Math.Sin(i / (resolution / Math.PI)) * depth);
                double posY = start.Y + arcIncreas;
                
                points[i] = new XPoint(start.X + increment * i, posY);
            }
            DrawCurvedLine(pen, points);
        }

        public void DrawCurvedLine(XPen pen, params XPoint[] points)
        {
            Gfx.DrawCurve(pen, points);
        }

        private void InternalWriteString(string value, XFont font, XBrush brush, XUnit xPosition, XUnit yPosition)
        {
            if (value.IndexOf(LineFeed) > -1
                || value.IndexOf(CarriageReturn) > -1)
            {
                // we have a lfcr in the string to write
                string valueForThisLine = string.Empty;
                XUnit currentXPosition = xPosition;
                for (int i = 0; i < value.Length; i++)
                {
                    if (LineBreaks.Contains(value[i]))
                    {
                        if (LineBreaks.Contains(value[i + 1]))
                        {
                            i++; // skip the next char
                        }

                        Gfx.DrawString(valueForThisLine, font, brush, currentXPosition, yPosition);
                        yPosition = NextLine(font);
                        currentXPosition = LeftMargin;
                        valueForThisLine = string.Empty;
                    }
                    else
                    {
                        valueForThisLine += value[i];
                    }
                }

                if (valueForThisLine.Length > 0)
                {
                    Gfx.DrawString(valueForThisLine, font, brush, currentXPosition, yPosition);
                }
            }
            else
            {
                Gfx.DrawString(value, font, brush, xPosition, yPosition);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (Gfx != null)
                        Gfx.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~PdfLayoutHelper()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


        public enum StringAlignments
        {
            Left,
            Center,
            Right
        }
    }
}
