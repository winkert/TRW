using System;
using System.Collections.Generic;
using TRW.CommonLibraries.Data.Core;
using System.Text.RegularExpressions;
using System.Data.Common;

namespace TRW.CommonLibraries.Data
{
    public static class StaticRoutines
    {
        /// <summary>
        /// Gets the corresponding data type based on the X.Data DataType value and the connecction type
        /// </summary>
        /// <param name="connectionType"></param>
        /// <param name="dataTypeInt"></param>
        /// <returns></returns>
        public static DataType GetDataType(DAL.ConnectionTypes connectionType, int dataTypeInt)
        {
            DataType dataType;
            switch (connectionType)
            {
                case DAL.ConnectionTypes.Sql:
                    System.Data.SqlDbType sqlDbType = (System.Data.SqlDbType)dataTypeInt;
                    switch (sqlDbType)
                    {
                        case System.Data.SqlDbType.Int:
                            dataType = DataType.Integer;
                            break;
                        case System.Data.SqlDbType.NVarChar:
                        case System.Data.SqlDbType.NChar:
                        case System.Data.SqlDbType.Char:
                        case System.Data.SqlDbType.VarChar:
                            dataType = DataType.String;
                            break;
                        case System.Data.SqlDbType.SmallInt:
                            dataType = DataType.SmallInt;
                            break;
                        case System.Data.SqlDbType.BigInt:
                            dataType = DataType.BigInt;
                            break;
                        case System.Data.SqlDbType.Bit:
                            dataType = DataType.Boolean;
                            break;
                        case System.Data.SqlDbType.DateTime:
                            dataType = DataType.DateTime;
                            break;
                        case System.Data.SqlDbType.Decimal:
                        case System.Data.SqlDbType.Float:
                        case System.Data.SqlDbType.Real:
                        case System.Data.SqlDbType.Money:
                            dataType = DataType.Decimal;
                            break;
                        default:
                            throw new Exception(string.Format("Unable to find matching DataType for SqlDbType [{0}]", sqlDbType));
                    }
                    break;
                case DAL.ConnectionTypes.OleDb:
                    System.Data.OleDb.OleDbType oleDbType = (System.Data.OleDb.OleDbType)dataTypeInt;
                    switch (oleDbType)
                    {
                        case System.Data.OleDb.OleDbType.Integer:
                            dataType = DataType.Integer;
                            break;
                        case System.Data.OleDb.OleDbType.VarWChar:
                        case System.Data.OleDb.OleDbType.WChar:
                        case System.Data.OleDb.OleDbType.Char:
                        case System.Data.OleDb.OleDbType.VarChar:
                            dataType = DataType.String;
                            break;
                        case System.Data.OleDb.OleDbType.SmallInt:
                            dataType = DataType.SmallInt;
                            break;
                        case System.Data.OleDb.OleDbType.BigInt:
                            dataType = DataType.BigInt;
                            break;
                        case System.Data.OleDb.OleDbType.Boolean:
                            dataType = DataType.Boolean;
                            break;
                        case System.Data.OleDb.OleDbType.Date:
                            dataType = DataType.DateTime;
                            break;
                        case System.Data.OleDb.OleDbType.Decimal:
                        case System.Data.OleDb.OleDbType.Double:
                        case System.Data.OleDb.OleDbType.Currency:
                            dataType = DataType.Decimal;
                            break;
                        default:
                            throw new Exception(string.Format("Unable to find matching DataType for SqlDbType [{0}]", oleDbType));
                    }
                    break;
                case DAL.ConnectionTypes.MySql:
                    MySql.Data.MySqlClient.MySqlDbType mySqlDbType = (MySql.Data.MySqlClient.MySqlDbType)dataTypeInt;
                    switch (mySqlDbType)
                    {
                        case MySql.Data.MySqlClient.MySqlDbType.Int32:
                            dataType = DataType.Integer;
                            break;
                        case MySql.Data.MySqlClient.MySqlDbType.VarChar:
                        case MySql.Data.MySqlClient.MySqlDbType.String:
                        case MySql.Data.MySqlClient.MySqlDbType.VarString:
                            dataType = DataType.String;
                            break;
                        case MySql.Data.MySqlClient.MySqlDbType.Int16:
                            dataType = DataType.SmallInt;
                            break;
                        case MySql.Data.MySqlClient.MySqlDbType.Int64:
                            dataType = DataType.BigInt;
                            break;
                        case MySql.Data.MySqlClient.MySqlDbType.Bit:
                            dataType = DataType.Boolean;
                            break;
                        case MySql.Data.MySqlClient.MySqlDbType.DateTime:
                            dataType = DataType.DateTime;
                            break;
                        case MySql.Data.MySqlClient.MySqlDbType.Decimal:
                        case MySql.Data.MySqlClient.MySqlDbType.Float:
                        case MySql.Data.MySqlClient.MySqlDbType.Double:
                            dataType = DataType.Decimal;
                            break;
                        default:
                            throw new Exception(string.Format("Unable to find matching DataType for SqlDbType [{0}]", mySqlDbType));
                    }
                    break;
                default:
                    throw new Exception(string.Format("Unexpected connection type {0}. Unable to create DataReader", connectionType));
            }

            return dataType;

        }

        internal const string SqlConnectionMatch = @"";
        internal const string Excel9xConnectionMatch = @"";
        internal const string ExcelConnectionMatch = @"";
        internal const string Access9xConnectionMatch = @"";
        internal const string AccessConnectionMatch = @"";
        internal const string MySqlConnectionMatch = @"";

        public static Regex SqlConRegex = new Regex(SqlConnectionMatch);
        public static Regex Excel9xRegex = new Regex(Excel9xConnectionMatch);
        public static Regex ExcelRegex = new Regex(ExcelConnectionMatch);
        public static Regex Access9xRegex = new Regex(Access9xConnectionMatch);
        public static Regex AccessRegex = new Regex(AccessConnectionMatch);
        public static Regex MySqlRegex = new Regex(MySqlConnectionMatch);

        public static DbConnection GetConnectionTypeFromConnectionString(string connectionString)
        {
            if (SqlConRegex.IsMatch(connectionString))
                return new System.Data.SqlClient.SqlConnection(connectionString);
            if (Excel9xRegex.IsMatch(connectionString))
                return new System.Data.OleDb.OleDbConnection(connectionString);
            if (ExcelRegex.IsMatch(connectionString))
                return new System.Data.OleDb.OleDbConnection(connectionString);
            if (Access9xRegex.IsMatch(connectionString))
                return new System.Data.OleDb.OleDbConnection(connectionString);
            if (AccessRegex.IsMatch(connectionString))
                return new System.Data.OleDb.OleDbConnection(connectionString);
            if (MySqlRegex.IsMatch(connectionString))
                return new MySql.Data.MySqlClient.MySqlConnection(connectionString);

            return null;
        }
    }
}
