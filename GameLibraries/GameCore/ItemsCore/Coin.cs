using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.GameLibraries.GameCore
{
    [Serializable]
    public abstract class Coin:ItemBase
    {
        public Coin() : base("Coin", "Coin", 0.02m)
        {

        }

        public abstract int BaseValue { get; }

    }
}
