using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TRW.CommonLibraries.Html
{
    public partial class HtmlParser : IDisposable
    {
        public const string OpenTagRegex = @"(?<tag><(?<tagname>!?[\w]{1,})(?<tagattributes>[\w\s="":;?%#&{}\-+().,\/\\]{0,})?>)";
        public const string OpenTagVariableRegex = @"(?<tag><(#TAGNAME)(?<tagattributes>[\w\s="":;?%#&{}\-+().,\/\\]{0,})(\/)?>)";
        public const string CloseTagRegex = @"(?<tag><((\/)(#TAGNAME)|(#TAGNAME)(?<tagattributes>[\w\s="":;?%#&{}\-+().,\/\\]{0,})(?<selfclose>\/))>)";

        private HtmlDoc _doc;

        public HtmlParser(string html)
        {
            _doc = ParseHtmlDocument(html);
        }

        public HtmlParser()
        {

        }

        public HtmlElement HtmlRoot { get; private set; }

        public HtmlElement Head { get; private set; }

        public HtmlElement Body { get; private set; }

        #region IDisposable
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _doc = null;
                }


                disposedValue = true;
            }
        }

        ~HtmlParser()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion
        /// <summary>
        /// Parses an HTML string and returns a HtmlDoc
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public HtmlDoc ParseHtmlDocument(string html)
        {
            // go through the string bit by bit and find start tags
            Dictionary<int, HtmlOpenTag> openTags = new Dictionary<int, HtmlOpenTag>();
            Dictionary<int, HtmlElement> elements = new Dictionary<int, HtmlElement>();
            HashSet<HtmlCloseTag> closedTags = new HashSet<HtmlCloseTag>();
            FindOpenTags(html, openTags, closedTags);

            BuildElementsFromOpenTags(html, openTags, elements, closedTags);

            // safety check
            if (elements.Count != openTags.Count)
            {

                throw new Exception($"Tag mismatch! Found {openTags.Count} open tags but only {elements.Count} Html Elements");
            }

            ArrangeElements(elements);

            _doc = new HtmlDoc(HtmlRoot, Head, Body);

            return _doc.Clone() as HtmlDoc; // return a clone so that when this parser is disposed, we don't lose it
        }

        private void FindOpenTags(string html, Dictionary<int, HtmlOpenTag> openTags, HashSet<HtmlCloseTag> closedTags)
        {
            int index = 0;
            Regex open = new Regex(OpenTagRegex);
            MatchCollection opens = open.Matches(html);
            foreach (Match openMatch in opens)
            {
                HtmlOpenTag openTag = new HtmlOpenTag();
                // get all open tags and make a dictionary with index
                openTag.Tag = openMatch.Groups["tagname"].Value;
                openTag.Attributes = openMatch.Groups["tagattributes"].Value.Trim();
                openTag.Index = openMatch.Index;
                openTag.Length = openMatch.Length;

                if (openTag.Attributes.EndsWith("/"))
                {
                    openTag.Attributes = openTag.Attributes.Trim('/');
                    openTag.IsSelfClosing = true;
                    closedTags.Add(new HtmlCloseTag(openTag));
                }
                else if (openTag.Tag.Equals("!doctype", StringComparison.InvariantCultureIgnoreCase))
                {
                    openTag.IsSelfClosing = true;
                    closedTags.Add(new HtmlCloseTag(openTag));
                }
                else if (openTag.Tag.Equals("link", StringComparison.InvariantCultureIgnoreCase)
                        || openTag.Tag.Equals("meta", StringComparison.InvariantCultureIgnoreCase))
                {
                    // kind of hate these special cases but HTML standards are not what they used to be
                    openTag.IsSelfClosing = true;
                    closedTags.Add(new HtmlCloseTag(openTag));
                }
                openTags.Add(index++, openTag);
            }
        }

        private void BuildElementsFromOpenTags(string html, Dictionary<int, HtmlOpenTag> openTags, Dictionary<int, HtmlElement> elements, HashSet<HtmlCloseTag> closedTags)
        {
            for (int i = openTags.Count - 1; i >= 0; i--)
            {
                if (openTags[i].IsSelfClosing)
                {
                    elements.Add(i, new HtmlElement(html, openTags[i], new HtmlCloseTag(openTags[i])));
                    continue;
                }

                string tagName = openTags[i].Tag;
                int elementStartIndex = openTags[i].Index;
                string closeTagRegex = CloseTagRegex.Replace("#TAGNAME", tagName);
                Regex close = new Regex(closeTagRegex);
                MatchCollection closeMatches = close.Matches(html.Substring(elementStartIndex));
                if (closeMatches.Count == 0)
                {
                    //probably self closing
                    openTags[i].IsSelfClosing = true;
                    elements.Add(i, new HtmlElement(html, openTags[i], new HtmlCloseTag(openTags[i])));
                    continue;
                }

                foreach (Match closeMatch in closeMatches)
                {
                    // Need to know if we are looking at the right tag
                    // generally speaking, the first one you encounter is going to be the one
                    // however, you need to know if the closing tag has already been claimed by another open
                    int closeTagLength = closeMatch.Length;
                    int closeTagIndex = elementStartIndex + closeMatch.Index;
                    HtmlCloseTag closeTag = new HtmlCloseTag(tagName, closeTagIndex, closeTagLength);
                    if (!closedTags.Add(closeTag))
                        continue;
                    try
                    {
                        HtmlElement el = new HtmlElement(html, openTags[i], closeTag);
                        elements.Add(i, el);
                        break;
                    }
                    catch (System.ArgumentOutOfRangeException argEx)
                    {
                        throw new System.Exception($"ArgumentOutOfRangeException \n" +
                            $"i = {i}\n" +
                            $"html.Substring({openTags[i].Index} + {openTags[i].Length}, {closeMatch.Index} - {openTags[i].Index} + {openTags[i].Length}; \n" +
                            $"openMatch.Index: {openTags[i].Index} openMatch.Length: {openTags[i].Length}\n" +
                            $"closeMatch.Index: {closeMatch.Index} closeMatch.Length: {closeMatch.Length}\n" +
                            $"elementStartIndex: {elementStartIndex}\n" +
                            $"IsSelfClosing: {openTags[i].IsSelfClosing}\n" +
                            $"html.Length: {html.Length}\n" +
                            $"tagName: {tagName}\n" +
                            $"Full Inbound HTML: {html}\n"
                            , argEx);
                    }
                    catch (System.ArgumentException argEx)
                    {
                        throw new System.Exception($"ArgumentException \n" +
                            $"i = {i} elements.Count {elements.Count}\n" +
                            $"openMatch.Index: {openTags[i].Index} openMatch.Length: {openTags[i].Length}\n" +
                            $"closeMatch.Index: {closeMatch.Index} closeMatch.Length: {closeMatch.Length}\n" +
                            $"elementStartIndex: {elementStartIndex}\n" +
                            $"hasClosing: {openTags[i].IsSelfClosing}\n" +
                            $"tagName: {tagName}\n"
                            , argEx);
                    }
                }

                if (!elements.ContainsKey(i))
                {
                    // need to do some checks to make sure this isn't some acceptable (but idiosyncratic) instance
                    string openTagVal = openTags[i].Tag.ToLowerInvariant();
                    switch(openTagVal)
                    {
                        case "input":
                        case "hr":
                        case "br":
                            openTags[i].IsSelfClosing = true;
                            elements.Add(i, new HtmlElement(html, openTags[i], new HtmlCloseTag(openTags[i])));
                            break;
                        default:
                            throw new Exception($"Key {i} was not added to the elements list. Tag {openTagVal} full tag: {html.Substring(openTags[i].Index, openTags[i].Length)}");
                    }
                    
                }
            
            }
        }

        private void ArrangeElements(Dictionary<int, HtmlElement> elements)
        {
            HtmlElement currentParent = null;
            for (int i = 0; i < elements.Count; i++)
            {
                if (currentParent == null)
                    currentParent = elements[i];

                if (currentParent.IsSelfClosing)
                {
                    currentParent = null;
                    continue;
                }

                if (elements[i].Tag.Equals("html", StringComparison.InvariantCultureIgnoreCase))
                    HtmlRoot = elements[i];
                if (elements[i].Tag.Equals("head", StringComparison.InvariantCultureIgnoreCase))
                {
                    Head = elements[i];
                    // add the head tags in a way that Head becomes the default parent
                    AddElementsToRoot(Head, currentParent, elements, ref i);
                }
                if (elements[i].IsBodyTag)
                {
                    Body = elements[i];
                    // add to body tags in a way that the Body becomes the default parent
                    AddElementsToRoot(Body, currentParent, elements, ref i);
                }
            }
        }

        private void AddElementsToRoot(HtmlElement rootElement, HtmlElement currentParent, Dictionary<int, HtmlElement> elements, ref int i)
        {
            for (; i < elements.Count; i++)
            {
                if (elements[i].OpenTag > rootElement.CloseTag)
                    break;

                if (elements[i].OpenTag > currentParent.OpenTag
                        && elements[i].CloseTag < currentParent.CloseTag)
                {
                    currentParent.Add(elements[i]);
                    // if the next element is within the bounds of the current element, make current element the current parent
                    // make safe for i + 1 with length etc
                    if (i + 1 < elements.Count)
                    {
                        if (elements[i + 1].OpenTag > elements[i].OpenTag
                            && elements[i + 1].CloseTag < elements[i].CloseTag)
                        {
                            currentParent = elements[i];
                        }
                    }
                }
                else
                {
                    currentParent = elements[i];
                    rootElement.Add(elements[i]);
                }
            }
        }


    }
}
