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
        /// Алгоритм для нахождения НОД трех чисел
        /// </summary>
        /// <param name="a"> Первое число</param>
        /// <param name="b"> Второе число</param>
        /// <param name="c"> Третье число</param>
        /// <returns></returns>
        public static int EuclideanGCV(int a, int b, int c)
        {
            return EuclideanGCV(EuclideanGCV(a, b), c);
        }

        /// <summary>
        /// Алгоритм для нахождения НОД четырех чисел
        /// </summary>
        /// <param name="a"> Первое число</param>
        /// <param name="b"> Второе число</param>
        /// <param name="c"> Третье число</param>
        /// <param name="d"> Четвертое число</param>
        /// <returns></returns>
        public static int EuclideanGCV(int a, int b, int c, int d)
        {
            return EuclideanGCV(EuclideanGCV(EuclideanGCV(a, b), c), d);
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
        public static int EuclideanGCV(int a, int b, int c, int d, int e)
        {
            return EuclideanGCV(EuclideanGCV(EuclideanGCV(EuclideanGCV(a, b), c), d), e);
        }



    }
}
