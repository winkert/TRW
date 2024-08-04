using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    public class MinorSecondInterval : Interval
    {
        public MinorSecondInterval(TemperamentStyles temperament) : base(temperament)
        {
        }

        public override Intervals IntervalEnum => Intervals.MinorSecond;

        public override double PythagoreanRatio => Math.Pow(2, 8) / Math.Pow(3, 5);

        public override bool Major => false;

        public override bool Perfect => false;
    }
}
