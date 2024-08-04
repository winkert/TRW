using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TRW.CommonLibraries.Data.Core;

namespace TRW.CommonLibraries.Data
{
    public class Schema
    {
        Dictionary<string, CustomDataColumnCollection> _schema;
        public Schema(DataTable columnsSchemaTable, DAL.ConnectionTypes connectionType)
        {
            _schema = new Dictionary<string, CustomDataColumnCollection>();
            InternalConstructor(columnsSchemaTable, connectionType);
        }

        #region Propertyies
        public CustomDataColumnCollection this[string table]
        {
            get
            {
                if (_schema.ContainsKey(table))
                {
                    return _schema[table];
                }

                return null;
            }
        }
        #endregion


        private void InternalConstructor(DataTable columnsSchemaTable, DAL.ConnectionTypes connectionType)
        {

            foreach (DataRow row in columnsSchemaTable.Rows)
            {
                string schema = Convert.ToString(row["TABLE_SCHEMA"]);
                string table = Convert.ToString(row["TABLE_NAME"]);
                string currentTable;
                if (string.IsNullOrWhiteSpace(schema))
                {
                    currentTable = table;
                }
                else
                {
                    currentTable = string.Join(".", Convert.ToString(row["TABLE_SCHEMA"]), Convert.ToString(row["TABLE_NAME"]));
                }
                if (!_schema.ContainsKey(currentTable))
                {
                    _schema.Add(currentTable, new CustomDataColumnCollection());
                }

                int ordinalPosition = Convert.ToInt32(row["ORDINAL_POSITION"]);
                string columnName = Convert.ToString(row["COLUMN_NAME"]);
                int dataTypeInt = Convert.ToInt32(row["DATA_TYPE"]);
                bool isNullable = Convert.ToBoolean(row["IS_NULLABLE"]);
                DataType dataType = StaticRoutines.GetDataType(connectionType, dataTypeInt);
                _schema[currentTable].Add(ordinalPosition, new CustomDataColumn(columnName, dataType));

            }
        }

        public string CreateQuery()
        {
            if (_schema.Count > 0)
                return CreateQuery(_schema.Keys.First());

            return string.Empty;
        }

        public string CreateQuery(string tableName)
        {
            if(_schema.ContainsKey(tableName))
            {
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("SELECT ");
                foreach(CustomDataColumn col in _schema[tableName].Values)
                {
                    queryBuilder.Append(string.Format("[{0}],", col.Name));
                }
                queryBuilder.Length--;
                if (tableName.Contains("."))
                {
                    var split = tableName.Split('.');
                    tableName = string.Format("[{0}].[{1}]", split[0], split[1]);
                }
                else
                {
                    tableName = string.Format("[{0}]", tableName);
                }

                queryBuilder.AppendFormat(" FROM {0}", tableName);
                return queryBuilder.ToString();
            }

            return string.Empty;
        }
    }
}
