using System;
using System.Xml;

namespace TRW.CommonLibraries.Xml
{
    /// <summary>
    /// Container object for XmlDocument to facilitate easy access to elements and attributes
    /// </summary>
    public class XmlParser : IDisposable
    {
        #region Fields
        private XmlDocument _document;
        private XmlDocumentElement _root;
        #endregion
        #region Constructors
        public XmlParser()
        {
            _document = new XmlDocument();
        }

        public XmlParser(string filePath)
        : this()
        {
            this.LoadXml(filePath);
        }
        #endregion
        #region Properties
        public XmlDocumentElement RootElement => _root;
        #endregion
        #region Public Methods
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {

            if(disposing)
            {
                if (_document != null)
                    _document = null;
                if (_root != null)
                    _root = null;
            }
        }
        ~XmlParser()
        {
            Dispose(false);
        }
        public void LoadXml(string filePath)
        {
            _document.Load(filePath);
            ParseDocumentInternal();
        }

        public void LoadXml(XmlDocument document)
        {
            _document = document;
            ParseDocumentInternal();
        }

        #endregion
        #region Private Methods
        private void ParseDocumentInternal()
        {
            _root = new XmlDocumentElement(_document.DocumentElement);

        }
        #endregion
    }
}
