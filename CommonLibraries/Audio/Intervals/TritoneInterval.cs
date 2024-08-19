using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    public class TritoneInterval : Interval
    {
        public TritoneInterval(TemperamentStyles temperament) : base(temperament)
        {
        }

        public override Intervals IntervalEnum => Intervals.AugmentedFourth;

        public override double PythagoreanRatio => Math.Pow(3, 6) / Math.Pow(2, 9);
        public override double MeantoneRatio => 25d/18d;

        public override bool Major => false;

        public override bool Perfect => false;
    }
}
