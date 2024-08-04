using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TRW.CommonLibraries.Xml
{

    /// <summary>
    /// Class to display and manipulate xml element nodes
    /// </summary>
    public class XmlDocumentElement : IComparable, IEquatable<XmlDocumentElement>
    {
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="element"></param>
        public XmlDocumentElement(XmlElement element)
        {
            _element = element;
            Name = element.Name;
            Value = GetValueFromElement(element);
            Attributes = new XmlElementAttributeCollection();
            Children = new XmlDocumentElementCollection();
            ParseElementInternal(element);
            _enumerator = new XmlDocumentElementEnumerator(this);
        }

        public XmlDocumentElement(string elementName, string elementValue)
        {
            _element = null;
            Name = elementName;
            Value = elementValue;
            Attributes = new XmlElementAttributeCollection();
            Children = new XmlDocumentElementCollection();
            _enumerator = new XmlDocumentElementEnumerator(this);
        }

        private readonly XmlElement _element;
        private XmlDocumentElementEnumerator _enumerator;

        public XmlElementAttributeCollection Attributes { get; }
        public XmlDocumentElementCollection Children { get; }
        public string Name { get; }
        public string Value { get; }
        public XmlDocumentElement CurrentChild => _enumerator.Current;

        public IEnumerator<XmlDocumentElement> GetEnumerator()
        {
            return _enumerator;
        }

        public bool SeekElement(string elementName)
        {
            return _enumerator.SeekElement(elementName);
        }

        public bool HasChild(string childName)
        {
            return Children.Contains(new XmlDocumentElement(childName, "*"));
        }

        public bool HasAttribute(string attributeName)
        {
            return Attributes.Contains(attributeName);
        }

        public string GetAttributeString(string attributeName)
        {
            if (Attributes.Contains(attributeName))
                return Attributes[attributeName].Value;
            else
                return string.Empty;
        }

        public int GetAttributeInt(string attributeName)
        {
            object attributeVal = GetAttributeString(attributeName);
            return Convert.ToInt32(attributeVal);
        }

        public T GetEnumFromAttributeValue<T>(string attributeName) where T:struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException(string.Format("Type [{0}] is not an Enum", typeof(T)));

            string value = GetAttributeString(attributeName);
            string cleanValue = value.Replace(' ', '_').Replace("'", "");

            if (!Enum.TryParse<T>(cleanValue, true, out T enumValue))
                enumValue = default(T);

            return enumValue;
        }

        public string GetAttributesAsString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (XmlElementAttribute attribute in Attributes)
            {
                builder.AppendFormat(" {0}", attribute.ToString());
            }
            return builder.ToString();
        }

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
            return string.Format("<{0}{1}>{2}</{0}>", Name, GetAttributesAsString(), Value);
        }

        public int CompareTo(object obj)
        {
            if (!(obj is XmlDocumentElement))
                throw new ArgumentException(string.Format("Unable to compare object type {0} to XmlDocumentElement", obj.GetType()));

            int compare = 0;
            XmlDocumentElement other = obj as XmlDocumentElement;
            if (this.Name != other.Name)
            {
                compare = this.Name.CompareTo(other.Name);
            }
            else if (this.Value != other.Value)
            {
                // allow * match on just element name
                if (other.Value != "*" && this.Value != "*")
                    compare = this.Value.CompareTo(other.Value);
            }
            else
            {
                if (this.Attributes.Count == other.Attributes.Count
                    && this.Children.Count == other.Children.Count)
                {
                    // attributes and children count match up so we need to do a compare
                    for (int a = 0; a < this.Attributes.Count; a++)
                    {
                        if (this.Attributes[a].CompareTo(other.Attributes[a]) != 0)
                        {
                            compare = this.Attributes[a].CompareTo(other.Attributes[a]);
                            break;
                        }
                    }
                    // this is going to be a bit recursive, but we want a good compare rather than a simplified ToString() compare
                    for (int c = 0; c < this.Children.Count; c++)
                    {
                        if (this.Children[c].CompareTo(other.Children[c]) != 0)
                        {
                            compare = this.Children[c].CompareTo(other.Children[c]);
                            break;
                        }
                    }
                }
                else
                {
                    // one of the counts is different...so we can return a compare of whichever is different first
                    if (this.Attributes.Count != other.Attributes.Count)
                    {
                        compare = this.Attributes.Count.CompareTo(other.Attributes.Count);
                    }
                    else if (this.Children.Count != other.Children.Count)
                    {
                        compare = this.Children.Count.CompareTo(other.Children.Count);
                    }
                }
            }

            return compare;
        }

        public bool Equals(XmlDocumentElement other)
        {
            return (this.CompareTo(other)) == 0;
        }

        private string GetValueFromElement(XmlElement element)
        {
            string value = string.Empty;
            if (string.IsNullOrEmpty(element.Value))
            {
                if (element.HasChildNodes)
                {
                    var nodes = element.ChildNodes.OfType<XmlNode>().Where(e => e.NodeType == XmlNodeType.Text);
                    if (nodes.Count() == 1)
                        value = nodes.First().Value;
                }
            }
            else
                value = element.Value;

            return value;
        }

        private void ParseElementInternal(XmlElement element)
        {
            foreach (XmlNode child in element)
            {
                if (child.NodeType == XmlNodeType.Element)
                    Children.Add(new XmlDocumentElement((XmlElement)child));
            }
            foreach (XmlAttribute attribute in element.Attributes)
            {
                Attributes.Add(new XmlElementAttribute((XmlAttribute)attribute));
            }
        }
    }
}
