using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatestCommonDivisor
{
    /// <summary>
    /// Greatest Common Divisor
    /// </summary>
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
        /// <param name="time"> Время выполнения метода (в тактах таймера)</param>
        /// <returns></returns>
        public static int EuclideanGCD(int a, int b, out long time)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            int ans = EuclideanGCD(a, b);

            stopWatch.Stop();
            time = stopWatch.ElapsedTicks ;

            return ans;
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
        /// Итеративный бинарный алгоритм Стейна нахождения НОД
        /// </summary>
        /// <param name="a"> Первое число</param>
        /// <param name="b"> Второе число</param>
        /// <param name="time"> Время выполнения метода (в тактах таймера)</param>
        /// <returns></returns>
        public static int SteinGCD(int a, int b, out long time)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            int shift = 0;

            if (a == 0)
            {
                stopWatch.Stop();
                time = stopWatch.ElapsedTicks;
                return b;
            }
            if (b == 0)
            {
                stopWatch.Stop();
                time = stopWatch.ElapsedTicks;
                return a;
            }

            while (((a | b) & 1) == 0)
            {
                shift++;
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }

            do
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                if (a > b)
                {
                    int t = b;
                    b = a;
                    a = t;
                }

                b -= a;

            } while (b != 0);

            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;

            return a << shift;
        }

        /// <summary>
        /// Подготовка данных для гистограммы
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static Dictionary<string, long> SetDataBarGraph(int a, int b, int c, int d, int e)
        {
            Dictionary<string, long> methodsData = new Dictionary<string, long>();

            Stopwatch stopwatch = new Stopwatch();
            long excTime;

            stopwatch.Start();
            EuclideanGCD(a, b);
            stopwatch.Stop();
            excTime = stopwatch.ElapsedTicks;
            methodsData.Add("EuclideanGCD_2numbers", excTime);

            stopwatch.Start();
            EuclideanGCD(a, b, c);
            stopwatch.Stop();
            excTime = stopwatch.ElapsedTicks;
            methodsData.Add("EuclideanGCD_3numbers", excTime);

            stopwatch.Start();
            EuclideanGCD(a, b, c, d);
            stopwatch.Stop();
            excTime = stopwatch.ElapsedTicks;
            methodsData.Add("EuclideanGCD_4numbers", excTime);

            stopwatch.Start();
            EuclideanGCD(a, b, c, d, e);
            stopwatch.Stop();
            excTime = stopwatch.ElapsedTicks;
            methodsData.Add("EuclideanGCD_5numbers", excTime);

            SteinGCD(a, b, out excTime);
            methodsData.Add("SteinGCD_2numbers", excTime);

            // Возвращаем словать (название_метода, время_выполнения)
            return methodsData;
        }

    }
}
