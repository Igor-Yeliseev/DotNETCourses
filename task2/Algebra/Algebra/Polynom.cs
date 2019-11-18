using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra
{
    public class Polynom
    {
        /// <summary>
        /// Старшая степень полинома
        /// </summary>
        public int Degree { get; set; }
        /// <summary>
        /// Массив коэффициентов полинома при каждой степени
        /// </summary>
        public double[] Coeffs { get; private set; }
        

        /// <summary>
        /// Конструктор полинома
        /// </summary>
        /// <param name="coeffs"> Коэффициенты при степенях начиная со старшей</param>
        public Polynom(params double[] coeffs)
        {
            if (coeffs.Length != 0)
            {
                Degree = coeffs.Length;
                Coeffs = new double[Degree];

                for (int i = 0; i < coeffs.Length; i++)
                {
                    Coeffs[i] = coeffs[i];
                }
            }
            else
            {
                Degree = 0;
                Coeffs = new double[1] {0};
            }
        }

        /// <summary>
        /// Умножение полинома на число
        /// </summary>
        /// <param name="p1"> Полином</param>
        /// <param name="number"> Число</param>
        /// <returns></returns>
        private static Polynom multiplyPolynom(Polynom poly, double number)
        {
            if (number == 0)
            {
                poly = new Polynom(0);
            }
            else
            {
                double[] coeffs = new double[poly.Degree];
                for (int i = 0; i < poly.Degree; i++)
                {
                    coeffs[i] = poly.Coeffs[i] * number;
                }
                poly = new Polynom(coeffs);
            }
            return poly;
        }

        /// <summary>
        /// Умножение полинома на число
        /// </summary>
        /// <param name="p1"> Полином</param>
        /// <param name="number"> Число</param>
        /// <returns></returns>
        public static Polynom operator *(Polynom poly, double number)
        {
            return multiplyPolynom(poly, number);
        }

        /// <summary>
        /// Умножение числа на полином
        /// </summary>
        /// <param name="number"> Число</param>
        /// <param name="poly"> Полином</param>
        /// <returns></returns>
        public static Polynom operator *(double number, Polynom poly)
        {
            return multiplyPolynom(poly, number);
        }

        /// <summary>
        /// Сложение полинома с числом
        /// </summary>
        /// <param name="poly"> Полином</param>
        /// <param name="number"> Число</param>
        /// <returns></returns>
        private static Polynom additionPolyNumber(Polynom poly, double number)
        {
            int last = poly.Coeffs.Length - 1; // Просто для наглядности
            poly.Coeffs[last] = poly.Coeffs.Last() + number;

            return new Polynom(poly.Coeffs);
        }

        /// <summary>
        /// Сложение полинома с числом
        /// </summary>
        /// /// <param name="p1"> Полином</param>
        /// <param name="number"> Число</param>
        /// <returns></returns>
        public static Polynom operator +(Polynom poly, double number)
        {
            return additionPolyNumber(poly, number);
        }

        /// <summary>
        /// Сложение числа с полиномом
        /// </summary>
        /// <param name="number"></param>
        /// <param name="poly"></param>
        /// <returns></returns>
        public static Polynom operator +(double number, Polynom poly)
        {
            return additionPolyNumber(poly, number);
        }

        /// <summary>
        /// Сложение двух полиномов
        /// </summary>
        /// <param name="p1"> Первый полином</param>
        /// <param name="p2"> Второй полином</param>
        /// <returns></returns>
        public static Polynom operator +(Polynom p1, Polynom p2)
        {
            Polynom p3 = new Polynom();
            int longer, less;
            bool isFirstLonger;
            if (p1.Coeffs.Length >= p2.Coeffs.Length)
            {
                longer = p1.Coeffs.Length;
                less = p2.Coeffs.Length;
                isFirstLonger = true;
            }
            else
            {
                longer = p2.Coeffs.Length;
                less = p1.Coeffs.Length;
                isFirstLonger = false;
            }
            p3.Coeffs = new double[longer];

            int j = 0;
            for (int i = 0; i < longer; i++)
            {
                if (longer - i <= less)
                {
                    if (isFirstLonger)
                    {
                        p3.Coeffs[i] = p1.Coeffs[i] + p2.Coeffs[j];
                    }
                    else
                    {
                        p3.Coeffs[i] = p1.Coeffs[j] + p2.Coeffs[i];
                    }
                    j++;
                }
                else
                {
                    p3.Coeffs[i] = (isFirstLonger)? p1.Coeffs[i] : p2.Coeffs[i];
                }
            }

            return p3;
        }


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Polynom poly = obj as Polynom;
            if (poly == null)
                return false;

            if (poly.Coeffs.Length != Coeffs.Length)
                return false;

            bool equal = true;

            for (int i = 0; i < Coeffs.Length; i++)
            {
                if(Coeffs[i] != poly.Coeffs[i])
                {
                    equal = false;
                    break;
                }
            }

            return equal;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() * 21;
        }
    }
}
