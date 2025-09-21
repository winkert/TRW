using System;

namespace TRW.CommonLibraries.Core
{
    public interface IMatrix<T>
    {
        T Current { get; }
        int Width { get; }
        int Height { get; }

        T this[int x, int y]  { get; set; }

        bool CellExists(int x, int y);

        /// <summary>
        /// Go to first element in Matrix
        /// </summary>
        /// <returns></returns>
        bool First();

        /// <summary>
        /// Go to Next elemenet in Matrix
        /// </summary>
        /// <returns></returns>
        bool Next();
        IMatrix<T> Clone();
        void CopyFrom(IMatrix<T> source);
        IMatrix<T> CreateNewEmpty();
    }
}
