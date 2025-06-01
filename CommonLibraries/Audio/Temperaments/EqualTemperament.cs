using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    /// <summary>
    /// Twelve Tone Equal Temperament
    /// </summary>
    public class EqualTemperament : ITemperament
    {
        public double KeyInterval => Math.Pow(2, 1d / 12d);
        public double ReferenceFrequency { get; }
        public Pitch ReferencePitch { get; }
        public int ReferenceOctave { get; }

        internal int ReferenceKey { get; private set; }

        public EqualTemperament()
            :this(Pitches.A, 440d, 4)
        {

        }
        public EqualTemperament(Pitch referencePitch, double referenceFrequency, int referenceOctave)
        {
            ReferencePitch = referencePitch;
            ReferenceFrequency = referenceFrequency;
            ReferenceOctave = referenceOctave;
            ReferenceKey = GetKeyboardKeyFromPitchOctave(ReferencePitch, ReferenceOctave);
        }

        public double GetFrequency(Pitch pitch, int octave)
        {
            int keyboardKey = GetKeyboardKeyFromPitchOctave(pitch, octave);
            return ReferenceFrequency * Math.Pow(KeyInterval, keyboardKey - ReferenceKey);
        }


        public int GetKeyboardKeyFromPitchOctave(Pitch pitch, int octave)
        {
            int octaveBase = octave * 12;
            int distanceFromRef = ReferencePitch - pitch;

            return octaveBase - distanceFromRef + 1;
        }

        double ITemperament.GetCents(Interval interval)
        {
            // Equal Temperament will always be 100 cents per interval/step
            return (double)interval.IntervalEnum * 100d;
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

            return Interval.GetInterval(interval, TemperamentStyles.EqualTemperament);
        }
    }
}
