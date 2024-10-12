using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    /// <summary>
    /// Werckmeister Temperament (III)
    /// </summary>
    public class WerckmeisterTemperament : ITemperament
    {
        public double ReferenceFrequency { get; }
        public Pitch ReferencePitch { get; }
        public int ReferenceOctave { get; }

        public WerckmeisterTemperament()
            : this(Pitches.A, 440d, 4)
        {

        }

        public WerckmeisterTemperament(Pitch referencePitch, double referenceFrequency, int referenceOctave)
        {
            ReferencePitch = referencePitch;
            ReferenceFrequency = referenceFrequency;
            ReferenceOctave = referenceOctave;
        }

        public double GetFrequency(Pitch pitch, int octave)
        {
            throw new NotImplementedException();
        }

        public double GetCents(Interval interval)
        {
            throw new NotImplementedException();
        }
    }
}
