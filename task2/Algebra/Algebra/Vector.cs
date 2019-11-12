using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra
{
    public class Vector
    {
        /// <summary>
        /// Координата X вектора
        /// </summary>
        float X { get; set; }

        /// <summary>
        /// Координата Y вектора
        /// </summary>
        float Y { get; set; }

        /// <summary>
        /// Координата Z вектора
        /// </summary>
        float Z { get; set; }

        /// <summary>
        /// Конструктор вектора
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Сложение векторов
        /// </summary>
        /// <param name="v1"> Первый вектор</param>
        /// <param name="v2"> Второй вектор</param>
        /// <returns></returns>
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        /// <summary>
        /// Вычитание векторов
        /// </summary>
        /// <param name="v1"> Первый вектор</param>
        /// <param name="v2"> Второй вектор</param>
        /// <returns></returns>
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        /// <summary>
        /// Умножение числа на вектор
        /// </summary>
        /// <param name="num"> Число</param>
        /// <param name="v"> Вектор</param>
        /// <returns></returns>
        public static Vector operator *(float num, Vector v)
        {
            return new Vector(v.X * num, v.Y * num, v.Z * num);
        }

        /// <summary>
        /// Умножение вектора на число
        /// </summary>
        /// <param name="v"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static Vector operator *(Vector v, float num)
        {
            return new Vector(v.X * num, v.Y * num, v.Z * num);
        }

        /// <summary>
        /// Скалярное произведение векторов
        /// </summary>
        /// <param name="v1"> Первый вектор</param>
        /// <param name="v2"> Второй вектор</param>
        /// <returns></returns>
        public static float operator *(Vector v1, Vector v2)
        {
            return (v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Vector v = obj as Vector;

            if (v == null)
                return false;
            
            return (X == v.X && Y == v.Y && Z == v.Z);
        }

    }
}
