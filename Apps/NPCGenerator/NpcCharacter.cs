using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.Apps.NPCGenerator
{
    internal class NpcCharacter : TRW.GameLibraries.Character.CharacterBase
    {
        public override int CharacterLevel => 1;
        protected override int MinimumAttributeSum => 50;

        internal void InitializeCharacter()
        {
            int[] attributes = RollAttributes();
            for(int i = 0; i< TotalAttributes; i++)
            {
                _attributes.Add(GetAttribute(i), attributes[i]);
            }
        }

        protected override void ApplyHealthChange(int healthChange)
        {
            throw new NotImplementedException();
        }
    }
}
