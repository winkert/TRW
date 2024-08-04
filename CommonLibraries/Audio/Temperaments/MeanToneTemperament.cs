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
        public double ReferenceFrequency { get; }
        public Pitch ReferencePitch { get; }
        public int ReferenceOctave { get; }

        public MeanToneTemperament()
            : this(Pitches.A, 440d, 4)
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
            throw new NotImplementedException();
        }
    }
}
