using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using TRW.CommonLibraries.Data.Core;

namespace TRW.CommonLibraries.Data
{
    public class DataCommand
    {
        CustomDataColumnCollection _columnsInCommand;
        private readonly string _commandText;
        DbCommand _dbCommand;
        DbParameterCollection _parameters;

        public DataCommand(DAL.DataConnector connector, string query)
        {
            _columnsInCommand = connector.GetSchemaData(query);
            _dbCommand = connector.CreateCommand();
            _commandText = query;
            
            InitializeCommand();
        }


        private void InitializeCommand()
        {
            _dbCommand.CommandText = _commandText;
        }
    }
}
