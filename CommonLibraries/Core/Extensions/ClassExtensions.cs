using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Core
{
    public static class ClassExtensions
    {
        #region Random
        /// <summary>
        /// Random decimal value between -1 and 1
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static decimal NextDecimal(this Random r)
        {
            return NextDecimal(r, -1, 1);
        }

        public static decimal NextDecimal(this Random r, decimal min, decimal max)
        {
            return min + (Convert.ToDecimal(r.NextDouble()) * (max - min));
        }
        #endregion
    }
}
