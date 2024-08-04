using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonGenerator
{
    public interface IDungeonComponentDetail:TRW.Apps.TrwAppsBase.IDetailSubform<IDungeonComponentBase>
    {
        void FillParentListView(DataGridView listview);
        void Remove(IDungeonComponentBase itemToRemove);
    }
}
