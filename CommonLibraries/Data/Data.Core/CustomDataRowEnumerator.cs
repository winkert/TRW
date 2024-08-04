using System;
using System.Collections;
using System.Collections.Generic;

namespace TRW.CommonLibraries.Data.Core
{
    public class CustomDataRowEnumerator<DataRow> : IEnumerator<DataRow> where DataRow : CustomDataRow, new()
    {
        protected internal int _deletedCount;
        protected internal List<DataRow> _rows;
        private int _index;
        private CustomDataTableBase<DataRow> _table;
        private CustomDataTableIndex<DataRow> _currentIndex;
        private bool _disposed = false;

        #region Properties
        public int Count => _rows.Count - _deletedCount;

        public DataRow Current
        {
            get
            {
                if (_index < _rows.Count && _index > -1)
                    return _rows[_index];
                else
                    return null;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                if (_index < _rows.Count && _index > -1)
                    return _rows[_index];
                else
                    return null;
            }
        }
        #endregion

        public CustomDataRowEnumerator()
        {
            _index = -1;
            _rows = new List<DataRow>();
            _deletedCount = 0;
        }

        public CustomDataRowEnumerator(CustomDataTableBase<DataRow> parentTable)
            : this()
        {
            _table = parentTable;
        }

        #region Public Methods
        public bool First()
        {
            if (_rows.Count > 0)
            {
                _index = -1;
                return Next();
            }
            else
                return false;
        }

        public bool Last()
        {
            if (_rows.Count > 0)
            {
                _index = _rows.Count;
                return Previous();
            }
            else
                return false;
        }

        public void Add(DataRow row)
        {
            _rows.Add(row);
            _index = _rows.Count - 1;
        }

        /// <summary>
        /// Append a row to the enumerator
        /// N.B. This is not strongly typed. This method converts weakly typed rows to strongly typed rows.
        ///     Columns that have a matching name and data type will be populated in new table row
        /// </summary>
        /// <param name="row"></param>
        public void AppendRow(CustomDataRow row)
        {
            DataRow newRow = new DataRow();
            newRow.InitializeRow(_table.Columns);
            foreach(var column in _table.Columns)
            {
                if(row.Columns.HasColumn(column.Value))
                {
                    newRow[column.Value.Name] = row[column.Value.Name];
                }
            }
            Add(newRow);
        }

        public void Delete(DataRow row)
        {
            row.Delete();
            _deletedCount++;
            // this is probably going to mess with the Current and screw some stuff up
            // but, insert "You shouldn't alter a enumerable while enumerating through it"
            if (Current == null || Current.Deleted)
            {
                MoveNext();
            }

        }

        public void Clear()
        {
            _rows.Clear();
            Reset();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _currentIndex = null;
                _rows.Clear();
                _rows = null;
                _index = -1;
            }
            _disposed = true;
        }

        ~CustomDataRowEnumerator()
        {
            Dispose(false);
        }
        
        public bool Previous()
        {
            for (; ; )
            {
                if (_index - 1 > -1)
                {
                    _index--;
                    if (Current.Deleted)
                        continue;
                    return true;
                }
                else
                {
                    _index = -1;
                    return false;
                }
            }
        }

        public bool Next()
        {
            for (; ; )
            {
                if (_index + 1 < _rows.Count)
                {
                    _index++;
                    if (Current.Deleted)
                        continue;
                    return true;
                }
                else
                {
                    _index = -1;
                    return false;
                }
            }
        }

        public bool MoveNext()
        {
            if (_disposed)
                return false;

            return Next();
        }

        public void Reset()
        {
            _index = -1;
        }

        public CustomDataRowEnumerator<DataRow> Clone()
        {
            CustomDataRowEnumerator<DataRow> enumerator = new CustomDataRowEnumerator<DataRow>(_table);
            DataRow[] items = new DataRow[Count];
            _rows.CopyTo(items, 0);
            enumerator._rows.AddRange(items);

            if (_currentIndex != null)
                enumerator.SetIndex(_currentIndex);
            
            return enumerator;
        }

        public void SetIndex(CustomDataTableIndex<DataRow> index)
        {
            if (index.IsMyParentTable(_table))
                _currentIndex = index;
            else
                throw new ArgumentException();

            Sort();
        }

        public bool GoTo(int index)
        {
            if (index < Count)
            {
                _index = index;
                return true;
            }

            return false;
        }

        public bool Seek(params object[] parameters)
        {
            if (_currentIndex == null)
                throw new ArgumentNullException("Table does not have an index to seek on.");

            return Seek(_currentIndex, parameters);
        }

        public bool Seek(CustomDataTableIndex<DataRow> index, params object[] parameters)
        {
            Reset();
            while (MoveNext())
            {
                if (index.IsMatch(Current, parameters))
                    return true;
            }
            return false;
        }

        public IEnumerable<DataRow> ScanForMatch(string pattern)
        {
            return ScanForMatch(_currentIndex, pattern);
        }

        public IEnumerable<DataRow> ScanForMatch(CustomDataTableIndex<DataRow> index, string pattern)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            foreach (DataRow row in _rows)
                if (index.IsMatch(row, regex))
                    yield return row;
        }

        public bool SeekNext(params object[] parameters)
        {
            if (_currentIndex == null)
                throw new ArgumentNullException("Table does not have an index to seek on.");

            return SeekNext(_currentIndex, parameters);
        }

        public bool SeekNext(CustomDataTableIndex<DataRow> index, params object[] parameters)
        {
            while (MoveNext())
            {
                if (index.IsMatch(Current, parameters))
                    return true;
            }
            return false;
        }

        public void Sort()
        {
            _rows.Sort(_currentIndex);
            Reset();
        }

        internal void InitializeEnumerator(CustomDataTableBase<DataRow> table)
        {
            _table = table;
            foreach (DataRow row in _rows)
                row.InitializeRow(_table.Columns);
        }
        #endregion
    }
}
