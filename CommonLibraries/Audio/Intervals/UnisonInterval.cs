using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    public class UnisonInterval : Interval
    {
        public UnisonInterval(TemperamentStyles temperament) : base(temperament)
        {
        }

        public override Intervals IntervalEnum => Intervals.Unison;

        public override double PythagoreanRatio => 1d;
        public override double MeantoneRatio => 1d;

        public override bool Major => true;

        public override bool Perfect => true;
    }
}
