using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Data.Core
{
    public interface IDataTable<DataRow> where DataRow : IDataRow
    {
        DataRow Current { get; }
        int Count { get; }
        CustomDataColumnCollection Columns { get; }
        bool First();
        bool Next();
    }
}
