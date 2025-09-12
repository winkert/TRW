using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;
using TRW.CommonLibraries.Xml;
using OfficeOpenXml;
using OfficeOpenXml.Utils;
using TRW.CommonLibraries.Data.Core;

namespace TRW.CommonLibraries.Data
{
    [Serializable]
    public class CustomDataTable : CustomDataTable<CustomDataRow>
    {
        public CustomDataTable()
            : base()
        { }

        public CustomDataTable(string[] columns)
            : base(columns)
        { }

        public CustomDataTable(params CustomDataColumn[] columns)
            : base(columns)
        { }

        public CustomDataTable(DAL.DataConnector connector)
            : base(connector)
        { }

        public CustomDataTable(DAL.DataConnector connector, params string[] columns)
            : base(connector, columns)
        { }

        public CustomDataTable(DAL.DataConnector connector, params CustomDataColumn[] columns)
            : base(connector, columns)
        { }
    }

    /// <summary>
    /// Base Custom Data Table with connection information
    /// </summary>
    /// <typeparam name="DataRow"></typeparam>
    [Serializable]
    public class CustomDataTable<DataRow> : CustomDataTableBase<DataRow>, IConnectedDataTable<DataRow> where DataRow : CustomDataRow, new()
    {
        #region Fields
        protected DAL.DataConnector _dataConnection;
        protected bool _connected;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public CustomDataTable()
        {
            _connected = false;
            _dataConnection = null;
            _rowEnum = new CustomDataRowEnumerator<DataRow>(this);
            _columns = new CustomDataColumnCollection();
        }

        public CustomDataTable(params string[] columnNames)
            : base(columnNames)
        {
        }

        public CustomDataTable(params CustomDataColumn[] columns)
            : base(columns)
        {
        }

        public CustomDataTable(DAL.DataConnector connector)
        {
            _dataConnection = connector;
            _connected = true;
            _rowEnum = new CustomDataRowEnumerator<DataRow>(this);
        }

        public CustomDataTable(string columns, DAL.DataConnector connector)
            : this(connector)
        {
            InitializeColumns(columns);
        }

        public CustomDataTable(DAL.DataConnector connector, params string[] columnNames)
            : this(connector)
        {
            InitializeColumns(columnNames);
        }

        public CustomDataTable(DAL.DataConnector connector, params CustomDataColumn[] columns)
            : this(connector)
        {
            InitializeColumns(columns);
        }
        #endregion

        #region Public Methods
        
        public int Fetch(string query)
        {
            if (_columns == null)
            {
                InitializeColumnsFromQuery(query);
            }
            return Fill(query);
        }

        public void SaveToExcel(string filePath, bool includeHeaders)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Thaddeus R. Winker");
            using (ExcelPackage package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Table");
                int c = 1;
                int currentRow = 1;
                if (includeHeaders)
                {
                    foreach (var column in this.Columns)
                    {
                        worksheet.Cells[currentRow, c++].Value = column.Value.Name;
                    }
                    worksheet.Row(currentRow).Style.Font.Bold = true;
                    worksheet.View.FreezePanes(currentRow + 1, 1);
                    currentRow++;
                }
                foreach (DataRow row in this)
                {
                    c = 1;
                    foreach (var column in this.Columns)
                    {
                        var cell = worksheet.Cells[currentRow, c++];
                        switch (column.Value.Type)
                        {
                            case DataType.BigInt:
                            case DataType.Integer:
                            case DataType.SmallInt:
                            case DataType.Decimal:
                                break;
                            case DataType.Boolean:
                                break;
                            case DataType.DateTime:
                                cell.Style.Numberformat.Format = "m/d/yyyy hh:mm";
                                break;
                            case DataType.String:
                                cell.Style.QuotePrefix = true;
                                break;
                            case DataType.Null:
                                cell.Value = null;
                                continue;
                        }
                        cell.Value = row[column.Key];
                    }
                    currentRow++;
                }

                c = 1;
                foreach (var column in this.Columns)
                {
                    worksheet.Column(c++).AutoFit();
                }

                package.SaveAs(new System.IO.FileInfo(filePath));
            }
        }

