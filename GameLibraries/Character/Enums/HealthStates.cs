using System.ComponentModel;

namespace TRW.GameLibraries.Character
{
    public enum HealthStates
    {
        Dead = -1,
        Unconscious = 0,
        [Description("Mortally Wounded")]
        MortallyWounded = 1,
        [Description("Severely Wounded")]
        SeverelyWounded = 2,
        Wounded = 3,
        [Description("Full Health")]
        FullHealth = 4
    }
}