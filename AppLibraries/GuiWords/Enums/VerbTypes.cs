using System.ComponentModel;

namespace TRW.AppLibraries.GuiWords
{
    public enum VerbTypes
    {
        [Description("Impersonal verbs")]
        Impers = 1,
        [Description("The verb \"To Be\"")]
        To_Be = 2,
        [Description("Semideponent verbs")]
        Semidep = 3,
        [Description("Intransitive verbs")]
        Intrans = 4,
        [Description("Unknown")]
        Unknown = 5,
        [Description("Verbs without a present stem")]
        Perfdef = 6,
        [Description("Verbs that derive from the verb \"To Be\"")]
        To_Being = 7,
        [Description("Transitive verbs")]
        Trans = 8,
        [Description("Deponent verbs")]
        Dep = 9,

    }
}
