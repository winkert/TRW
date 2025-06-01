using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    public class MinorThirdInterval : Interval
    {
        public MinorThirdInterval(TemperamentStyles temperament) : base(temperament)
        {
        }

        public override Intervals IntervalEnum => Intervals.MinorThird;

        public override double PythagoreanRatio => Math.Pow(2, 5) / Math.Pow(3, 3);
        public override double MeantoneRatio => 32d/27d;

        public override bool Major => false;

        public override bool Perfect => false;
    }
}
