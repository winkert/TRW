using System.ComponentModel;

namespace TRW.AppLibraries.GuiWords
{
    public enum AdjectiveTypes
    {
        [Description("Positive")]
        POS = 1,
        [Description("Comparative")]
        COMP = 2,
        [Description("Superlative")]
        SUPER = 3,
        [Description("Personal")]
        PERS = 4,
        [Description("Reflexive")]
        REFLEX = 5,
        [Description("Demonstrative")]
        DEMON = 6,
        [Description("Cardinal")]
        CARD = 7,
        [Description("Ordinal")]
        ORD = 8,
        [Description("Distributive")]
        DIST = 9,
        [Description("Adverbial")]
        ADVERB = 10,
        [Description("Indefinite")]
        INDEF = 11,
        [Description("Adjectival")]
        ADJECT = 12,
        [Description("Interrogative")]
        INTERR = 13,
        [Description("Relative")]
        REL = 14,
        [Description("Adjectives without changing stems")]
        ALL = 15,
    }
}
