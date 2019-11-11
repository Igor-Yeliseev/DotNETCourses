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
            int q;
            int r1 = 0;
            int r2 = 0;
            int r3 = 0;
            int answer = 0;
            bool loopOn = true;

            if (a > b)
            {
                r1 = a;
                r2 = b;
            }
            else if (a < b)
            {
                r1 = b;
                r2 = a;
            }

            while (loopOn)
            {
                // r1 = r2 * q + r3;
                if (r1 % r2 != 0)
                {
                    r3 = r1 % r2;
                    q = r1 / r2;
                    r1 = r2;
                    r2 = r3;
                }
                else
                {
                    answer = r2;
                    loopOn = false;
                }
            }

            return answer;
        }



    }
}
