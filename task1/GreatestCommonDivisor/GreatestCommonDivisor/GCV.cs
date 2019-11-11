using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatestCommonDivisor
{
    public class GCV
    {
        /// <summary>
        /// Алгоритм Евклида для нахождения НОД двух чисел
        /// </summary>
        /// <param name="a"> Первое число</param>
        /// <param name="b"> Второе число</param>
        /// <returns></returns>
        public static int EuclideanGCV(int a, int b)
        {
            if (a == b)
            {
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

            return (a + b);
        }

        /// <summary>
        /// Алгоритм Евклида для нахождения НОД трех чисел
        /// </summary>
        /// <param name="a"> Первое число</param>
        /// <param name="b"> Второе число</param>
        /// <param name="c"> Третье число</param>
        /// <returns></returns>
        public static int EuclideanGCV(int a, int b, int c)
        {
            return 0;
        }

    }
}
