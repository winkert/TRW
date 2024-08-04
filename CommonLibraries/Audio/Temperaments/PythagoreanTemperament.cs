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

    }
}
