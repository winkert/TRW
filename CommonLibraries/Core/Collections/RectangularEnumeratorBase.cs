using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Core
{
    public abstract class RectangularEnumeratorBase<T> : IEnumerator<T> where T :IEquatable<T>
    {
        #region Fields
        protected int _indexX;
        protected int _indexY;
        protected readonly int _x;
        protected readonly int _y;
        #endregion

        #region Constructor
        public RectangularEnumeratorBase(int x, int y)
        {
            _x = x;
            _y = y;
            _indexX = 0;
            _indexY = 0;
        }
        #endregion

        #region Properties
        protected abstract T[,] Items { get; }
        public abstract T Current { get; set; }

        object IEnumerator.Current => Current;

        public int Count => Items.Length;

        public abstract T this[int x, int y] { get; set; }

        public abstract Position Position { get; }
        #endregion

        #region Publics
        public abstract void Clear();

        public abstract void Dispose();

        /// <summary>
        /// Moves across then down carriage return style e.g
        ///     S.......>
        ///     >.......>
        ///     >.......E
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveNext()
        {
            _indexX++;
            if (_indexX >= _x)
            {
                _indexY++;
                if (_indexY < _y)
                {
                    _indexX = 0;
                }
                else
                {
                    return false;
                }
            }

            Position.UpdatePosition(_indexX, _indexY);
            return true;
        }

        public void Reset()
        {
            _indexX = 0;
            _indexY = 0;

            Position.UpdatePosition(_indexX, _indexY);
        }

        public Tuple<int, int> Find(T item)
        {
            // TODO: Find a way to change this class to use a HashTable or some other potentially faster process of seeking

            for (int y = 0; y < _y; y++)
                for (int x = 0; x < _x; x++)
                {
                    if (Items[x, y] == null)
                        continue;
                    if (Items[x, y].Equals(item))
                        return new Tuple<int, int>(x, y);
                }

            return null;
        }

        public void GoTo(int x, int y)
        {
            if (WithinRange(x, y))
                throw new IndexOutOfRangeException(string.Format("Incoming vector {0},{1} not within range {2},{3}", x, y, _x, _y));

            _indexX = x;
            _indexY = y;
            Position.UpdatePosition(_indexX, _indexY);
        }

        public bool WithinRange(int x, int y)
        {
            if (x < _x && y < _y && x > -1 && y > -1)
                return true;
            return false;
        }

        #endregion

    }
}
