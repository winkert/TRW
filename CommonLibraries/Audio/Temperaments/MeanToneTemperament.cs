using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    /// <summary>
    /// Mean Tone Temperament
    /// </summary>
    public class MeanToneTemperament : ITemperament
    {
        internal const double SyntonicComma = 21.506d;

        public double ReferenceFrequency { get; }
        public Pitch ReferencePitch { get; }
        public int ReferenceOctave { get; }

        public MeanToneTemperament()
            : this(Pitches.C, 327.04d, 4)
        {

        }

        public MeanToneTemperament(Pitch referencePitch, double referenceFrequency, int referenceOctave)
        {
            ReferencePitch = referencePitch;
            ReferenceFrequency = referenceFrequency;
            ReferenceOctave = referenceOctave;
        }

        public double GetFrequency(Pitch pitch, int octave)
        {
            /*
             * Start with C:
             *   The frequency of C is our reference point.
             *   Major Third (C to E):
             *   Multiply the frequency of C by the major third ratio (1.25, according to the harmonic series).
             *   This gives us the frequency of E.
             *   Major Second (D above C):
             *   Divide the major third size by two (using the square root operation).
             *   The square root of 1.25 is approximately 1.118033988749895.
             *   Multiply the frequency of C by this value to find D.
             *   Continue the Scale:
             *   Multiply the frequency of D by the major second size to get E.
             *   Calculate F by multiplying E by the major second size.
             *   Complete the scale by finding G (major second above F) and A (major third above F).
             */

            Intervals interval = PitchEngine.GetInterval(ReferencePitch, pitch, TemperamentStyles.MeanToneTemperament);
            double octaveMultiplier = PitchEngine.GetOctaveMultiplier(ReferenceOctave, octave);

            Interval thisInterval = Interval.GetInterval(interval, TemperamentStyles.MeanToneTemperament);

            double intervalMultiplier = thisInterval.MeantoneRatio;

            return ReferenceFrequency * intervalMultiplier * octaveMultiplier; ;
        }

        public double GetCents(Interval interval)
        {
            return (interval.MeantoneRatio * 100d) * (SyntonicComma/4d);
        }
    }
}
