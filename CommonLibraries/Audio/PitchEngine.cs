using System;

namespace TRW.CommonLibraries.Audio
{
    public static class PitchEngine
    {

        public static double GetFrequency(Pitch key, int octave)
        {
            return GetFrequency(key, octave, TemperamentStyles.EqualTemperament);
        }
        public static double GetFrequency(Pitch key, int octave, TemperamentStyles temperament)
        {
            ITemperament engine = TemperamentFactory.GetTemperament(temperament);

            return engine.GetFrequency(key, octave);
        }

        public static double GetOctaveMultiplier(int octaveFrom, int octaveTo)
        {
            if (octaveFrom == octaveTo)
                return 1d;

            return Math.Pow(2, octaveTo - octaveFrom);
        }

        public static Intervals GetInterval(Pitch keyFrom, Pitch keyTo)
        {
            return GetInterval(keyFrom, keyTo, TemperamentStyles.EqualTemperament);
        }
        public static Intervals GetInterval(Pitch keyFrom, Pitch keyTo, TemperamentStyles temperament)
        {
            Intervals interval = Intervals.Unknown;
            int steps;

            switch (temperament)
            {
                case TemperamentStyles.EqualTemperament:
                case TemperamentStyles.PythagoreanTuning:
                    steps = GetSemitones(keyFrom, keyTo);

                    if (Enum.IsDefined(typeof(Intervals), (short)steps))
                        interval = (Intervals)steps; // should work
                    break;
                case TemperamentStyles.MeanToneTemperament:
                    // for the most part this is the same, but MeanTone will consider augmented/diminshed intervals as well
                    steps = GetSemitones(keyFrom, keyTo);
                    
                    break;
                case TemperamentStyles.WerckmeisterTemperament:
                    break;
            }

            return interval;
        }

        public static int GetSemitones(Pitch keyFrom, Pitch keyTo)
        {
            if (keyFrom == keyTo)
                return 0;
            else if (keyFrom < keyTo)
                return keyTo - keyFrom;
            else
                return keyTo - keyFrom + 12;

        }
    }

}
