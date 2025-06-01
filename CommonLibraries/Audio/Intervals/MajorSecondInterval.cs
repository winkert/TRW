using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    public class MajorSecondInterval : Interval
    {
        public MajorSecondInterval(TemperamentStyles temperament) : base(temperament)
        {
        }

        public override Intervals IntervalEnum => Intervals.MajorSecond;

        public override double PythagoreanRatio => Math.Pow(3, 2) / Math.Pow(2, 3);
        public override double MeantoneRatio => 125d/96d;

        public override bool Major => true;

        public override bool Perfect => false;
    }
}
