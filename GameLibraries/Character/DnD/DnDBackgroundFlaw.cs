using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.GameLibraries.Character.DnD
{
    [Serializable]
    public class DnDBackgroundFlaw : Feature
    {
        public DnDBackgroundFlaw() :base() { }
        public DnDBackgroundFlaw(string name, string description) : base(name, description)
        {
        }
    }
}
