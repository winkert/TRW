using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TRW.CommonLibraries.Data.Core;

namespace TRW.CommonLibraries.Data
{
    public interface IConnectedDataTable<DataRow> where DataRow : Core.IDataRow
    {
        DataRow Current { get; }
        int Count { get; }
        CustomDataColumnCollection Columns { get; }
        int Fetch(string query);
        bool First();
        bool Next();
    }
}
