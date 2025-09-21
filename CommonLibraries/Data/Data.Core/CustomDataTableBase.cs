using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TRW.CommonLibraries.Serialization;

namespace TRW.CommonLibraries.Data.Core
{
    /// <summary>
    /// In memory, serializable data table.
    /// </summary>
    /// <typeparam name="DataRow"></typeparam>
    [Serializable]
    public class CustomDataTableBase<DataRow> : IDataTable<DataRow>, IBinarySerializable where DataRow : CustomDataRow, new()
    {
        #region Fields
        protected internal CustomDataRowEnumerator<DataRow> _rowEnum;
        protected CustomDataColumnCollection _columns;

        protected static char[] ColumnDelimiters = new char[] { ',', '|' };
        #endregion

        #region Properties
        public DataRow Current => _rowEnum.Current;
        public CustomDataColumnCollection Columns => _columns;
        public object this[int index]
        {
            get
            {
                return this.Current[index];
            }
            set
            {
                this.Current[index] = value;
            }
        }
        public object this[string colName]
        {
            get
            {
                return this.Current[colName];
            }
            set
            {
                this.Current[colName] = value;
            }
        }
        public int Count => _rowEnum.Count;
        #endregion

        #region Constructors

        public CustomDataTableBase()
        {
            _rowEnum = new CustomDataRowEnumerator<DataRow>(this);
            _columns = new CustomDataColumnCollection();
        }

        protected CustomDataTableBase(params string[] columnNames)
            : this()
        {
            InitializeColumns(columnNames);
        }

        protected CustomDataTableBase(params CustomDataColumn[] columns)
            : this()
        {
            InitializeColumns(columns);
        }

        #endregion

        #region Public Methods

        #region Serialization
        public void WriteTo(BinaryWriter writer)
        {
            byte[] columnBytes = _columns.Serialize();
            writer.Write(columnBytes.Length);
            writer.Write(columnBytes, 0, columnBytes.Length);
            string[] tableRows = SerializeTableRows();
            writer.Write(tableRows.Length);
            foreach (string row in tableRows)
            {
                writer.Write(row);
            }
        }

        public void ReadFrom(BinaryReader reader)
        {
            int columnBytesLength = reader.ReadInt32();
            byte[] columns = reader.ReadBytes(columnBytesLength);
            _columns.Deserialize(columns);
            _rowEnum.InitializeEnumerator(this);
            int rowCount = reader.ReadInt32();
            string[] base64Table = new string[rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                base64Table[i] = reader.ReadString();
            }
            DeserializeTableRows(base64Table);
        }

        public byte[] ToByteArray()
        {
            using (var ms = new MemoryStream())
            using (var writer = new BinaryWriter(ms))
            {
                WriteTo(writer);
                return ms.ToArray(); // Return serialized data as byte array
            }
        }

        public void SerializeTable(string filePath)
        {
            SerializeTable(filePath, false);
        }
        public void SerializeTable(string filePath, bool useCompression)
        {
            Serialization.BinarySerializationRoutines.SerializeToFile(this, filePath, System.IO.FileMode.Create, useCompression);
        }

        public string SerializeTable()
        {
            string serializedData = TRW.CommonLibraries.Serialization.BinarySerializationRoutines.SerializeToString(this);
            return serializedData;
        }

        public void DeserializeFromFile(string filePath)
        {
            DeserializeFromFile(filePath, false);
        }

        public void DeserializeFromFile(string filePath, bool useCompression)
        {
            using (System.IO.MemoryStream reader = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(filePath)))
            {
                DeserializeFromFile(reader, useCompression);
            }
        }

        public void DeserializeFromFile(System.IO.Stream stream, bool useCompression = false)
        {
            System.Diagnostics.Debug.WriteLine($"Deserializing Memory Stream at {DateTime.Now:t}.");
            CustomDataTableBase<DataRow> table = TRW.CommonLibraries.Serialization.BinarySerializationRoutines.DeserializeStream<CustomDataTableBase<DataRow>>(stream, useCompression);
            this.InitializeColumns(table.Columns.Values.ToArray());
            this._rowEnum = table._rowEnum.Clone();
            System.Diagnostics.Debug.WriteLine($"Completed Deserialization at {DateTime.Now:t}.");
        }

        public void DeserializeTable(string serializedData)
        {
            CustomDataTableBase<DataRow> table = TRW.CommonLibraries.Serialization.BinarySerializationRoutines.DeserializeFromString<CustomDataTableBase<DataRow>>(serializedData);
            this.InitializeColumns(table.Columns.Values.ToArray());
            this._rowEnum = table._rowEnum.Clone();
        }

        protected string[] SerializeTableRows()
        {
            string[] values = new string[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                values[i] = _rowEnum._rows[i].SerializeRow();
            }
            return values;
        }

        protected void DeserializeTableRows(string[] serializedData)
        {
            foreach (string value in serializedData)
            {
                DataRow row = new DataRow();
                row.DeserializeRow(this.Columns, value);
                this.Add(row);
            }
        }

        #endregion

        public bool First()
        {
            return _rowEnum.First();
        }

        public bool Last()
        {
            return _rowEnum.Last();
        }

        public bool Next()
        {
            return _rowEnum.MoveNext();
        }

