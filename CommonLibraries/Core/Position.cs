using System;
using System.Collections.Generic;
using System.Linq;

namespace TRW.CommonLibraries.Core
{
    public class Position : IComparable
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public void UpdatePosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            Position other = obj as Position;
            return this.X.Equals(other.X) && this.Y.Equals(other.Y);
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public bool Between(Position a, Position b)
        {
            return Between(this, a, b);
        }

        public bool Between(Position a, Position b, bool inclusive)
        {
            return Between(this, a, b, inclusive, false);
        }

        public int CompareTo(object obj)
        {
            Position other = obj as Position;
            return Compare(this, other);
        }

        public override string ToString()
        {
            return $"{X}, {Y}";
        }

        #region Statics
        public static Position Create(int x, int y)
        {
            return new Position(x, y);
        }

        public static bool Between(Position x, Position a, Position b)
        {
            return Between(x, a, b, true, false);
        }

        public static bool Between(Position x, Position a, Position b, bool inclusive, bool useAToBAsPlane)
        {
            if (a == b && x != a)
                return false;
            if (x == a || x == b)
                return true && inclusive;

            if(a.X == b.X) // forms vertical line
            {
                return x.Y.Between(a.Y, b.Y, inclusive);
            }

            if(a.Y == b.Y) // forms horizontal line
            {
                return x.X.Between(a.X, b.X, inclusive);
            }

            // from here it gets more complicated
            if (useAToBAsPlane)
            {
                var angles = Triangulate(a, b, x);

                double radiansA = angles.Item1;
                double radiansB = angles.Item2;
                double radiansC = angles.Item3;

                if (inclusive && radiansA < Math.PI / 2
                    && radiansB < Math.PI / 2)
                    return true;

                if (!inclusive && radiansA <= Math.PI / 2
                    && radiansB <= Math.PI / 2)
                    return true;
            }
            else
            {
                // move everything to a horizontal line at 0
                Position flatA = Create(a.X, 0);
                Position flatB = Create(b.X, 0);
                Position flatX = Create(x.X, 0);

                if (flatX.X.Between(flatA.X, flatB.X, inclusive))
                    return true;

                // move everything to a vertical line at 0
                flatA = Create(0, a.Y);
                flatB = Create(0, b.Y);
                flatX = Create(0, x.Y);

                if (flatX.Y.Between(flatA.Y, flatB.Y, inclusive))
                    return true;
            }

            return false;
        }

        public static bool Within(Position x, Position[] plots, bool inclusive)
        {
            int a = 0;
            int b = 1;
            bool done = false;
            while(true)
            {
                if(b >= plots.Length)
                {
                    b = 0;
                    done = true;
                }

                if (!x.Between(plots[a], plots[b], inclusive))
                {
                    return false;
                }
                
                // if not inclusive and three points are on a line, return false
                if (!inclusive && FormsLine(plots[a], plots[b], x))
                {
                    return false;
                }

                if (done)
                    break;

                a++;
                b++;
            }

            return true;
        }

        /// <summary>
        /// Two points determine a line. Determines if all three points on a line
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool FormsLine(Position a, Position b, Position c)
        {
            if (a.X == b.X && a.X == c.X)
                return true;

            if (a.Y == b.Y && a.Y == c.Y)
                return true;

            return false;
        }

        public static Tuple<double, double, double> Triangulate(Position a, Position b, Position c)
        {
            double dB = Math.Sqrt(Math.Pow(a.X - c.X, 2) + Math.Pow(a.Y - c.Y, 2));
            double dA = Math.Sqrt(Math.Pow(b.X - c.X, 2) + Math.Pow(b.Y - c.Y, 2));
            double dC = Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));

            double radiansA = Math.Acos((Math.Pow(dB, 2) + Math.Pow(dC, 2) - Math.Pow(dA, 2)) / (2 * dB * dC));
            double radiansB = Math.Acos((Math.Pow(dA, 2) + Math.Pow(dC, 2) - Math.Pow(dB, 2)) / (2 * dA * dC));
            double radiansC = Math.Acos((Math.Pow(dA, 2) + Math.Pow(dB, 2) - Math.Pow(dC, 2)) / (2 * dA * dB));

            return Tuple.Create(radiansA, radiansB, radiansC);
        }

        public static Position[] GetLine(Position a, Position b)
        {
            HashSet<Position> points = new HashSet<Position>();

            int startX = a.X < b.X ? a.X : b.X;
            int endX = a.X > b.X ? a.X : b.X;

            int startY = a.Y < b.Y ? a.Y : b.Y;
            int endY = a.Y > b.Y ? a.Y : b.Y;

            int rise = b.Y - a.Y;
            int run = b.X - a.X;
            decimal slope = run == 0m ? 0m : (decimal)rise / run;
            int c = (int)(a.Y - a.X * slope);

            for (int x = startX; x <= endX; x++)
            {
                int localY = (int)(slope * x) + c;
                if(!localY.Between(startY, endY))
                {
                    if (localY > startY)
                        localY = startY;
                    else if (localY < endY)
                        localY = endY;
                }
                points.Add(Create(x, localY));
            }

            if (slope != 0) // go back over y axis to hit everything
            {
                for (int y = startY; y <= endY; y++)
                {
                    int localX = (int)((y - c) / slope);
                    if (!localX.Between(startX, endX))
                    {
                        if (localX > startX)
                            localX = startX;
                        else if (localX < endX)
                            localX = endX;
                    }
                    points.Add(Create(localX, y));
                }
            }
            else if (run == 0) // veritcal line
            {
                for (int y = startY; y <= endY; y++)
                {
                    points.Add(Create(a.X, y));
                }
            }

            return points.ToArray();
        }

        public static int Compare(Position a, Position b)
        {
            if (a == null && b == null)
                return 0;

            if (a != null && b == null)
                return 1;

            if (a == null && b != null)
                return -1;

            if (a.Equals(b))
                return 0;

            if (a.X.Equals(b.X))
            {
                if (a.Y.Equals(b.Y))
                {
                    return 0;
                }
                else
                {
                    return a.Y.CompareTo(b.Y);
                }
            }
            else
            {
                return a.X.CompareTo(b.X);
            }
        }
        #endregion

        #region Operators
        public static Position operator +(Position pos, Vector vector) { return Create(pos.X + vector.Dx, pos.Y + vector.Dy); }
        public static Position operator -(Position pos, Vector vector) { return Create(pos.X - vector.Dx, pos.Y - vector.Dy); }
        public static Vector operator -(Position pos1, Position pos2) { return new Vector(pos1.X - pos2.X, pos1.Y - pos2.Y); }
        public static bool operator >(Position pos1, Position pos2) { return Compare(pos1, pos2) > 0; }
        public static bool operator >=(Position pos1, Position pos2) { return Compare(pos1, pos2) >= 0; }
        public static bool operator <(Position pos1, Position pos2) { return Compare(pos1, pos2) < 0; }
        public static bool operator <=(Position pos1, Position pos2) { return Compare(pos1, pos2) <= 0; }
        public static bool operator ==(Position pos1, Position pos2)
        {
            if (pos1 is null && pos2 is null)
                return true;
            else if (pos1 is null || pos2 is null)
                return false;
            else
                return pos1.Equals(pos2);
        }
        public static bool operator !=(Position pos1, Position pos2)
        {
            if (pos1 is null && pos2 is null)
                return false;
            else if (pos1 is null || pos2 is null)
                return true;
            else
                return !pos1.Equals(pos2);
        }
        #endregion
    }
}
