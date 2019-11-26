using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatestCommonDivisor
{
    /// <summary>
    /// Greatest Common Divisor (GCD)
    /// </summary>
    public class GCD
    {
        /// <summary>
        /// GCD euclidean algorithm for two numbers
        /// </summary>
        /// <param name="a"> First number</param>
        /// <param name="b"> Second number</param>
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
        /// GCD euclidean algorithm for two numbers
        /// </summary>
        /// <param name="a"> First number</param>
        /// <param name="b"> Second number</param>
        /// <param name="time"> Method execution time (in timer ticks)</param>
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
        /// GCD euclidean algorithm for three numbers
        /// </summary>
        /// <param name="a"> First number</param>
        /// <param name="b"> Second number</param>
        /// <param name="c"> Third number</param>
        /// <returns></returns>
        public static int EuclideanGCD(int a, int b, int c)
        {
            return EuclideanGCD(EuclideanGCD(a, b), c);
        }

        /// <summary>
        /// GCD euclidean algorithm for four numbers
        /// </summary>
        /// <param name="a"> First number</param>
        /// <param name="b"> Second number</param>
        /// <param name="c"> Third number</param>
        /// <param name="d"> Fourth number</param>
        /// <returns></returns>
        public static int EuclideanGCD(int a, int b, int c, int d)
        {
            return EuclideanGCD(EuclideanGCD(EuclideanGCD(a, b), c), d);
        }

        /// <summary>
        ///  GCD euclidean algorithm for five numbers
        /// </summary>
        /// <param name="a"> First number</param>
        /// <param name="b"> Second number</param>
        /// <param name="c"> Third number</param>
        /// <param name="d"> Fourth number</param>
        /// <param name="e"> Fifth number</param>
        /// <returns></returns>
        public static int EuclideanGCD(int a, int b, int c, int d, int e)
        {
            return EuclideanGCD(EuclideanGCD(EuclideanGCD(EuclideanGCD(a, b), c), d), e);
        }

        /// <summary>
        /// Stein's GCD iterative binary algorithm
        /// </summary>
        /// <param name="a"> First number</param>
        /// <param name="b"> Second number</param>
        /// <param name="time"> Method execution time (in timer ticks)</param>
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
        /// Data preparation for a histogram
        /// </summary>
        /// <param name="a"> First number</param>
        /// <param name="b"> Second number</param>
        /// <param name="c"> Third number</param>
        /// <param name="d"> Fourth number</param>
        /// <param name="e"> Fifth number</param>
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

            // Returns dictionary (method_name, exc_выполнения)
            return methodsData;
        }

    }
}
