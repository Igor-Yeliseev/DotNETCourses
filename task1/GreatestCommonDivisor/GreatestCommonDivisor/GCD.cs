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
        public static int EuclideanGCD(int a, int b)
        {

            if (a < 0 || b < 0)
            {
                throw new Exception("Отрицательные числа");
            }

            if (a == b)
            {
                return a;
            }

            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }
            
            return (a + b);
        }

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
            return EuclideanGCD(EuclideanGCD(a, b), c);
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
            return EuclideanGCD(EuclideanGCD(EuclideanGCD(a, b), c), d);
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
            return EuclideanGCD(EuclideanGCD(EuclideanGCD(EuclideanGCD(a, b), c), d), e);
        }

        /// <summary>
        /// Алгоритм Стейна для расчета НОД
        /// </summary>
        /// <param name="a"> Первое число</param>
        /// <param name="b"> Второе число</param>
        /// <returns></returns>
        private static int steinGCD(int a, int b)
        {

            if (a == b)
            {
                return a;
            }
            if (a == 0)
            {
                return b;
            }
            if (b == 0)
            {
                return a;
            }

            if ((~a & 1) != 0)
            {
                if ((b & 1) != 0)
                {
                    return steinGCD(a >> 1, b);
                }
                else
                {
                    
                    return steinGCD(a >> 1, b >> 1) << 1;
                }
            }
            if ((~b & 1) != 0)
            {
                return steinGCD(a, b >> 1);
            }
            if (a > b)
            {
                return steinGCD((a - b) >> 1, b);
            }

            return steinGCD((b - a) >> 1, a);

        }

        /// <summary>
        /// Алгоритм Стейна для расчета НОД
        /// </summary>
        /// <param name="a"> Первое число</param>
        /// <param name="b"> Второе число</param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int SteinGCD(int a, int b, out long time)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            int answer = steinGCD(a, b);
            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;
            return answer;
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
