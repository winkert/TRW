using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Core
{
    public interface IMatrix<T>
    {
        T Current { get; }
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
    }
}
