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
    public class AccessConnector : DataConnector
    {
        private const string _accessConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False;";

        private const string _access9xExtension = ".mdb";
        private const string _accessExtension = ".accdb";

        public override ConnectionTypes ConnectionType => ConnectionTypes.OleDb;
        public new OleDbConnection DbConnection => (OleDbConnection)_dbConnection;

        #region Constructors
        public AccessConnector(OleDbConnection dbConnection) : base(dbConnection)
        {
        }

        public AccessConnector(string filePath)
            : base(string.Format(_accessConString, filePath))
        {
        }
        
        #endregion

        #region Public Methods
        
        #endregion
        
    }
}
