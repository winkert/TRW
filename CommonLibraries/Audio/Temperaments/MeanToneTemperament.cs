using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    /// <summary>
    /// Quarter-Comma Mean Tone Temperament
    /// </summary>
    public class MeanToneTemperament : ITemperament
    {
        internal readonly static double SyntonicComma = 1200 * Math.Log2(SyntonicCommaRatio);
        internal const double SyntonicCommaRatio = 81d/80d;

        public double ReferenceFrequency { get; }
        public Pitch ReferencePitch { get; }
        public int ReferenceOctave { get; }

        public MeanToneTemperament()
            : this(Pitches.C, 327.04d, 4) // Baroque/Bach
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

            int halfStepDifference = (octave - ReferenceOctave) * 12 + (pitch.HalfStep - ReferencePitch.HalfStep);
            double ratio = Math.Pow(2, halfStepDifference / 12.0) * Math.Pow(2, -SyntonicComma / 4800.0 * halfStepDifference);
            return ReferenceFrequency * ratio;

        }

        public double GetCents(Interval interval)
        {
            return (interval.MeantoneRatio * 100d) * (SyntonicComma/4d);
        }

        public double GetCents(Pitch from, Pitch to)
        {
            double freq1 = GetFrequency(from, from.Octave);
            double freq2 = GetFrequency(to, to.Octave);

            return 1200 * Math.Log2(freq1 / freq2);
        }

        public Interval GetInterval(Pitch pitchStart, Pitch pitchEnd)
        {
            Intervals interval = Intervals.Unknown;
            int steps = PitchEngine.GetSemitones(pitchStart, pitchEnd);

            if (Enum.IsDefined(typeof(Intervals), (short)steps))
                interval = (Intervals)steps; // should work

            /*
             * Where Mean Tone differs from temperaments like Equal and Pythagorean is that in Mean Tone,
             * Augmented and Diminished intervals may not be the same as Major and Minor intervals
             */

            return Interval.GetInterval(interval, TemperamentStyles.MeanToneTemperament);
        }


    }
}
