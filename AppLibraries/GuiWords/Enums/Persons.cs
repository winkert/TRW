using System.ComponentModel;

namespace TRW.AppLibraries.GuiWords
{
    public enum Persons
    {
        [Description("1st Person")]
        FirstPerson = 1,
        [Description("2nd Person")]
        SecondPerson = 2,
        [Description("3rd Person")]
        ThirdPerson = 3,
        [Description("None")]
        None = 4
    }
}
