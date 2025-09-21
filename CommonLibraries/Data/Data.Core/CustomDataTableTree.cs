using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRW.CommonLibraries.Core;

namespace TRW.CommonLibraries.Data.Core
{
    public class CustomDataTableTree : SearchTree<CustomDataRow>
    {
        public CustomDataTableTree() : base()
        {
            TraversalStyle = TraversalStyles.InOrder;
        }

        public CustomDataRow FoundRow { get; private set; }

        public bool FindRow(CustomDataRow row, out int index)
        {
            index = -1;
            if (Find(row, out Node<CustomDataRow> node))
            {
                FoundRow = node.Data;
                index = FoundRow._myIndex;
                return true;
            }
            FoundRow = null;
            return false;
        }

    }
}
