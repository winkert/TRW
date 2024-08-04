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
            Intervals interval = Intervals.Unknown;

            int steps;
            if (keyFrom == keyTo)
                steps = 0;
            else if (keyFrom < keyTo)
                steps = keyTo - keyFrom;
            else
                steps = keyTo - keyFrom + 12;
            
            if (Enum.IsDefined(typeof(Intervals), (short)steps))
                interval = (Intervals)steps; // should work

            return interval;
        }
    }

}
