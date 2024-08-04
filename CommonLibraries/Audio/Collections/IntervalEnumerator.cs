using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TRW.CommonLibraries.Core;

namespace TRW.CommonLibraries.Audio
{
    public class IntervalEnumerator : RectangularEnumeratorBase<double>
    {
        #region Fields
        private bool _disposed;
        private readonly IntervalMatrix _parentCollection;
        private double[,] _intervals;
        protected Position _position;
        #endregion
        #region Constructors
        public IntervalEnumerator(IntervalMatrix collection, int x, int y)
            : base(x, y)
        {
            _parentCollection = collection;
            _intervals = new double[_x, _y];

            _position = new Position(_indexX, _indexY);
        }
        #endregion


        public override double Current
        {
            get
            {
                if (_indexX > -1 && _indexY > -1
                    && _indexX < _x && _indexY < _y)
                {
                    return this[_indexX, _indexY];
                }
                else
                    throw new NullReferenceException();
            }
            set
            {
                this[_indexX, _indexY] = value;
            }
        }

        protected override double[,] Items => _intervals;

        public override Position Position => _position;

        public override double this[int x, int y]
        {
            get
            {
                if (WithinRange(x, y))
                    return _intervals[x, y];
                throw new IndexOutOfRangeException($"Incoming vector {x},{y} not within range {_x},{_y}");
            }
            set
            {
                if (WithinRange(x, y))
                    _intervals[x, y] = value;
                else
                    throw new IndexOutOfRangeException($"Incoming vector {x},{y} not within range {_x},{_y}");
            }
        }

        #region Publics
        public override void Dispose()
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
                _intervals = null;
            }
            _disposed = true;
        }

        ~IntervalEnumerator()
        {
            Dispose(false);
        }

        public bool First()
        {
            if (_intervals != null)
            {
                Reset();
                return true;
            }
            return false;
        }

        public override void Clear()
        {
            _intervals = new double[_x, _y];

            Reset();
        }

        #endregion
    }
}
