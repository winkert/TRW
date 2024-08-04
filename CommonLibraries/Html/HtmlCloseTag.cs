using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Html
{
    public class HtmlCloseTag : HtmlTagBase
    {
        /// <summary>
        /// For Self closing tags
        /// </summary>
        /// <param name="openTag"></param>
        public HtmlCloseTag(HtmlOpenTag openTag)
            : base(openTag.Tag, openTag.Index, openTag.Length)
        { }

        public HtmlCloseTag(string tag, int index, int length) : base(tag, index, length)
        {
        }

        public override object Clone()
        {
            HtmlCloseTag clone = new HtmlCloseTag(this.Tag, this.Index, this.Length);
            return clone;
        }
    }
}
