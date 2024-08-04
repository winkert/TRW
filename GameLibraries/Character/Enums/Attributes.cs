using System.ComponentModel;

namespace TRW.GameLibraries.Character
{
    public enum Attributes
    {
        None,
        [Description("Player's Choice")]
        Players_Choice,
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }
}
