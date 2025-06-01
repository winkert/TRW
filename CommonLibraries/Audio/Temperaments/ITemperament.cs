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
        double GetCents(Interval interval);
        double GetCents(Pitch from, Pitch to);
        Interval GetInterval(Pitch pitchStart, Pitch pitchEnd);
    }
}
