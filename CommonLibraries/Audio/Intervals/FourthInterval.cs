using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    public class FourthInterval : Interval
    {
        public FourthInterval(TemperamentStyles temperament) : base(temperament)
        {
        }

        public override Intervals IntervalEnum => Intervals.Fourth;

        public override double PythagoreanRatio => Math.Pow(2, 2) / Math.Pow(3, 1);
        public override double MeantoneRatio => 1.25;

        public override bool Major => true;

        public override bool Perfect => true;
    }
}
