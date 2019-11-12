using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatestCommonDivisor
{
    public class GCD
    {
        /// <summary>
        /// Алгоритм Евклида для нахождения НОД двух чисел
        /// </summary>
        /// <param name="a"> Первое число</param>
        /// <param name="b"> Второе число</param>
        /// <returns></returns>
        public static int EuclideanGCD(int a, int b, out double time)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            if (a == b)
            {
                stopWatch.Stop();
                time = stopWatch.ElapsedMilliseconds;
                return a;
            }

            while (a != 0 && b!= 0)
            {
                if(a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }

            stopWatch.Stop();
            time = stopWatch.ElapsedMilliseconds;
            return (a + b);
        }

        /// <summary>
        /// Алгоритм для нахождения НОД трех чисел
        /// </summary>
        /// <param name="a"> Первое число</param>
        /// <param name="b"> Второе число</param>
        /// <param name="c"> Третье число</param>
        /// <returns></returns>
        public static int EuclideanGCD(int a, int b, int c)
        {
            double time;
            return EuclideanGCD(EuclideanGCD(a, b, out time), c, out time);
        }

        /// <summary>
        /// Алгоритм для нахождения НОД четырех чисел
        /// </summary>
        /// <param name="a"> Первое число</param>
        /// <param name="b"> Второе число</param>
        /// <param name="c"> Третье число</param>
        /// <param name="d"> Четвертое число</param>
        /// <returns></returns>
        public static int EuclideanGCD(int a, int b, int c, int d)
        {
            double time;
            return EuclideanGCD(EuclideanGCD(EuclideanGCD(a, b, out time), c, out time), d, out time);
        }

        /// <summary>
        /// Алгоритм для нахождения НОД пяти чисел
        /// </summary>
        /// <param name="a"> Первое число</param>
        /// <param name="b"> Второе число</param>
        /// <param name="c"> Третье число</param>
        /// <param name="d"> Четвертое число</param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static int EuclideanGCD(int a, int b, int c, int d, int e)
        {
            double time;
            return EuclideanGCD(EuclideanGCD(EuclideanGCD(EuclideanGCD(a, b, out time), c, out time), d, out time), e, out time);
        }

        /// <summary>
        /// Алгоритм Стейна для расчета НОД
        /// </summary>
        /// <param name="a"> Первое число</param>
        /// <param name="b"> Второе число</param>
        /// <returns></returns>
        public static int SteinGCD(int a, int b, out double time)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //stopWatch.Stop();
            //time = stopWatch.Elapsed;

            if (a == b)
            {
                stopWatch.Stop();
                time = stopWatch.Elapsed.TotalMilliseconds;
                return a;
            }
            if (a == 0)
            {
                stopWatch.Stop();
                time = stopWatch.Elapsed.TotalMilliseconds;
                return b;
            }
            if (b == 0)
            {
                stopWatch.Stop();
                time = stopWatch.Elapsed.TotalMilliseconds;
                return a;
            }

            if ((~a & 1) != 0)
            {
                if ((b & 1) != 0)
                {
                    return SteinGCD(a >> 1, b, out time);
                }
                else
                {
                    
                    return SteinGCD(a >> 1, b >> 1, out time) << 1;
                }
            }
            if ((~b & 1) != 0)
            {
                return SteinGCD(a, b >> 1, out time);
            }
            if (a > b)
            {
                return SteinGCD((a - b) >> 1, b, out time);
            }

            return SteinGCD((b - a) >> 1, a, out time);

        }

        /// <summary>
        /// Итеративный бинарный алгоритм Стейна нахождения НОД
        /// </summary>
        /// <param name="u"> Первое число</param>
        /// <param name="v"> Второе число</param>
        /// <param name="time"> Время выполнения метода</param>
        /// <returns></returns>
        public static int SteinIterativeGCD(int u, int v, out long time)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            int shift = 0;

            if (u == 0)
            {
                stopWatch.Stop();
                time = stopWatch.ElapsedTicks;
                return v;
            }
            if (v == 0)
            {
                stopWatch.Stop();
                time = stopWatch.ElapsedTicks;
                return u;
            }

            while (((u | v) & 1) == 0)
            {
                shift++;
                u >>= 1;
                v >>= 1;
            }

            while ((u & 1) == 0)
            {
                u >>= 1;
            }

            do
            {
                while ((v & 1) == 0)
                {
                    v >>= 1;
                }

                if (u > v)
                {
                    int t = v; v = u; u = t;
                }

                v -= u;

            } while (v != 0);

            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;

            return u << shift;
        }

    }
}
