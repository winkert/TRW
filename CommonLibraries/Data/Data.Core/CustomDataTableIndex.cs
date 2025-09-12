using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRW.CommonLibraries.Core; // For NodeTree and Node

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
                throw new ArgumentException();

            for(int i = 0; i < _indexedColumnOrdinals.Length; i++)
            {
                if (!row[_indexedColumnOrdinals[i]].Equals(parameters[i]))
                    isMatch = false;

            }

            return isMatch;
        }

        public bool IsMatch(DataRow row, System.Text.RegularExpressions.Regex regex)
        {
            bool isMatch = false;

            if (_indexedColumnOrdinals.Length != 1)
                throw new NotImplementedException(); // do not support more than one column for this type of match
            
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