        public void SaveToXml(string filePath)
        {
            this.First();
            using (XmlBuilder writer = new XmlBuilder(filePath))
            {
                writer.OpenElement("Table");
                writer.WriteElement("Rows", this.Count);
                do
                {
                    writer.OpenElement("Item");

                    foreach (KeyValuePair<int, CustomDataColumn> column in this.Columns)
                    {
                        if (this.Current[column.Key] == null)
                            continue;

                        if (column.Value.Type == DataType.DateTime)
                        {
                            // there is some data loss here, which should be expected
                            writer.WriteElement(column.Value.Name, ((DateTime)this.Current[column.Key]).ToString("G"));
                        }
                        else
                            writer.WriteElement(column.Value.Name, this.Current[column.Key]);
                    }
                    writer.CloseElement();
                } while (this.Next());

                writer.CloseElement();
                writer.FinalizeDocument();
            }
        }

        public void ReadFromXml(string filePath)
        {
            this.Clear();
            using (XmlParser reader = new XmlParser(filePath))
            {
                int rows = 0;
                XmlDocumentElement root = reader.RootElement;
                foreach (XmlDocumentElement item in root.Children)
                {
                    if (item.Name.Equals("Rows"))
                    {
                        rows = int.Parse(item.Value);
                        continue;
                    }

                    CustomDataRow newRow = this.Add();
                    foreach (KeyValuePair<int, CustomDataColumn> column in this.Columns)
                    {
                        if (item.SeekElement(column.Value.Name))
                        {
                            switch (column.Value.Type)
                            {
                                case DataType.String:
                                    newRow[column.Key] = item.CurrentChild.Value;
                                    break;
                                case DataType.Integer:
                                    newRow[column.Key] = int.Parse(item.CurrentChild.Value);
                                    break;
                                case DataType.Decimal:
                                    newRow[column.Key] = decimal.Parse(item.CurrentChild.Value);
                                    break;
                                case DataType.SmallInt:
                                    newRow[column.Key] = short.Parse(item.CurrentChild.Value);
                                    break;
                                case DataType.DateTime:
                                    newRow[column.Key] = DateTime.Parse(item.CurrentChild.Value);
                                    break;
                                case DataType.Boolean:
                                    newRow[column.Key] = Convert.ToBoolean(item.CurrentChild.Value);
                                    break;
                            }
                        }
                    }
                }

                if (rows != this.Count)
                    throw new Exception($"Error parsing XML: Row Count Mismatch. Value in XML: [{rows}]. Rows Parsed: [{this.Count}]");
            }
        }

        #endregion

        #region Protected/Private Methods
        protected int Fill(string query)
        {
            int retrievedRowCount = 0;
            try
            {
                _dataConnection.Open();
                using (DbTransaction readTrans = _dataConnection.BeginTransaction())
                {
                    using (DbDataReader dataReader = this._dataConnection.GetDataReader(query, readTrans))
                    {
                        while (dataReader.Read())
                        {
                            DataRow newRow = new DataRow();
                            newRow.InitializeRow(Columns, this);
                            dataReader.GetValues(newRow.Items);
                            this.Add(newRow);
                            retrievedRowCount++;
                        }
                    }
                    readTrans.Commit();
                }
            }
            finally
            {
                if (_dataConnection.ConnectionState == ConnectionState.Open)
                    _dataConnection.Close();
            }
            return retrievedRowCount;
        }

        protected int SaveChanges()
        {
            int savedRowCount = 0;
            try
            {
                _dataConnection.Open();
                using (DbTransaction readTrans = _dataConnection.BeginTransaction())
                {
                    _dataConnection.ExecuteQuery(GetSaveChangesCommand());
                }
            }
            finally
            {
                if (_dataConnection.ConnectionState == ConnectionState.Open)
                    _dataConnection.Close();
            }
            return savedRowCount;
        }
        protected void InitializeColumnsFromQuery(string query)
        {
            _columns = _dataConnection.GetSchemaData(query);
        }

        private string GetSaveChangesCommand()
        {
            StringBuilder commandBuilder = new StringBuilder();


            return commandBuilder.ToString();
        }
        #endregion
    }

}
