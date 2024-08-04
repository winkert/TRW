using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    public class MajorSixthInterval : Interval
    {
        public MajorSixthInterval(TemperamentStyles temperament) : base(temperament)
        {
        }

        public override Intervals IntervalEnum => Intervals.MajorSixth;

        public override double PythagoreanRatio => Math.Pow(3, 3) / Math.Pow(2, 4);

        public override bool Major => true;

        public override bool Perfect => false;
    }
}
