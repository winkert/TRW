using System;
using System.Collections;
using System.Collections.Generic;

namespace TRW.CommonLibraries.Xml
{

    /// <summary>
    /// Enumerator for XmlDocumentElement objects
    /// This enumerator will return the element and all child elements (and all grand child, etc) in an ordered way
    /// </summary>
    internal class XmlDocumentElementEnumerator : IEnumerator<XmlDocumentElement>
    {
        private XmlDocumentElementCollection _elements;
        private int _index;

        internal XmlDocumentElementEnumerator(XmlDocumentElement element)
        {
            _elements = new XmlDocumentElementCollection();

            AddChildElements(element);
        }

        public XmlDocumentElement Current
        {
            get
            {
                return _elements[_index];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return _elements[_index];
            }
        }

        public bool SeekElement(string elementName)
        {
            if (_elements.Contains(elementName))
            {
                _index = _elements.IndexOf(elementName);
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                if (_elements != null)
                {
                    _elements.Clear();
                    _elements = null;
                }
            }
        }

        ~XmlDocumentElementEnumerator()
        {
            Dispose(false);
        }

        public bool MoveNext()
        {
            if (_index + 1 < _elements.Count)
                _index++;
            else
                return false;
            return true;
        }

        public void Reset()
        {
            _index = 0;
        }

        /// <summary>
        /// Recursive function to add the current element and all child elements in order
        /// </summary>
        /// <param name="element"></param>
        private void AddChildElements(XmlDocumentElement element)
        {
            _elements.Add(element);
            foreach (XmlDocumentElement child in element.Children)
            {
                AddChildElements(child);
            }
        }


    }
}

