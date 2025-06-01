using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    public class MinorSixthInterval : Interval
    {
        public MinorSixthInterval(TemperamentStyles temperament) : base(temperament)
        {
        }

        public override Intervals IntervalEnum => Intervals.MinorSixth;

        public override double PythagoreanRatio => Math.Pow(2, 7) / Math.Pow(3, 4);
        public override double MeantoneRatio => 1.25;

        public override bool Major => false;

        public override bool Perfect => false;
    }
}
