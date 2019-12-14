using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Class representing an triangle
    /// </summary>
    public abstract class Triangle : Figure
    {
        /// <summary>
        /// The side A of a triangle
        /// </summary>
        public float SideA { get; private set; }

        /// <summary>
        /// The side B of a triangle
        /// </summary>
        public float SideB { get; private set; }

        /// <summary>
        /// The side C of a triangle
        /// </summary>
        public float SideC { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Triangle class
        /// </summary>
        /// <param name="a"> First side of a triangle</param>
        /// <param name="b"> Second side of a triangle</param>
        /// <param name="c"> Third side of a triangle</param>
        public Triangle(float a, float b, float c)
        {
            if ((a + b) > c && (a + c) > b && (b + c) > a)
            {
                SideA = a;
                SideB = b;
                SideC = c;
            }
            else
            {
                throw new Exception("Such a triangle cannot exist.");
            }
        }

        /// <summary>
        /// Initializes a new instance of the Triangle class, cutting from another figure
        /// </summary>
        /// <param name="figure"> Figure for cutting</param>
        /// <param name="a"> First side of a triangle</param>
        /// <param name="b"> Second side of a triangle</param>
        /// <param name="c"> Third side of a triangle</param>
        public Triangle(Figure figure, float a, float b, float c)
        {
            if (figure == null)
            {
                throw new ArgumentNullException(nameof(figure));
            }
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new Exception("Invalid figure's parameters");
            }
            if ((a + b) > c && (a + c) > b && (b + c) > a)
            {
                SideA = a;
                SideB = b;
                SideC = c;
            }
            else
            {
                throw new Exception("Such a triangle cannot exist.");
            }
            if (figure.GetArea() < GetArea())
            {
                throw new Exception("The figure cannot be created.");
            }
        }

        /// <summary>
        /// Get the area of a triangle
        /// </summary>
        /// <returns></returns>
        public override float GetArea()
        {
            float semiPer = GetPerimeter() / 2;
            return (float)Math.Sqrt(semiPer * (semiPer - SideA) * (semiPer - SideB) * (semiPer - SideC));
        }

        /// <summary>
        /// Get the perimeter of a triangle
        /// </summary>
        /// <returns></returns>
        public override float GetPerimeter()
        {
            return (SideA + SideB + SideC);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj"> The object to compare with the current object.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Triangle tr = obj as Triangle;
            if (tr == null)
                return false;

            return (SideA.Equals(tr.SideA) && SideB.Equals(tr.SideB) && SideC.Equals(tr.SideC));
            
        }
        
        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (3 * SideA.GetHashCode() + 2 * SideB.GetHashCode() -
                    2 * SideC.GetHashCode());
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Triangle with sides: A = " + SideA + ", B = " + SideB + ", C = " + SideB + 
                "; Perimeter = " + GetPerimeter() + ", Area = " + GetArea();
        }
    }
}
