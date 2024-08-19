using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    public abstract class Interval : IEquatable<Interval>
    {
        public abstract Intervals IntervalEnum { get; }
        public virtual Intervals DiminishedInterval => (Intervals)(-1 * (int)IntervalEnum);
        public abstract double PythagoreanRatio { get; }
        public abstract double MeantoneRatio { get; }
        public abstract bool Major { get; }
        public abstract bool Perfect { get; }

        /// <summary>
        /// Semitones
        /// </summary>
        public virtual int HalfSteps => Math.Abs((int)IntervalEnum);

        public TemperamentStyles TemperamentStyle { get; set; }

        public Interval(TemperamentStyles temperament)
        {
            TemperamentStyle = temperament;
        }


        public override bool Equals(object obj)
        {
            return Equals(obj as Interval);
        }

        public bool Equals(Interval other)
        {
            return other != null &&
                   IntervalEnum == other.IntervalEnum &&
                   HalfSteps == other.HalfSteps &&
                   TemperamentStyle == other.TemperamentStyle;
        }

        public override int GetHashCode()
        {
            int hashCode = 1820241736;
            hashCode = hashCode * -1521134295 + IntervalEnum.GetHashCode();
            hashCode = hashCode * -1521134295 + HalfSteps.GetHashCode();
            hashCode = hashCode * -1521134295 + TemperamentStyle.GetHashCode();
            return hashCode;
        }


        public static Interval GetInterval(Intervals intervals, TemperamentStyles temperament)
        {
            switch(intervals)
            {
                case Intervals.Unison:
                    return new UnisonInterval(temperament);
                case Intervals.MinorSecond:
                    return new MinorSecondInterval(temperament);
                case Intervals.MajorSecond:
                    return new MajorSecondInterval(temperament);
                case Intervals.MinorThird:
                    return new MinorThirdInterval(temperament);
                case Intervals.MajorThird:
                    return new MajorThirdInterval(temperament);
                case Intervals.Fourth:
                    return new FourthInterval(temperament);
                case Intervals.AugmentedFourth:
                    return new TritoneInterval(temperament);
                case Intervals.Fifth:
                    return new FifthInterval(temperament);
                case Intervals.MinorSixth:
                    return new MinorSixthInterval(temperament);
                case Intervals.MajorSixth:
                    return new MajorSixthInterval(temperament);
                case Intervals.MinorSeventh:
                    return new MinorSeventhInterval(temperament);
                case Intervals.MajorSeventh:
                    return new MajorSeventhInterval(temperament);
                case Intervals.Octave:
                    return new OctaveInterval(temperament);
                default:
                    throw new ArgumentException($"Unexpected Interval [{intervals}]", "intervals");
            }
        }

        #region Operators
        public static bool operator ==(Interval left, Interval right)
        {
            return EqualityComparer<Interval>.Default.Equals(left, right);
        }

        public static bool operator !=(Interval left, Interval right)
        {
            return !(left == right);
        }

        #endregion
    }
}
