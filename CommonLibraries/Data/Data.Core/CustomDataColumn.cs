using System;
using System.Collections.Generic;

namespace TRW.CommonLibraries.Data.Core
{
    public class CustomDataColumn
    {
        public string Name { get; set; }
        public DataType Type { get; private set; }
        public bool PrimaryKey { get; private set; }

        public CustomDataColumn()
        {

        }

        public CustomDataColumn(string columnName)
            : this(columnName, DataType.String)
        { }

        public CustomDataColumn(string columnName, DataType type)
        {
            Name = columnName;
            Type = type;
        }

        public CustomDataColumn(string columnName, string type)
        {
            Name = columnName;
            SetType(type);
        }

        internal protected void SetType(DataType dataType)
        {
            Type = dataType;
        }
        public void SetType(Type type)
        {
            if (type == typeof(string))
            {
                Type = DataType.String;
            }
            else if (type == typeof(double))
            {
                Type = DataType.Decimal;
            }
            else if (type == typeof(decimal))
            {
                Type = DataType.Decimal;
            }
            else if (type == typeof(float))
            {
                Type = DataType.Decimal;
            }
            else if (type == typeof(bool))
            {
                Type = DataType.Boolean;
            }
            else if (type == typeof(int))
            {
                Type = DataType.Integer;
            }
            else if (type == typeof(short))
            {
                Type = DataType.SmallInt;
            }
            else if (type == typeof(DateTime))
            {
                Type = DataType.DateTime;
            }
            else if (type == typeof(long))
            {
                Type = DataType.BigInt;
            }

        }

        public void SetType(string typeAsString)
        {
            switch (typeAsString.ToLowerInvariant())
            {
                case "system.string":
                case "string":
                case "char":
                    Type = DataType.String;
                    break;
                case "system.double":
                case "double":
                case "decimal":
                case "float":
                    Type = DataType.Decimal;
                    break;
                case "system.boolean":
                case "boolean":
                case "bool":
                    Type = DataType.Boolean;
                    break;
                case "system.int32":
                case "int32":
                case "int":
                case "integer":
                    Type = DataType.Integer;
                    break;
                case "system.int16":
                case "int16":
                case "short":
                case "smallint":
                    Type = DataType.SmallInt;
                    break;
                case "system.int64":
                case "int64":
                case "long":
                case "bigint":
                    Type = DataType.BigInt;
                    break;
                case "system.datetime":
                case "datetime":
                    Type = DataType.DateTime;
                    break;

            }
        }

        internal void ClearPrimaryKey()
        {
            this.PrimaryKey = false;
        }

        internal void MakePrimaryKey()
        {
            this.PrimaryKey = true;
        }

        public override bool Equals(object obj)
        {
            var column = obj as CustomDataColumn;
            return column != null &&
                   Name == column.Name &&
                   Type == column.Type;
        }

        public override int GetHashCode()
        {
            return (Name.GetHashCode() ^ Type.GetHashCode());
        }
    }
}
