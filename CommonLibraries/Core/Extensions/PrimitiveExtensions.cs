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


        public static bool IsPalindrome(this string input)
        {
            if (input.Length < 2)
                throw new ArgumentException("not a valid input - must be 2 characters");

            if (input == null)
                throw new ArgumentNullException(nameof(input));

            string cleanInput = input.Replace(" ", "").ToLowerInvariant();

            int j = cleanInput.Length - 1;
            for (int i = 0; i < cleanInput.Length / 2; i++)
            {
                if (cleanInput[i] != cleanInput[j--])
                {
                    Console.WriteLine($"{cleanInput[i]} != {cleanInput[j + 1]}");
                    return false;
                }
            }

            return true;

        }


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

        public static T CastToType<T>(this object o)
        {
            if (o is T typedO)
                return typedO;

            if (o is IConvertible)
                return (T)Convert.ChangeType(o, typeof(T));

            // Try direct cast - we are most likely dealing with a reference type
            try
            {
                //unbox o for casting which should use any implicit operator that exists
                dynamic oAsType = o;
                return (T)(oAsType);
            }
            catch (InvalidCastException ex)
            {
                throw new ArgumentException($"Object is not of type {typeof(T)} and cannot be converted to that type.", nameof(o), ex);
            }

        }
    }
}
