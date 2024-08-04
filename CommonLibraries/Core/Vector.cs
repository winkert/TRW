using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Core
{
    public class Vector:IComparable
    {
        public Vector(int x, int y)
            :this(x, y, 0, 0)
        { }

        public Vector(int x, int y, int startX, int startY)
        {
            Dx = x;
            Dy = y;
            Origin = new Position(startX, startY);
        }

        public int Dx { get; private set; }
        public int Dy { get; private set; }

        public Position Origin { get; }

        internal void UpdateVector(int x, int y)
        {
            Dx = x;
            Dy = y;
        }

        public override bool Equals(object obj)
        {
            Vector other = obj as Vector;
            return this.Dx.Equals(other.Dx) && this.Dy.Equals(other.Dy);
        }

        public override int GetHashCode()
        {
            return Dx ^ Dy;
        }

        /// <summary>
        /// Determines if a Vector is higher (Dx and/or Dy are larger) than this Vector
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            Vector other = obj as Vector;
            if (this.Dx.Equals(other.Dx))
            {
                if (this.Dy.Equals(other.Dy))
                {
                    return 0;
                }
                else
                {
                    return this.Dy.CompareTo(other.Dy);
                }
            }
            else
            {
                return this.Dx.CompareTo(other.Dx);
            }
        }

        public override string ToString()
        {
            return $"D{Dx}, D{Dy}";
        }

        public bool IsToTheLeft(Vector other)
        {
            return this.Dx > other.Dx;
        }
        public bool IsToTheRight(Vector other)
        {
            return this.Dx < other.Dx;
        }

        public bool IsAbove(Vector other)
        {
            return this.Dy > other.Dy;
        }
        public bool IsBelow(Vector other)
        {
            return this.Dy < other.Dy;
        }

        #region Operators
        public static Vector operator +(Vector v1, Vector v2) { return new Vector(v1.Dx + v2.Dx, v1.Dy + v2.Dy); }
        public static Vector operator -(Vector v1, Vector v2) { return new Vector(v1.Dx - v2.Dx, v1.Dy - v2.Dy); }
        #endregion
    }
}
