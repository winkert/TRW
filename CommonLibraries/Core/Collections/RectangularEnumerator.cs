using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Core
{
    public class RectangularEnumerator<T> : RectangularEnumeratorBase<T> where T : class, IEquatable<T>, new()
    {
        #region Fields
        private bool _disposed;
        private readonly RectangularCollection<T> _parentCollection;
        private T[,] _items;
        Position _position;
        #endregion

        #region Constructors
        public RectangularEnumerator(RectangularCollection<T> collection, int x, int y)
            : base(x, y)
        {
            _parentCollection = collection;
            _items = new T[x, y];
            _position = new Position(_indexX, _indexY);
        }
        #endregion

        #region Properties
        public override T Current
        {
            get
            {
                if (_indexX > -1 && _indexY > -1
                    && _indexX < _x && _indexY < _y)
                {
                    return this[_indexX, _indexY];
                }
                else
                    return null;
            }
            set
            {
                this[_indexX, _indexY] = value;
            }
        }

        public override T this[int x, int y]
        {
            get
            {
                if (WithinRange(x, y))
                    return _items[x, y];
                return null;
            }
            set
            {
                if (WithinRange(x, y))
                    _items[x, y] = value;
                else
                    throw new IndexOutOfRangeException(string.Format("Incoming vector {0},{1} not within range {2},{3}", x, y, _x, _y));
            }
        }

        public override Position Position => _position;

        protected override T[,] Items => _items;
        #endregion

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
                _items = null;
            }
            _disposed = true;
        }

        ~RectangularEnumerator()
        {
            Dispose(false);
        }

        public override void Clear()
        {
            for (int x = 0; x < _x; x++)
                for (int y = 0; y < _y; y++)
                    _items[x, y] = null;

            Reset();
        }

        public RectangularEnumerator<T> Clone()
        {
            RectangularEnumerator<T> enumerator = new RectangularEnumerator<T>(_parentCollection, _x, _y);
            T[,] items = new T[_x, _y];
            for(int i = 0; i< _x; i++)
            {
                for(int j = 0; j < _y; j++)
                {
                    items[i, j] = this._items[i, j];
                }
            }

            enumerator._items = items;

            return enumerator;
        }
        #endregion

    }
}
