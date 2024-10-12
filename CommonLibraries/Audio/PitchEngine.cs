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

        public static double GetFrequency(Pitch key, TemperamentStyles temperament, int octave)
        {
            ITemperament t = TemperamentFactory.GetTemperament(temperament);
            // frequency = startFrequency * 2^(intervalcents/1200)

            Interval i = Interval.GetInterval(GetInterval(t.ReferencePitch, key), temperament);

            double f = t.ReferenceFrequency * Math.Pow(2, (i.Cents / 1200));

            // transpose the frequence if needed
            return Transpose(f, t.ReferenceOctave, octave);
        }

        public static double Transpose(double frequency, int startOctave, int targetOctave)
        {
            if (startOctave == targetOctave)
                return frequency;
            else if (startOctave < targetOctave)
                return frequency * (2 * (targetOctave - startOctave));
            else
                return frequency / (2 * (targetOctave - startOctave));

        }
    }

}
