using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    public class FifthInterval : Interval
    {
        public FifthInterval(TemperamentStyles temperament) : base(temperament)
        {
        }

        public override Intervals IntervalEnum => Intervals.Fifth;

        public override double PythagoreanRatio => Math.Pow(3, 1) / Math.Pow(2, 1);

        public override bool Major => true;

        public override bool Perfect => true;
    }
}
