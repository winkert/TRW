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
        DiminishedSecond = 0,
        /// <summary>
        /// Diatonic Semitone
        /// </summary>
        MinorSecond = 1, 
        AugmentedUnison = 1,
        MajorSecond = 2,
        DiminishedThird = 2,
        MinorThird = 3, 
        /// <summary>
        /// Augmented Second is "sonically equivalent" to Minor Third in Equal Temperament
        /// </summary>
        AugmentedSecond = 3,
        MajorThird = 4, 
        DiminishedFourth = 4,
        Fourth = 5,
        AugmentedThird = 5,
        /// <summary>
        /// Tritone
        /// </summary>
        AugmentedFourth = 6, 
        DiminishedFifth = 6,
        DiminishedSixth = 7,
        /// <summary>
        /// Perfect Fifth
        /// </summary>
        Fifth = 7, 
        AugmentedFifth = 8,
        MinorSixth = 8, 
        /// <summary>
        /// Diminshed Seventh is "sonically equivalent" to Major Sixth in Equal Temperament
        /// </summary>
        DiminishedSeventh = 9,
        MajorSixth = 9,
        MinorSeventh = 10, 
        AugmentedSixth = 10,
        MajorSeventh = 11, 
        DiminishedOctave = 11,
        Octave = 12,
        AugmentedSeventh = 12
    }
}