using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Data.Core
{
    public interface IDataRow
    {
        object this[int col] { get; set; }
        object this[string colName] { get;set; }
    }
}
