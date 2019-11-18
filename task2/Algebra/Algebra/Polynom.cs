using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra
{
    class Polynom
    {
        /// <summary>
        /// Старшая степень полинома
        /// </summary>
        public int Degree { get; set; }
        /// <summary>
        /// Массив коэффициентов полинома при каждой степени
        /// </summary>
        private double[] coeffs;
        

        /// <summary>
        /// Конструктор полинома
        /// </summary>
        /// <param name="coeffs"> Коэффициенты при степенях начиная со старшей</param>
        public Polynom(params double[] coeffs)
        {
            Degree = coeffs.Length;
            this.coeffs = new double[Degree];

            for (int i = 0; i < coeffs.Length; i++)
            {
                this.coeffs[i] = coeffs[i];
                
            }
        }

    }
}
