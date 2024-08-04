using System.ComponentModel;

namespace TRW.GameLibraries.Character
{
    public enum Skills
    {
        [Description("Player's Choice")]
        Players_Choice,
        Athletics,
        Acrobatics,
        [Description("Sleight of Hand")]
        Sleight_of_Hand,
        Stealth,
        Arcana,
        History,
        Investigation,
        Nature,
        Religion,
        [Description("Animal Handling")]
        Animal_Handling,
        Insight,
        Medicine,
        Perception,
        Survival,
        Deception,
        Intimidation,
        Performance,
        Persuassion
    }
}
