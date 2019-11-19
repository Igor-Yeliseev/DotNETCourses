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
        public float X { get; set; }

        /// <summary>
        /// Координата Y вектора
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Координата Z вектора
        /// </summary>
        public float Z { get; set; }

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

        /// <summary>
        /// Векторное произведение векторов
        /// </summary>
        /// <param name="v1"> Первый вектор</param>
        /// <param name="v2"> Второй вектор</param>
        /// <returns></returns>
        public static Vector operator ^(Vector v1, Vector v2)
        {
            float i = v1.Y * v2.Z - v2.Y * v1.Z;
            float j = v2.X * v1.Z - v1.X * v2.Z;
            float k = v1.X * v2.Y - v2.X * v1.Y;
            return new Vector(i, j, k);
        }

        /// <summary>
        /// Вычисление длины вектора
        /// </summary>
        /// <returns></returns>
        public float GetLength()
        {
            return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        /// <summary>
        /// Операция(больше) сравнения векторов
        /// </summary>
        /// <param name="v1"> Первый вектор</param>
        /// <param name="v2"> Второй вектор</param>
        /// <returns></returns>
        public static bool operator >(Vector v1, Vector v2)
        {
            return v1.GetLength() > v2.GetLength();
        }

        /// <summary>
        /// Операция(меньше) сравнения векторов
        /// </summary>
        /// <param name="v1"> Первый вектор</param>
        /// <param name="v2"> Второй вектор</param>
        /// <returns></returns>
        public static bool operator <(Vector v1, Vector v2)
        {
            return v1.GetLength() < v2.GetLength();
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Vector v = obj as Vector;
            if (v == null)
                return false;
            
            return (X.Equals(v.X) && Y.Equals(v.Y) && Z.Equals(v.Z));
        }

        public override int GetHashCode()
        {
            return (31 * X.GetHashCode() + 7 * Y.GetHashCode() + 
                    3 * Z.GetHashCode());  
        }

    }
}
