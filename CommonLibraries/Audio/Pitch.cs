using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    public class Pitch : IComparable<Pitch>
    {
        public string Name { get; }
        public int HalfStep { get; }

        public Pitch(string name, int halfStep)
        {
            Name = name;
            HalfStep = halfStep % 12;
        }

        public override bool Equals(object obj)
        {
            return obj is Pitch pitch &&
                   HalfStep == pitch.HalfStep;
        }

        public override int GetHashCode()
        {
            int hashCode = -1907610900;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + HalfStep.GetHashCode();
            return hashCode;
        }

        public int CompareTo(Pitch other)
        {
            if (this.HalfStep != other.HalfStep)
                return this.HalfStep.CompareTo(other.HalfStep);
            else
                return this.Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return $"{Name} ({HalfStep})";
        }

        #region Operators
        public static bool operator ==(Pitch left, Pitch right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Pitch left, Pitch right)
        {
            return !(left == right);
        }

        public static int operator -(Pitch left, Pitch right)
        {
            return left.HalfStep - right.HalfStep;
        }

        public static int operator +(Pitch left, Pitch right)
        {
            return left.HalfStep + right.HalfStep;
        }

        public static Pitch operator -(Pitch left, int right)
        {
            int newHalfStep = left.HalfStep - right;
            return new Pitch(Pitches.GetPitchName(newHalfStep), newHalfStep);
        }

        public static Pitch operator +(Pitch left, int right)
        {
            int newHalfStep = left.HalfStep + right;
            return new Pitch(Pitches.GetPitchName(newHalfStep), newHalfStep);
        }

        public static Pitch operator -(Pitch left, Intervals right)
        {
            int newHalfStep = left.HalfStep - (int)right;
            return new Pitch(Pitches.GetPitchName(newHalfStep), newHalfStep);
        }

        public static Pitch operator +(Pitch left, Intervals right)
        {
            int newHalfStep = left.HalfStep + (int)right;
            return new Pitch(Pitches.GetPitchName(newHalfStep), newHalfStep);
        }

        public static Pitch operator -(Pitch left, Interval right)
        {
            int newHalfStep = left.HalfStep - (int)right.HalfSteps;
            return new Pitch(Pitches.GetPitchName(newHalfStep), newHalfStep);
        }

        public static Pitch operator +(Pitch left, Interval right)
        {
            int newHalfStep = left.HalfStep + (int)right.HalfSteps;
            return new Pitch(Pitches.GetPitchName(newHalfStep), newHalfStep);
        }

        public static bool operator <(Pitch left, Pitch right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Pitch left, Pitch right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Pitch left, Pitch right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Pitch left, Pitch right)
        {
            return left.CompareTo(right) >= 0;
        }
        #endregion
    }
}
