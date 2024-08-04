using System;
using System.Xml;

namespace TRW.CommonLibraries.Xml
{
    /// <summary>
    /// Class to display and manipulate xml attribute nodes
    /// </summary>
    public class XmlElementAttribute : IComparable, IEquatable<XmlElementAttribute>
    {
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="attribute"></param>
        public XmlElementAttribute(XmlAttribute attribute)
        {
            _attribute = attribute;
            Name = attribute.Name;
            Value = attribute.Value;
        }

        public XmlElementAttribute(string attributeName, string attributeValue)
        {
            _attribute = null;
            Name = attributeName;
            Value = attributeValue;
        }

        private readonly XmlAttribute _attribute;

        public string Name { get; }
        public string Value { get; }

        public T GetEnumFromValue<T>() where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException(string.Format("Type [{0}] is not an Enum", typeof(T)));

            string cleanValue = this.Value.Replace(' ', '_').Replace("'", "");

            if (!Enum.TryParse<T>(cleanValue, true, out T enumValue))
                enumValue = default(T);

            return enumValue;
        }

        public override string ToString()
        {
            return string.Format("{0}=\"{1}\"", Name, Value);
        }

        public int CompareTo(object obj)
        {
            if (!(obj is XmlElementAttribute))
                throw new ArgumentException(string.Format("Unable to compare object type {0} to XmlElementAttribute", obj.GetType()));

            int compare = 0;
            XmlElementAttribute other = obj as XmlElementAttribute;
            if (this.Name != other.Name)
            {
                compare = this.Name.CompareTo(other.Name);
            }
            else if (this.Value != other.Value)
            {
                if(other.Value != "*" && this.Value != "*")
                    compare = this.Value.CompareTo(other.Value);
            }

            return compare;
        }

        public bool Equals(XmlElementAttribute other)
        {
            return (this.CompareTo(other)) == 0;
        }
    }

}
