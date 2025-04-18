using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.GameLibraries.Character.DnD
{
    [Serializable]
    public class DnDBackgroundPersonalityTrait : Feature
    {
        public DnDBackgroundPersonalityTrait():base() { }
        public DnDBackgroundPersonalityTrait(string name, string description) : base(name, description)
        {
        }
    }
}
