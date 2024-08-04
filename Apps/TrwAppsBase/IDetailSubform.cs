using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.Apps.TrwAppsBase
{
    public interface IDetailSubform<P> where P: class
    {
        void Clear();
        void CopyNew();
        void LoadDetailScreen(P property, string filePath);
        void SetEditMode(bool editMode);
        bool ValidateScreen();
        P Save();
    }
}
