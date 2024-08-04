using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Data.DAL
{
    public class SqlConnector : DataConnector
    {
        private const string _noInstanceIntegratedSecurityConString = @"Server={0};Database={1};Integrated Security=true;";
        private const string _noInstanceUserNamePasswordConString = @"Server={0};Database={1};User Id={2};Password={3};";
        private const string _instanceIntegratedSecurityConString = @"Server={0}\{1};Database={2};Integrated Security=true;";
        private const string _instanceUserNamePasswordConString = @"Server={0}\{1};Database={2};User Id={3};Password={4};";

        public override ConnectionTypes ConnectionType => ConnectionTypes.Sql;
        public new SqlConnection DbConnection => (SqlConnection)_dbConnection;

        #region Constructors
        public SqlConnector(SqlConnection dbConnection) : base(dbConnection)
        {
        }
        
        public SqlConnector(string server, string database)
            :base(string.Format(_noInstanceIntegratedSecurityConString, server, database))
        {
        }

        public SqlConnector(string server, string database, string username, string password)
            : base(string.Format(_noInstanceUserNamePasswordConString, server, database, username, password))
        {
        }

        public SqlConnector(string server, string instance, string database)
            :base(string.Format(_instanceIntegratedSecurityConString, server, instance, database))
        {
        }

        public SqlConnector(string server, string instance, string database, string username, string password)
            : base(string.Format(_instanceUserNamePasswordConString, server, instance, database, username, password))
        {
        }

        public SqlConnector(string conString)
            :base(conString)
        {
        }
        #endregion

    }
}
