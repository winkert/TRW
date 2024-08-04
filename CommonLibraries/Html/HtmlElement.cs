using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TRW.CommonLibraries.Html
{
    public class HtmlElement : IEnumerable<HtmlElement>, ICloneable
    {
        public const string OpenTagRegex = @"(?<tag><(?<tagname>!?[\w]{1,})(?<tagattributes>[\w\s="":;?%#&{}\-+().,\/\\]{0,})(\/)?>)";
        public const string OpenTagVariableRegex = @"(?<tag><(#TAGNAME)(?<tagattributes>[\w\s="":;?%#&{}\-+().,\/\\]{0,})(\/)?>)";
        public const string CloseTagRegex = @"(?<tag><((\/)(#TAGNAME)|(#TAGNAME)(?<tagattributes>[\w\s="":;?%#&{}\-+().,\/\\]{0,})(?<selfclose>\/))>)";

        private int _index = 0;
        internal HtmlElement()
        {

        }
        public HtmlElement(string html, HtmlOpenTag open, HtmlCloseTag close)
        {
            Elements = new Dictionary<int, HtmlElement>();
            Tag = open.Tag;
            Attributes = open.Attributes;
            IsBodyTag = open.Tag.Equals("body", System.StringComparison.InvariantCultureIgnoreCase);

            if (open.Index == close.Index)
            {
                // self close
                IsSelfClosing = true;
                Content = string.Empty;
            }
            else
            {
                Content = html.Substring(open.Index + open.Length, (close.Index - open.Index) - open.Length);
            }
            OpenTag = open;
            CloseTag = close;
        }

        public bool IsBodyTag { get; private set; }
        public bool HasTag => !string.IsNullOrEmpty(Tag);
        public bool IsSelfClosing { get; private set; }
        public bool HasClosing { get; private set; }
        public string Tag { get; private set; }
        public string Attributes { get; private set; }
        public string Content { get; private set; }
        internal protected HtmlOpenTag OpenTag { get; private set; }
        internal protected HtmlCloseTag CloseTag { get; private set; }
        /// <summary>
        /// Get : Get indexed HTML Element
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        internal HtmlElement this[int index]
        {
            get
            {
                if (index < _index)
                    return Elements[index];
                else
                    return null;
            }
        }
        public IEnumerable<HtmlElement> this[string name]
        {
            get 
            {
                for(int i = 0; i> _index;i++)
                {
                    if (Elements[i].Tag.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                        yield return Elements[i];
                }
            }
        }
        public Dictionary<int, HtmlElement> Elements { get; private set; }
        public int Add(HtmlElement element)
        {
            Elements.Add(_index, element);
            return _index++;
        }
        internal List<HtmlElement> ToList()
        {
            List<HtmlElement> list = new List<HtmlElement>();
            foreach (KeyValuePair<int, HtmlElement> kvp in Elements)
            {
                list.Add(kvp.Value);
            }
            return list;
        }
        public override string ToString()
        {
            return $"{this.Tag} {this.Attributes}";
        }

        public IEnumerator<HtmlElement> GetEnumerator()
        {
            foreach (KeyValuePair<int, HtmlElement> kvp in Elements)
                yield return kvp.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (KeyValuePair<int, HtmlElement> kvp in Elements)
                yield return kvp.Value;
        }

        public object Clone()
        {
            HtmlElement element = new HtmlElement();
            element.Attributes = this.Attributes;
            element.Content = this.Content;
            element.Tag = this.Tag;
            element.IsBodyTag = this.IsBodyTag;
            element.HasClosing = this.HasClosing;
            element.IsSelfClosing = this.IsSelfClosing;
            element.OpenTag = this.OpenTag.Clone() as HtmlOpenTag;
            element.CloseTag = this.CloseTag.Clone() as HtmlCloseTag;
            element.Elements = new Dictionary<int, HtmlElement>();
            foreach (HtmlElement el in this)
                element.Add(el.Clone() as HtmlElement);

            return element;
        }
    }
}
