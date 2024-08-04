using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.GameLibraries.Character.DnD
{
    [Serializable]
    public class DnDBackgroundBond : Feature
    {
        public DnDBackgroundBond(string name, string description) : base(name, description)
        {
        }
    }
}
