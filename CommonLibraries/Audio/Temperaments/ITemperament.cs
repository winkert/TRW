using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    public interface ITemperament
    {
        double ReferenceFrequency { get; }
        Pitch ReferencePitch { get; }
        int ReferenceOctave { get; }

        double GetFrequency(Pitch pitch, int octave);
    }
}
