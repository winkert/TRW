using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Xml
{
    public class XmlDocumentElementCollection:ICollection<XmlDocumentElement>
    {
        private readonly List<XmlDocumentElement> _elements;

        public XmlDocumentElementCollection()
        {
            _elements = new List<XmlDocumentElement>();
        }

        public int Count => ((ICollection<XmlDocumentElement>)_elements).Count;

        public bool IsReadOnly => ((ICollection<XmlDocumentElement>)_elements).IsReadOnly;

        public XmlDocumentElement this[string name]
        {
            get
            {
                if (_elements.Contains(new XmlDocumentElement(name, "*")))
                    return _elements[_elements.IndexOf(new XmlDocumentElement(name, "*"))];
                else
                    return null;
            }
        }

        public XmlDocumentElement this[int index] => _elements[index];

        public void Add(XmlDocumentElement item)
        {
            ((ICollection<XmlDocumentElement>)_elements).Add(item);
        }

        public void Clear()
        {
            ((ICollection<XmlDocumentElement>)_elements).Clear();
        }

        public bool Contains(XmlDocumentElement item)
        {
            return ((ICollection<XmlDocumentElement>)_elements).Contains(item);
        }

        public bool Contains(string elementName)
        {
            return ((ICollection<XmlDocumentElement>)_elements).Contains(new XmlDocumentElement(elementName, "*"));
        }

        public void CopyTo(XmlDocumentElement[] array, int arrayIndex)
        {
            ((ICollection<XmlDocumentElement>)_elements).CopyTo(array, arrayIndex);
        }

        public IEnumerator<XmlDocumentElement> GetEnumerator()
        {
            return ((ICollection<XmlDocumentElement>)_elements).GetEnumerator();
        }

        public bool Remove(XmlDocumentElement item)
        {
            return ((ICollection<XmlDocumentElement>)_elements).Remove(item);
        }

        public int IndexOf(XmlDocumentElement item)
        {
            return _elements.IndexOf(item);
        }

        public int IndexOf(string elementName)
        {
            return this.IndexOf(new XmlDocumentElement(elementName, "*"));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<XmlDocumentElement>)_elements).GetEnumerator();
        }
    }
}
