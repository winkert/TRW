using System;
using System.Collections.Generic;

namespace TRW.CommonLibraries.Data.Core
{
    public class CustomDataTableIndex<DataRow> : IComparer<DataRow> where DataRow : CustomDataRow, IComparable<DataRow>, new()
    {
        #region Fields
        private int[] _indexedColumnOrdinals;
        private CustomDataTableBase<DataRow> _parentTable;
        private bool _disposed;
        #endregion

        #region Constructors
        public CustomDataTableIndex(CustomDataTableBase<DataRow> table, params string[] columns)
        {
            _indexedColumnOrdinals = new int[columns.Length];
            _parentTable = table;
            InitializeIndex(columns);
        }
        #endregion

        #region Properties
        #endregion

        #region Publics
        public void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if(disposing)
            {
                _parentTable = null;
                _indexedColumnOrdinals = null;
            }

            _disposed = true;
        }
        public bool IsMyParentTable(CustomDataTableBase<DataRow> table)
        {
            if (_parentTable.Equals(table))
                return true;

            return false;
        }

        public bool IsMatch(DataRow row, params object[] parameters)
        {
            bool isMatch = true;
            if (parameters.Length != _indexedColumnOrdinals.Length)
                throw new ArgumentException("Parameter count does not match indexed columns.");

            for(int i = 0; i < _indexedColumnOrdinals.Length; i++)
            {
                object param = parameters[i];
                switch (_parentTable.Columns[_indexedColumnOrdinals[i]].Type)
                {
                    case DataType.Integer:
                        if (!(param is int))
                            throw new ArgumentException($"Parameter {i} is not of type int.");
                        break;
                    default:
                        break;
                }

                if (!row[_indexedColumnOrdinals[i]].Equals(parameters[i]))
                    isMatch = false;

            }

            return isMatch;
        }

        /// <summary>
        /// Slow regex match of a single column index
        /// </summary>
        /// <param name="row"></param>
        /// <param name="regex"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public bool IsMatch(DataRow row, System.Text.RegularExpressions.Regex regex)
        {
            bool isMatch = false;

            if (_indexedColumnOrdinals.Length != 1)
                throw new ArgumentException("Regular Expression Match is only valid for single column indexes.");
            
            // TODO: consider if there should be an argument exception for trying to use Regex on something like an int or datetime
            if (regex.IsMatch(row[_indexedColumnOrdinals[0]].ToString()))
                isMatch = true;

            return isMatch;
        }

        public int Compare(DataRow x, DataRow y)
        {
            foreach(int columnOrdinal in _indexedColumnOrdinals)
            {
                if (!x[columnOrdinal].Equals(y[columnOrdinal]))
                {
                    // need to know the data type and do Compare
                    // supported data types are IComparable
                    IComparable xValue = x[columnOrdinal] as IComparable;
                    IComparable yValue = y[columnOrdinal] as IComparable;
                    return xValue.CompareTo(yValue);
                }
            }

            return 0;
        }

        public DataRow CreateParameterRow(params object[] parameters)
        {
            if (parameters.Length != _indexedColumnOrdinals.Length)
                throw new ArgumentException();
            DataRow row = new DataRow();
            row.InitializeRow(_parentTable.Columns, _parentTable);
            for (int i = 0; i < _indexedColumnOrdinals.Length; i++)
            {
                row[_indexedColumnOrdinals[i]] = parameters[i];
            }
            return row;
        }

        #endregion

        #region Privates
        private void InitializeIndex(string[] columns)
        {
            for (int i = 0; i < _indexedColumnOrdinals.Length; i++)
            {
                _indexedColumnOrdinals[i] = _parentTable.Columns[columns[i]];
            }
        }
        #endregion
    }
}
