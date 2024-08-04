using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    public class MajorThirdInterval : Interval
    {
        public MajorThirdInterval(TemperamentStyles temperament) : base(temperament)
        {
        }

        public override Intervals IntervalEnum => Intervals.MajorThird;

        public override double PythagoreanRatio => Math.Pow(3, 4) / Math.Pow(2, 6);

        public override bool Major => true;

        public override bool Perfect => false;
    }
}
