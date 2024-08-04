using System;

namespace TRW.GameLibraries.GameCore
{
    [Flags]
    public enum DiceOptions : byte
    {
        None = 0,
        DropLowest = 2,
        ExplodingDice = 4
    }
}