        public DataRow Add()
        {
            DataRow newRow = new DataRow();
            newRow.InitializeRow(Columns, this);
            newRow.SetRowState(CustomDataRow.RowStates.Insert);
            this.Add(newRow);
            return newRow;
        }

        public void Add(DataRow row)
        {
            _rowEnum.Add(row);
        }
        /// <summary>
        /// Append a row - Column names that match will be populated in the new row
        /// </summary>
        /// <param name="row"></param>
        public void Append(CustomDataRow row)
        {
            _rowEnum.AppendRow(row);
        }
        /// <summary>
        /// Append a row - strongly typed
        /// </summary>
        /// <param name="row"></param>
        public void Append(DataRow row)
        {
            _rowEnum.Add(row);
        }

        public void Append(CustomDataTableBase<DataRow> tableToAppend)
        {
            foreach (DataRow row in tableToAppend)
                _rowEnum.Add(row);
        }

        public void Append(CustomDataTableBase<CustomDataRow> tableToAppend)
        {
            foreach (CustomDataRow row in tableToAppend)
                _rowEnum.AppendRow(row);
        }

        public void Delete()
        {
            this.Delete(false);
        }

        public void Delete(bool remove)
        {
            if (this.Current == null)
            {
                throw new InvalidOperationException("No current row to delete.");
            }

            this.Current.Delete();
            if (remove)
                _rowEnum.Delete(this.Current);
        }

        public void Pack()
        {
            _rowEnum.Pack();
        }

        public void Clear()
        {
            this._rowEnum.Clear();
        }

        public IEnumerator<DataRow> GetEnumerator()
        {
            // GetEnumerator disposes when complete so you have to use a copy or new
            return _rowEnum.Clone();
        }

        public bool GoTo(int index)
        {
            return _rowEnum.GoTo(index);
        }

        public bool Seek(params object[] parameters)
        {
            return _rowEnum.Seek(parameters);
        }

        public bool Seek(CustomDataTableIndex<DataRow> index, params object[] parameters)
        {
            return _rowEnum.Seek(index, parameters);
        }

        public bool SeekNext(params object[] parameters)
        {
            return _rowEnum.SeekNext(parameters);
        }

        public bool SeekNext(CustomDataTableIndex<DataRow> index, params object[] parameters)
        {
            return _rowEnum.SeekNext(index, parameters);
        }

        public IEnumerable<DataRow> ScanForMatch(string expression)
        {
            return _rowEnum.ScanForMatch(expression);
        }

        public IEnumerable<DataRow> ScanForMatch(CustomDataTableIndex<DataRow> index, string expression)
        {
            return _rowEnum.ScanForMatch(index, expression);
        }

        /// <summary>
        /// Sums numeric column
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public T Sum<T>(string columnName) where T : struct, IConvertible
        {
            dynamic sum = default(T);
            DataType dataType = _columns.GetColumnType(columnName);
            switch (dataType)
            {
                case DataType.SmallInt:
                    sum = _rowEnum._rows.Sum(r => Convert.ToInt16(r[columnName]));
                    break;
                case DataType.Integer:
                    sum = _rowEnum._rows.Sum(r => Convert.ToInt32(r[columnName]));
                    break;
                case DataType.BigInt:
                    sum = _rowEnum._rows.Sum(r => Convert.ToInt64(r[columnName]));
                    break;
                case DataType.Decimal:
                    sum = _rowEnum._rows.Sum(r => Convert.ToDecimal(r[columnName]));
                    break;
                default:
                    throw new ArgumentException($"Unsupported column DataType {dataType} for Sum. Column: {columnName}", nameof(columnName));
            }

            return sum;
        }

        public void SetIndex(params string[] columns)
        {
            _rowEnum.SetIndex(new CustomDataTableIndex<DataRow>(this, columns));
        }

        public override bool Equals(object obj)
        {
            // TODO: Make Equals
            return _columns.Equals(((CustomDataTableBase<DataRow>)obj)._columns);
        }

        public override int GetHashCode()
        {
            // TODO: Make GetHashCode
            return base.GetHashCode();
        }
        #endregion

        #region Protected/Private Methods
        protected void InitializeColumns(string columnsString)
        {
            string[] columns = columnsString.Split(ColumnDelimiters, StringSplitOptions.RemoveEmptyEntries);
            _columns = new CustomDataColumnCollection(columns.Length);
            for (int i = 0; i < columns.Length; i++)
            {
                string[] kvp = columns[i].Split(new char[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                if (kvp.Length != 2)
                {
                    throw new ArgumentException();
                }
                _columns[i] = new CustomDataColumn(kvp[0], kvp[1]);

            }
        }

        protected void InitializeColumns(string[] columnNames)
        {
            _columns = new CustomDataColumnCollection(columnNames.Length);
            for (int i = 0; i < columnNames.Length; i++)
                _columns[i] = new CustomDataColumn(columnNames[i]);
        }

        protected void InitializeColumns(CustomDataColumn[] columns)
        {
            _columns = new CustomDataColumnCollection(columns.Length);
            for (int i = 0; i < columns.Length; i++)
                _columns[i] = columns[i];
        }

        #endregion
    }

}
