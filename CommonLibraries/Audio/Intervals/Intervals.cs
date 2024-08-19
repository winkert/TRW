namespace TRW.CommonLibraries.Audio
{
    public enum Intervals : short
    {
        Unknown = -1, 
        Unison = 0, 
        //DiminishedSecond = 0
        AugmentedUnison = -1,
        /// <summary>
        /// Diatonic Semitone
        /// </summary>
        MinorSecond = 1, 
        DiminishedThird = -2,
        MajorSecond = 2,
        /// <summary>
        /// Augmented Second is "sonically equivalent" to Minor Third in Equal Temperament
        /// </summary>
        AugmentedSecond = -3,
        MinorThird = 3, 
        DiminishedFourth = -4,
        MajorThird = 4, 
        AugmentedThird = -5,
        Fourth = 5,
        /// <summary>
        /// Tritone
        /// </summary>
        AugmentedFourth = 6, 
        //DiminishedFifth = 6,
        /// <summary>
        /// Perfect Fifth
        /// </summary>
        Fifth = 7, 
        DiminishedSixth = -7,
        MinorSixth = 8, 
        AugmentedFifth = -8,
        MajorSixth = 9,
        /// <summary>
        /// Diminshed Seventh is "sonically equivalent" to Major Sixth in Equal Temperament
        /// </summary>
        DiminishedSeventh = -9,
        MinorSeventh = 10, 
        AugmentedSixth = -10,
        MajorSeventh = 11, 
        DiminishedOctave = -11,
        Octave = 12,
        AugmentedSeventh = -12
    }
}