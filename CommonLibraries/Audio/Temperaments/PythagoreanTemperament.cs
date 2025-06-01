using System;
using System.Collections.Generic;
using System.Text;
using TRW.CommonLibraries.Core;

namespace TRW.CommonLibraries.Audio
{
    /// <summary>
    /// Pythagorean Temperament
    /// </summary>
    public class PythagoreanTemperament : ITemperament
    {
        public double ReferenceFrequency { get; }
        public Pitch ReferencePitch { get; }
        public int ReferenceOctave { get; }

        public PythagoreanTemperament()
            : this(Pitches.A, 440d, 4)
        {

        }

        public PythagoreanTemperament(Pitch referencePitch, double referenceFrequency, int referenceOctave)
        {
            ReferencePitch = referencePitch;
            ReferenceFrequency = referenceFrequency;
            ReferenceOctave = referenceOctave;
        }

        public double GetFrequency(Pitch pitch, int octave)
        {
            Intervals interval = PitchEngine.GetInterval(ReferencePitch, pitch);
            double octaveMultiplier = PitchEngine.GetOctaveMultiplier(ReferenceOctave, octave);

            Interval thisInterval = Interval.GetInterval(interval, TemperamentStyles.PythagoreanTuning);

            double intervalMultiplier = thisInterval.PythagoreanRatio;

            return ReferenceFrequency * intervalMultiplier * octaveMultiplier;;
        }

        public double GetCents(Interval interval)
        {
            return Math.Log(interval.PythagoreanRatio, 2d) * 1200;
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

            if (Enum.IsDefined(typeof(Intervals), (short)(steps * 10)))
                interval = (Intervals)(steps * 10); // should work

            return Interval.GetInterval(interval, TemperamentStyles.PythagoreanTuning);
        }
    }
}
