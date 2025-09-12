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

    }
}
