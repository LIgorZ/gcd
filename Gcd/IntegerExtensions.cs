using System;
using System.Diagnostics;

namespace Gcd
{
    /// <summary>
    /// Provide methods with integers.
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        private static int Priv_GetGcdByEuclidean(int a, int b)
        {
           while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return Math.Abs(a);
        }

        public static int GetGcdByEuclidean(int a, int b)
        {
            if ((a == 0) && (b == 0))
            {
                throw new ArgumentException("all numbers are 0");
            }

            if ((a == int.MinValue) || (b == int.MinValue))
            {
                throw new ArgumentOutOfRangeException(nameof(a), nameof(b), "one or two numbers are int.MinValue");
            }

            return Priv_GetGcdByEuclidean(a, b);
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b, int c)
        {
            if ((a == 0) && (b == 0) && (c == 0))
            {
                throw new ArgumentException("all numbers are 0");
            }

            if ((a == int.MinValue) || (b == int.MinValue) || (c == int.MinValue))
            {
                throw new ArgumentOutOfRangeException(nameof(a), nameof(b), "one or two or more numbers are int.MinValue");
            }

            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            while (c != 0)
            {
                int temp = c;
                c = a % c;
                a = temp;
            }

            return Math.Abs(a);
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b, params int[] other)
        {
           if ((a == int.MinValue) || (b == int.MinValue))
            {
                throw new ArgumentOutOfRangeException(nameof(a), nameof(b), "one or two or more numbers are int.MinValue");
            }

            if (other == null || other.Length == 0)
            { return GetGcdByEuclidean(a, b); }

            int nod = 0;
            if (a != 0 || b != 0)
            { nod = GetGcdByEuclidean(a, b); }

            if (other != null)
            {
                foreach (int c_1 in other)
                {
                    if (c_1 != 0)
                    { nod = GetGcdByEuclidean(nod, c_1); }
                }
            }

            if (nod == 0)
            { throw new ArgumentException("all numbers are 0"); }

            return nod;
        }

        /// <summary>
        /// Calculates GCD of two integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        private static int Priv_GetGcdByStein(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            if ((a == 1) || (b == 1))
            {
                return a;
            }

            if (a % 2 == 0)
            {
                if (b % 2 == 1)
                {
                    return Priv_GetGcdByStein(a / 2, b);
                }
                else
                {
                    return 2 * Priv_GetGcdByStein(a / 2, b / 2);
                }
            }
            else
            {
                if (b % 2 == 0)
                {
                    return Priv_GetGcdByStein(a, b / 2);
                }

                if (a > b)
                {
                    return Priv_GetGcdByStein((a - b) / 2, b);
                }
                else
                {
                    return Priv_GetGcdByStein((b - a) / 2, a);
                }
            }
        }

        public static int GetGcdByStein(int a, int b)
        {
            if ((a == int.MinValue) || (b == int.MinValue))
            {
                throw new ArgumentOutOfRangeException(nameof(a), nameof(b), "one or two numbers are int.MinValue");
            }

            if ((a == 0) && (b == 0))
            {
                throw new ArgumentException("all numbers are 0");
            }
            
            return Priv_GetGcdByStein(a, b);
        }

        /// <summary>
        /// Calculates GCD of three integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b, int c)
        {
            if ((a == int.MinValue) || (b == int.MinValue) || (c == int.MinValue))
            {
                throw new ArgumentOutOfRangeException(nameof(a), nameof(b), "one or two numbers are int.MinValue");
            }

            if ((a == 0) && (b == 0) && (c == 0))
            {
                throw new ArgumentException("all numbers are 0");
            }

            int tmp = Priv_GetGcdByStein(c, Priv_GetGcdByStein(a, b));
            int tmp2 = Priv_GetGcdByStein(a, Priv_GetGcdByStein(c, b));
            return Math.Min(tmp, tmp2);
        }

        /// <summary>
        /// Calculates the GCD of integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b, params int[] other)
        {
            if ((a == int.MinValue) || (b == int.MinValue))
            {
                throw new ArgumentOutOfRangeException(nameof(a), nameof(b), "one or two numbers are int.MinValue");
            }

            foreach (var r in other) if (r == int.MinValue) throw new ArgumentOutOfRangeException(nameof(other), "one or two numbers are int.MinValue");
            
            if ((a == 0) && (b == 0))
            {
                bool yes = true;
                foreach (var r in other) { if (r != 0) yes = false; }
                if (yes == true) { throw new ArgumentException("all numbers are 0"); }
            }

            var res = Priv_GetGcdByStein(a, b);
            foreach (var r in other) { res = Priv_GetGcdByStein(res, r); }
            return res;
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b)
        {
            var sw = Stopwatch.StartNew();
            int tmp = GetGcdByEuclidean(a, b);
            sw.Stop();
            elapsedTicks = sw.ElapsedTicks;
            return tmp;
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b, int c)
        {
            var sw = Stopwatch.StartNew();
            int tmp = GetGcdByEuclidean(a, b, c);
            sw.Stop();
            elapsedTicks = sw.ElapsedTicks;
            return tmp;
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in Ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b, params int[] other)
        {
            var sw = Stopwatch.StartNew();
            int tmp = GetGcdByEuclidean(a, b, other);
            sw.Stop();
            elapsedTicks = sw.ElapsedTicks;
            return tmp;
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b)
        {
            var sw = Stopwatch.StartNew();
            int tmp = GetGcdByStein(a, b);
            sw.Stop();
            elapsedTicks = sw.ElapsedTicks;
            return tmp;
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b, int c)
        {
            var sw = Stopwatch.StartNew();
            int tmp = GetGcdByStein(a, b, c);
            sw.Stop();
            elapsedTicks = sw.ElapsedTicks;
            return tmp;
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in Ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b, params int[] other)
        {
            var sw = Stopwatch.StartNew();
            int tmp = GetGcdByStein(a, b, other);
            sw.Stop();
            elapsedTicks = sw.ElapsedTicks;
            return tmp;
        }
    }
}
