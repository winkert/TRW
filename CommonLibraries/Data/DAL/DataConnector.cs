using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using TRW.CommonLibraries.Data.Core;

namespace TRW.CommonLibraries.Data.DAL
{
    public abstract class DataConnector : IDisposable
    {
        protected DbConnection _dbConnection;
        protected string _connectionString;
        protected Schema _dataSchema;

        public abstract ConnectionTypes ConnectionType { get; }
        public DbConnection DbConnection => _dbConnection;
        public ConnectionState ConnectionState => _dbConnection.State;

        public Schema DataSchema
        {
            get 
            {
                if (_dataSchema == null)
                {
                    FetchAndStoreSchema();
                }
                return _dataSchema;
            }
        }
        #region Constructors
        protected DataConnector(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _connectionString = DbConnection.ConnectionString;
        }

        internal DataConnector(string connectionString)
        {
            _connectionString = connectionString;
            switch (ConnectionType)
            {
                case ConnectionTypes.Sql:
                    _dbConnection = new System.Data.SqlClient.SqlConnection(connectionString);
                    break;
                case ConnectionTypes.OleDb:
                    _dbConnection = new System.Data.OleDb.OleDbConnection(connectionString);
                    break;
                case ConnectionTypes.MySql:
                    _dbConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    break;
                case ConnectionTypes.Unknown:
                    throw new NotImplementedException();
                default:
                    throw new Exception($"Unexpected connection type {ConnectionType}. Unable to create DataConnector");
            }
        }
        #endregion

        #region Public Base Methods
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                ((IDisposable)_dbConnection).Dispose();
            }
        }
        ~DataConnector()
        {
            Dispose(false);
        }
        public int ExecuteQuery(string query)
        {
            try
            {
                this.Open();

                using(DbTransaction transaction = this.BeginTransaction())
                {
                    return ExecuteQuery(query, transaction);
                }
            }
            finally
            {
                this.Close();
            }
        }
        public int ExecuteQuery(string query, DbTransaction transaction)
        {
            try
            {
                this.Open();

                DbCommand command = this.CreateCommand(transaction);
                command.CommandText = query; // TODO: needs security to handle injection
                return command.ExecuteNonQuery();
            }
            finally
            {
                this.Close();
            }
        }

        public DbDataAdapter GetDataAdapter()
        {
            switch (ConnectionType)
            {
                case ConnectionTypes.Sql:
                    return new System.Data.SqlClient.SqlDataAdapter();
                case ConnectionTypes.OleDb:
                    return new System.Data.OleDb.OleDbDataAdapter();
                case ConnectionTypes.MySql:
                    return new MySql.Data.MySqlClient.MySqlDataAdapter();
                case ConnectionTypes.Unknown:
                    throw new NotImplementedException();
                default:
                    throw new Exception(string.Format("Unexpected connection type {0}. Unable to create DataAdapter", ConnectionType));
            }
        }

        public CustomDataColumnCollection GetSchemaData(string query)
        {
            DbDataReader reader;
            CustomDataColumnCollection columns = null;
            try
            {
                this.Open();
                using (DbTransaction readTrans = this.BeginTransaction())
                {
                    reader = GetDataReader(query, readTrans, CommandBehavior.SchemaOnly);
                    var schema = reader.GetSchemaTable();

                    int columnsCount = schema.Rows.Count;
                    columns = new CustomDataColumnCollection(columnsCount);
                    int i = 0;
                    foreach (DataRow column in schema.Rows)
                    {
                        columns[i].Name = (string)column["ColumnName"];
                        columns[i].SetType((Type)column["DataType"]);
                        // try a couple of different ways to determine if a field is a primary key
                        try
                        {
                            if ((bool)column["IsIdentity"])
                                columns.MakePrimaryKey(i);
                        }
                        catch { } // don't care if we can't set this
                        try
                        {
                            if ((bool)column["IsKey"])
                                columns.MakePrimaryKey(i);
                        }
                        catch { } // don't care if we can't set this
                        i++;
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Close();
            }

            return columns;
        }

        internal protected void FetchAndStoreSchema()
        {
            try
            {
                this.Open();

                _dataSchema = new Schema(DbConnection.GetSchema("Columns"), ConnectionType);
            }
            finally
            {
                this.Close();
            }
        }

        public DbDataReader GetDataReader(string query)
        {
            try
            {
                this.Open();

                using (DbTransaction readTrans = this.BeginTransaction())
                {
                    return GetDataReader(query, readTrans);
                }
            }
            finally
            {
                this.Close();
            }
        }

        public DbDataReader GetDataReader(string query, DbTransaction transaction, CommandBehavior commandBehavior = CommandBehavior.Default)
        {
            DbCommand command = CreateCommand(transaction);
            command.CommandText = query;

            return command.ExecuteReader(commandBehavior);
        }
        public DbCommand CreateCommand()
        {
            try
            {
                this.Open();

                using (DbTransaction transaction = this.BeginTransaction())
                {
                    return CreateCommand(transaction);
                }
            }
            finally
            {
                this.Close();
            }
        }
        public DbCommand CreateCommand(DbTransaction transaction)
        {
            DbCommand command;
            switch (ConnectionType)
            {
                case ConnectionTypes.Sql:
                    command = new System.Data.SqlClient.SqlCommand
                    {
                        Connection = (System.Data.SqlClient.SqlConnection)DbConnection,
                        Transaction = (System.Data.SqlClient.SqlTransaction)transaction
                    };
                    break;
                case ConnectionTypes.OleDb:
                    command = new System.Data.OleDb.OleDbCommand
                    {
                        Connection = (System.Data.OleDb.OleDbConnection)DbConnection,
                        Transaction = (System.Data.OleDb.OleDbTransaction)transaction
                    };
                    break;
                case ConnectionTypes.MySql:
                    command = new MySql.Data.MySqlClient.MySqlCommand
                    {
                        Connection = (MySql.Data.MySqlClient.MySqlConnection)DbConnection,
                        Transaction = (MySql.Data.MySqlClient.MySqlTransaction)transaction
                    };
                    break;
                case ConnectionTypes.Unknown:
                    throw new NotImplementedException();
                default:
                    throw new Exception(string.Format("Unexpected connection type {0}. Unable to create DataReader", ConnectionType));
            }
            return command;
        }

        public DbTransaction BeginTransaction()
        {
            return BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public DbTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return DbConnection.BeginTransaction(isolationLevel);
        }

        public void Open()
        {
            if(this.ConnectionState != ConnectionState.Open)
                DbConnection.Open();
        }

        public void Close()
        {
            if (this.ConnectionState == ConnectionState.Open)
                DbConnection.Close();
        }
        #endregion
    }
}
