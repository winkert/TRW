using System.ComponentModel;

namespace TRW.GameLibraries.Character
{
    public enum ProficiencyTypes
    {
        Unkown,
        Weapon,
        Armor,
        Tool,
        [Description("Musical Instrument")]
        Musical_Instrument,
        Skill,
        Language,
        [Description("Saving Throws")]
        Saving_Throws
    }
}
