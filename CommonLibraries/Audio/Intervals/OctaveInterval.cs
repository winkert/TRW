using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    public class OctaveInterval : Interval
    {
        public OctaveInterval(TemperamentStyles temperament) : base(temperament)
        {
        }

        public override Intervals IntervalEnum => Intervals.Octave;

        public override double PythagoreanRatio => 2d;
        public override double MeantoneRatio => 2d;

        public override bool Major => true;

        public override bool Perfect => true;
    }
}
