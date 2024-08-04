using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Core
{
    public static class PrimitiveExtensions
    {
        #region Factorial
        public static long GetFactorial(this int n)
        {
            if (n > 1)
            {
                return n-- * n.GetFactorial();
            }

            return n;
        }
        public static long GetFactorial(this long n)
        {
            if (n > 1)
            {
                return n-- * n.GetFactorial();
            }

            return n;
        }
        #endregion

        /// <summary>
        /// Determine if a value is between two other values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o">Object</param>
        /// <param name="a">Point A</param>
        /// <param name="b">Point B</param>
        /// <returns></returns>
        public static bool Between<T>(this T o, T a, T b) where T : IComparable<T>, IEquatable<T>
        {
            return Between(o, a, b, true);
        }

        /// <summary>
        /// Determine if a value is between two other values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o">Object</param>
        /// <param name="a">Point A</param>
        /// <param name="b">Point B</param>
        /// <param name="inclusive">FALSE means use Less Than and Greater Than, TRUE means use Less Than Or Equal To and Greater Than Or Equal To</param>
        /// <returns></returns>
        public static bool Between<T>(this T o, T a, T b, bool inclusive) where T : IComparable<T>, IEquatable<T>
        {
            if (inclusive)
            {
                if (o.CompareTo(a) >= 0 && o.CompareTo(b) <= 0)
                    return true;

                if (o.CompareTo(a) <= 0 && o.CompareTo(b) >= 0)
                    return true;
            }
            else
            {
                if (o.CompareTo(a) > 0 && o.CompareTo(b) < 0)
                    return true;

                if (o.CompareTo(a) < 0 && o.CompareTo(b) > 0)
                    return true;
            }
            return false;
        }

        public static byte[] AppendBytes(this byte[] first, byte[] second)
        {
            byte[] bytes = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, bytes, 0, first.Length);
            Buffer.BlockCopy(second, 0, bytes, first.Length, second.Length);
            return bytes;
        }
    }
}
