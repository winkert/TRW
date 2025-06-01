namespace TRW.CommonLibraries.Audio
{
    /// <summary>
    /// Intervals of pitches
    /// </summary>
    /// <remarks>This takes advantage of how enum is based on a number. It can only be based on a whole number.
    /// Augmented/Diminished intervals are numbered identical to their Major/Minor partners. When comparing enum values, they will be treated as the same.
    /// Each Temperament would need to account for this internally
    /// </remarks>
    public enum Intervals : short
    {
        Unknown = -1, 
        Unison = 0, 
        DiminishedSecond = 5,
        /// <summary>
        /// Diatonic Semitone
        /// </summary>
        MinorSecond = 10, 
        AugmentedUnison = 15,
        MajorSecond = 20,
        DiminishedThird = 25,
        MinorThird = 30, 
        /// <summary>
        /// Augmented Second is "sonically equivalent" to Minor Third in Equal Temperament
        /// </summary>
        AugmentedSecond = 35,
        MajorThird = 40, 
        DiminishedFourth = 45,
        Fourth = 50,
        AugmentedThird = 55,
        /// <summary>
        /// Tritone
        /// </summary>
        AugmentedFourth = 60, 
        DiminishedFifth = 65,
        DiminishedSixth = 75,
        /// <summary>
        /// Perfect Fifth
        /// </summary>
        Fifth = 70, 
        AugmentedFifth = 85,
        MinorSixth = 80, 
        /// <summary>
        /// Diminshed Seventh is "sonically equivalent" to Major Sixth in Equal Temperament
        /// </summary>
        DiminishedSeventh = 95,
        MajorSixth = 90,
        MinorSeventh = 100, 
        AugmentedSixth = 105,
        MajorSeventh = 110, 
        DiminishedOctave = 115,
        Octave = 120,
        AugmentedSeventh = 125
    }
}