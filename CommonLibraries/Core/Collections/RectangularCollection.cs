using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Core
{
    /// <summary>
    /// Fixed length collection with two non-unique dimensions
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RectangularCollection<T> : IMatrix<T> where T : class, IEquatable<T>, new()
    {
        #region Fields
        protected readonly RectangularEnumerator<T> _enumerator;
        private readonly Tuple<int, int> _size;
        #endregion

        #region Constructors
        public RectangularCollection(int x, int y)
        {
            _enumerator = new RectangularEnumerator<T>(this, x, y);
            _size = new Tuple<int, int>(x, y);
        }
        #endregion

        #region Properties
        protected virtual bool ThrowIndexExceptions => true;
        public T Current
        {
            get => _enumerator.Current;
            set => _enumerator.Current = value;
        }

        public int Count => _enumerator.Count;

        public virtual bool IsReadOnly => false;

        public int Width => _size.Item1;

        public int Height => _size.Item2;

        public T this[int x, int y]
        {
            get
            {
                if ((x < 0 || x >= Width) || (y < 0 || y >= Height))
                {
                    if (!ThrowIndexExceptions)
                    {
                        return null;
                    }
                        
                }
                return _enumerator[x, y]; 
            }
            set 
            {
                _enumerator[x, y] = value; 
            }
        }

        public Position Position => _enumerator.Position;
        #endregion

        #region Publics
        public bool CellExists(int x, int y)
        {
            return _enumerator.WithinRange(x, y);
        }

        /// <summary>
        /// Go to the first cell in the collection
        /// </summary>
        /// <returns></returns>
        public bool First()
        {
            _enumerator.Reset();
            if (_enumerator.Count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Go to the first non-null cell in the collection
        /// </summary>
        /// <returns>False if all cells are null</returns>
        public bool FirstNonNull()
        {
            _enumerator.Reset();
            do
            {
                if (_enumerator.Current != null)
                    return true;
            } while (_enumerator.MoveNext());
            return false;
        }

        public bool Next()
        {
            return _enumerator.MoveNext();
        }

        public void Fill()
        {
            _enumerator.Reset();
            do
            {
                _enumerator.Current = new T();
            } while (_enumerator.MoveNext());
        }

        public void Clear()
        {
            _enumerator.Clear();
        }

        public Tuple<int, int> Find(T item)
        {
            return _enumerator.Find(item);
        }

        public void GoTo(int x, int y)
        {
            _enumerator.GoTo(x, y);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _enumerator.Clone();
        }

        public IMatrix<T> Clone()
        {
            // Create a new instance of the matrix with the same dimensions
            IMatrix<T> clonedMatrix = new RectangularCollection<T>(Width, Height);

            // Copy each element from the current matrix to the cloned matrix
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    clonedMatrix[x, y] = this[x, y];
                }
            }

            return clonedMatrix;
        }

        public void CopyFrom(IMatrix<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (source.Width != Width || source.Height != Height)
            {
                throw new ArgumentException("Source matrix dimensions do not match.");
            }

            // Assuming the dimensions of the source and current matrix are the same
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    this[x, y] = source[x, y];
                }
            }
        }

        public IMatrix<T> CreateNewEmpty()
        {
            return new RectangularCollection<T>(Width, Height);
        }
        #endregion
    }
}
