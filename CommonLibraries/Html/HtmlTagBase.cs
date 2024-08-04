using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Html
{
    public abstract class HtmlTagBase:IComparable<HtmlTagBase>, ICloneable
    {

        public HtmlTagBase()
        {

        }

        public HtmlTagBase(string tag, int index, int length)
        {
            Tag = tag;
            Index = index;
            Length = length;
        }
        public string Tag { get; set; }
        public int Index { get; set; }
        public int Length { get; set; }

        public int CompareTo(HtmlTagBase other, bool compareTag)
        {
            if (compareTag)
            {
                if (!this.Tag.Equals(other.Tag))
                    return this.Tag.CompareTo(other.Tag);
            }

            if (!this.Index.Equals(other.Index))
                return this.Index.CompareTo(other.Index);

            if (!this.Length.Equals(other.Length))
                return this.Length.CompareTo(other.Length);

            return 0;
        }
        public int CompareTo(HtmlTagBase other)
        {
            return CompareTo(other, true);
        }

        public override bool Equals(object obj)
        {
            if (this.CompareTo((HtmlTagBase)obj) == 0)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return (Tag.GetHashCode()^Index.GetHashCode()^Length.GetHashCode());
        }

        public abstract object Clone();

        public static bool operator ==(HtmlTagBase left, HtmlTagBase right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(HtmlTagBase left, HtmlTagBase right)
        {
            return !(left == right);
        }

        public static bool operator <(HtmlTagBase left, HtmlTagBase right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right, false) < 0;
        }

        public static bool operator <=(HtmlTagBase left, HtmlTagBase right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right, false) <= 0;
        }

        public static bool operator >(HtmlTagBase left, HtmlTagBase right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right, false) > 0;
        }

        public static bool operator >=(HtmlTagBase left, HtmlTagBase right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right, false) >= 0;
        }
    }
}
