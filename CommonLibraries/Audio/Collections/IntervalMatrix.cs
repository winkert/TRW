using System;
using System.Collections.Generic;
using System.Text;
using TRW.CommonLibraries.Core;

namespace TRW.CommonLibraries.Audio
{
    public class IntervalMatrix : IMatrix<double>
    {

        #region Fields
        protected readonly IntervalEnumerator _enumerator;
        private readonly Tuple<int, int> _size;
        #endregion

        #region Constructors
        public IntervalMatrix(int x, int y)
        {
            _enumerator = new IntervalEnumerator(this, x, y);
            _size = new Tuple<int, int>(x, y);
        }
        #endregion

        public int Width => _size.Item1;

        public int Height => _size.Item2;

        public double this[int x, int y]
        {
            get => _enumerator[x, y];
            set => _enumerator[x, y] = value;
        }

        public double Current => _enumerator.Current;

        #region Publics
        public bool CellExists(int x, int y)
        {
            return _enumerator.WithinRange(x, y);
        }

        public bool First()
        {
            return _enumerator.First();
        }

        public bool Next()
        {
            return _enumerator.MoveNext();
        }

        public IEnumerator<double> GetEnumerator()
        {
            return _enumerator;
        }
        #endregion
    }
}
