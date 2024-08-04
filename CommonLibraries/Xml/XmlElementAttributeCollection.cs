using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Xml
{
    public class XmlElementAttributeCollection:ICollection<XmlElementAttribute>
    {
        private List<XmlElementAttribute> _attributes;

        public XmlElementAttributeCollection()
        {
            _attributes = new List<XmlElementAttribute>();
        }

        public int Count => ((ICollection<XmlElementAttribute>)_attributes).Count;

        public bool IsReadOnly => ((ICollection<XmlElementAttribute>)_attributes).IsReadOnly;

        public XmlElementAttribute this[string name]
        {
            get
            {
                if (_attributes.Contains(new XmlElementAttribute(name, "*")))
                    return _attributes[_attributes.IndexOf(new XmlElementAttribute(name, "*"))];
                else
                    return null;
            }
        }

        public XmlElementAttribute this[int index] => _attributes[index];

        public void Add(XmlElementAttribute item)
        {
            ((ICollection<XmlElementAttribute>)_attributes).Add(item);
        }

        public void Clear()
        {
            ((ICollection<XmlElementAttribute>)_attributes).Clear();
        }

        public bool Contains(XmlElementAttribute item)
        {
            return ((ICollection<XmlElementAttribute>)_attributes).Contains(item);
        }

        public bool Contains(string name)
        {
            return ((ICollection<XmlElementAttribute>)_attributes).Contains(new XmlElementAttribute(name, "*"));
        }

        public void CopyTo(XmlElementAttribute[] array, int arrayIndex)
        {
            ((ICollection<XmlElementAttribute>)_attributes).CopyTo(array, arrayIndex);
        }

        public IEnumerator<XmlElementAttribute> GetEnumerator()
        {
            return ((ICollection<XmlElementAttribute>)_attributes).GetEnumerator();
        }

        public bool Remove(XmlElementAttribute item)
        {
            return ((ICollection<XmlElementAttribute>)_attributes).Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<XmlElementAttribute>)_attributes).GetEnumerator();
        }
    }
}
