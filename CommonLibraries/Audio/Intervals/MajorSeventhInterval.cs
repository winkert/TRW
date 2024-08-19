using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    public class MajorSeventhInterval : Interval
    {
        public MajorSeventhInterval(TemperamentStyles temperament) : base(temperament)
        {
        }

        public override Intervals IntervalEnum => Intervals.MajorSeventh;

        public override double PythagoreanRatio => Math.Pow(3, 5) / Math.Pow(2, 7);
        public override double MeantoneRatio => 1.25;

        public override bool Major => true;

        public override bool Perfect => true;
    }
}
