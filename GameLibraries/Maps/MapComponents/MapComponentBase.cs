using System;
using System.Collections.Generic;
using TRW.CommonLibraries.Core;

namespace TRW.GameLibraries.Maps
{
    public abstract class MapComponentBase:IComparable<MapComponentBase>
    {
        public abstract Position[] Points { get; }

        public abstract void Draw(Map map);

        protected abstract int SortOrder { get; }

        /// <summary>
        /// Indicates whether there is an intersection of points/walls
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool Intersects(MapComponentBase other)
        {
            return Intersects(other, false);
        }

        public virtual bool Intersects(MapComponentBase other, bool ignoreAdjacent)
        {
            foreach (Position p in Points)
            {
                int a = 0;
                int b = 1;
                bool done = false;
                while (true)
                {
                    if (b >= other.Points.Length)
                    {
                        b = 0;
                        done = true;
                    }

                    if (Position.Between(p, other.Points[a], other.Points[b], !ignoreAdjacent, false))
                        return true;

                    if (done)
                        break;

                    a++;
                    b++;
                }
            }

            return false;
        }

        /// <summary>
        /// Indicates whether one component is entirely within another
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool Contains(MapComponentBase other)
        {
            foreach(Position p in other.Points)
            {
                if (!Position.Within(p, this.Points, false))
                    return false;
            }
            return true;
        }

        public int CompareTo(MapComponentBase other)
        {
            return this.SortOrder.CompareTo(other.SortOrder);
        }

        public override bool Equals(object obj)
        {
            return obj is MapComponentBase @base &&
                   EqualityComparer<Position[]>.Default.Equals(Points, @base.Points);
        }

        public override int GetHashCode()
        {
            return 480822998 + EqualityComparer<Position[]>.Default.GetHashCode(Points);
        }
    }
}
