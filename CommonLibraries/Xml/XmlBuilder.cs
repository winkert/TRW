using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TRW.CommonLibraries.Xml
{
    /// <summary>
    /// 
    /// </summary>
    public class XmlBuilder : IDisposable
    {
        private XmlWriter _writer;
        private bool _initialized;
        private bool _finalized;

        private int _elementsOpen;

        private XmlWriterSettings _writerSettings;

        private XmlElement _currentElement;
        private XmlDocument _underlyingDoc;

        public XmlBuilder()
        {
            _initialized = false;
            _elementsOpen = 0;
            _writerSettings = new XmlWriterSettings()
            {
                Indent = true
            };
            _underlyingDoc = new XmlDocument();
        }

        public XmlBuilder(string filePath)
            :this()
        {
            this.InternalInitialize(filePath);
        }

        #region Public Methods
        #region Writing Methods
        public void WriteElement<T>(string elementName, T value)
        {
            WriteElement(elementName, value.ToString());
        }

        public void WriteElement(string elementName, string value, params Tuple<string, string>[] attributes)
        {
            OpenElement(elementName);

            if(attributes != null)
            {
                foreach(Tuple<string, string> attribute in attributes)
                {
                    AddAttribute(attribute.Item1, attribute.Item2);
                }
            }

            WriteString(value);

            CloseElement();
        }

        /// <summary>
        /// Add an attribute to an element tag.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="attributeName"></param>
        /// <param name="attributeValue"></param>
        public void AddAttribute<T>(string attributeName, T attributeValue)
        {
            // need to have a current element and the writer can't be in a state that would error
            if (_currentElement != null && _writer.WriteState == WriteState.Element)
            {
                _writer.WriteAttributeString(attributeName, attributeValue.ToString());
            }
            else
                throw new InvalidOperationException("Attributes can only be added to an open element. Use sequence: OpenElement() AddAttribute() WriteString() CloseElement()");
        }

        public void WriteString<T>(T value)
        {
            _writer.WriteString(value.ToString());
        }

        public void OpenElement(string elementName)
        {
            _elementsOpen++;
            _currentElement = _underlyingDoc.CreateElement(elementName);
            _writer.WriteStartElement(elementName);
        }

        public void CloseElement()
        {
            _elementsOpen--;
            _currentElement = null;
            _writer.WriteEndElement();
        }

        public void FinalizeDocument()
        {
            if (_writer.WriteState != WriteState.Error)
            {
                if (_elementsOpen > 0)
                {
                    for (int i = 0; i < _elementsOpen; i++)
                    {
                        CloseElement();
                    }
                }
                _writer.WriteEndDocument();
            }
            _finalized = true;
        }
        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

            if(disposing)
            {
                if (_writer != null)
                {
                    if (_initialized && !_finalized)
                        FinalizeDocument();

                    ((IDisposable)_writer).Dispose();
                    _currentElement = null;
                    _underlyingDoc = null;
                }
            }

        }

        ~XmlBuilder()
        {
            Dispose(false);
        }
        #endregion

        #region Private Methods
        private void InternalInitialize(string filePath)
        {
            _writer = XmlWriter.Create(filePath, _writerSettings);
            _writer.WriteStartDocument();
            _initialized = true;
        }

        #endregion
    }
}
