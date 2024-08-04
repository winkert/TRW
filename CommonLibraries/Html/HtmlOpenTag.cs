using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Html
{
    public class HtmlOpenTag : HtmlTagBase
    {
        public HtmlOpenTag()
            :base()
        {

        }

        public HtmlOpenTag(string tag, int index, int length) : base(tag, index, length)
        {

        }

        public string Attributes { get; set; }
        public bool IsSelfClosing { get; set; }

        public override object Clone()
        {
            HtmlOpenTag clone = new HtmlOpenTag(this.Tag, this.Index, this.Length)
            { Attributes = this.Attributes, IsSelfClosing = this.IsSelfClosing };

            return clone;
        }
    }
}
