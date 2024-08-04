using System;
using System.Collections;
using System.Collections.Generic;

namespace TRW.CommonLibraries.Html
{

    public class HtmlDoc:ICloneable
    {
        internal HtmlDoc()
        { 

        }

        public HtmlDoc(HtmlElement root, HtmlElement head, HtmlElement body)
        {
            HtmlRoot = root;
            Head = head;
            Body = body;
        }

        public HtmlElement HtmlRoot { get; set; }

        public HtmlElement Head { get; set; }

        public HtmlElement Body { get; set; }


        public IEnumerable<HtmlElement> FindElements(string tag)
        {
            return FindElements(tag, ".*", HtmlTagSearchScope.All);
        }

        public IEnumerable<HtmlElement> FindElements(string tag, string contentPattern, HtmlTagSearchScope searchScope)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(contentPattern);
            List<HtmlElement> localSearchList = new List<HtmlElement>();
            switch (searchScope)
            {
                case HtmlTagSearchScope.All:
                    if (Head != null)
                        AddRangeRecursive(localSearchList, Head);
                    if (Body != null)
                        AddRangeRecursive(localSearchList, Body);
                    break;
                case HtmlTagSearchScope.BodyOnly:
                    if (Body != null)
                        AddRangeRecursive(localSearchList, Body);
                    else
                        throw new ArgumentException($"Unable to do BodyOnly search because Body is null! ");
                    break;
                case HtmlTagSearchScope.HeadOnly:
                    if (Head != null)
                        AddRangeRecursive(localSearchList, Head);
                    else
                        throw new ArgumentException($"Unable to do HeadOnly search because Head is null! ");
                    break;
            }

            for (int i = 0; i < localSearchList.Count; i++)
            {
                if (localSearchList[i].Tag.Equals(tag, StringComparison.InvariantCultureIgnoreCase)
                    && regex.IsMatch(localSearchList[i].Content))
                {
                    yield return localSearchList[i];
                }
            }
        }

        private void FindElements(List<HtmlElement> elements)
        {
            foreach (HtmlElement element in elements)
            {
                if (element.Tag.Equals("!doctype", StringComparison.InvariantCultureIgnoreCase))
                {
                    //_docType = element.Attributes;
                }
                if (element.Tag.Equals("html", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (this.HtmlRoot == null)
                    {
                        this.HtmlRoot = element;
                    }
                    else
                    {
                        throw new Exception("Found multiple HTML tags in HTML");
                    }
                }
                if (element.Tag.Equals("head", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (Head == null)
                    {
                        Head = element;
                    }
                    else
                    {
                        throw new Exception("Found multiple HEAD tags in HTML");
                    }
                }
                if (element.IsBodyTag)
                {
                    if (Body == null)
                    {
                        Body = element;
                    }
                    else
                    {
                        throw new Exception("Found multiple BODY tags in HTML");
                    }
                }

                if (Head == null || Body == null || HtmlRoot == null)
                    FindElements(element.ToList());
            }
        }

        internal void AddRangeRecursive(List<HtmlElement> localList, HtmlElement element)
        {
            localList.AddRange(element.ToList());
            foreach (HtmlElement el in element)
                AddRangeRecursive(localList, el);
        }

        public object Clone()
        {
            HtmlDoc doc = new HtmlDoc();
            doc.HtmlRoot = this.HtmlRoot.Clone() as HtmlElement;
            doc.Head = this.Head.Clone() as HtmlElement;
            doc.Body = this.Body.Clone() as HtmlElement;

            return doc;
        }
    }
}