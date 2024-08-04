using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGenerator
{
    public interface IDungeonComponentBase
    {

        string Name { get; set; }
        ComponentType ComponentType { get; }
        Guid UniqueIdentifier { get; }

        string Serialize();
        void Deserialize(string serialized);

    }
}
