using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    public class MinorSeventhInterval : Interval
    {
        public MinorSeventhInterval(TemperamentStyles temperament) : base(temperament)
        {
        }

        public override Intervals IntervalEnum => Intervals.MinorSeventh;

        public override double PythagoreanRatio => Math.Pow(2, 4) / Math.Pow(3, 2);

        public override bool Major => false;

        public override bool Perfect => false;
    }
}
