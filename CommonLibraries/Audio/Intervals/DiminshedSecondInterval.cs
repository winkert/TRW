using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    public class DiminshedSecondInterval : Interval
    {
        public DiminshedSecondInterval(TemperamentStyles temperament) : base(temperament)
        {
        }

        public override Intervals IntervalEnum => Intervals.DiminishedSecond;

        public override double PythagoreanRatio => 1d;
        public override double MeantoneRatio => 128d/125d;

        public override bool Major => true;

        public override bool Perfect => true;
    }
}
