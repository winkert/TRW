using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TRW.CommonLibraries.Data.DAL
{
    public class ExcelConnector : DataConnector
    {
        private const string _excelConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"{1}\";";
        private const string _excel9xProperty = "Excel 8.0;";
        private const string _excelProperty = "Excel 12.0;";
        private const string _excelHDRProperty = "HDR={0};";
        private const string _excelIMEXProperty = "IMEX={0};";

        private const string _excel9xExtension = ".xls";
        private const string _excelExtension = ".xlsx";

        public override ConnectionTypes ConnectionType => ConnectionTypes.OleDb;
        public new OleDbConnection DbConnection => (OleDbConnection)_dbConnection;

        #region Constructors
        public ExcelConnector(OleDbConnection dbConnection) : base(dbConnection)
        {
        }

        public ExcelConnector(string filePath)
            : base(CreateConnectionString(filePath, true, true))
        {
        }

        public ExcelConnector(string filePath, bool headers)
            :base(CreateConnectionString(filePath, headers, true))
        {
        }

        public ExcelConnector(string filePath, bool headers, bool asText)
            : base(CreateConnectionString(filePath, headers, asText))
        {
        }
        #endregion

        #region Public Methods
        public static string CreateConnectionString(string filePath, bool headers, bool asText)
        {
            string conString = string.Empty;
            string properties = string.Empty;
            string fileExtension = Path.GetExtension(filePath);
            switch(fileExtension)
            {
                case _excel9xExtension:
                    properties = _excel9xProperty;
                    break;
                case _excelExtension:
                    properties = _excelProperty;
                    break;
                default:
                    throw new Exception(string.Format("Unrecognize file format for Excel connection {0}", fileExtension));
            }

            if (headers)
                properties = string.Format("{0}{1}", properties, string.Format(_excelHDRProperty, "YES"));

            if (asText)
                properties = string.Format("{0}{1}", properties, string.Format(_excelIMEXProperty, "1"));

            conString = string.Format(_excelConString, filePath, properties);
            return conString;
        }
        #endregion
        
    }
}
