using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Class representing a circle
    /// </summary>
    public class Circle : Figure
    {
        /// <summary>
        /// Circle radius
        /// </summary>
        public float Radius { get; set; }

        /// <summary>
        /// Initializes a new instance of the Circle class
        /// </summary>
        /// <param name="radius"> Circle radius</param>
        public Circle(float radius)
        {
            if(radius > 0)
            {
                Radius = radius;
            }
            else
            {
                throw new Exception("Such a circle cannot exist.");
            }
        }

        /// <summary>
        /// Initializes a new instance of the Circle class, cutting from another figure
        /// </summary>
        /// <param name="figure"> Figure for cutting</param>
        /// <param name="radius"> Circle radius</param>
        public Circle(Figure figure, float radius)
        {
            if(radius <= 0)
            {
                throw new Exception("Invalid figure's parameters");
            }
            Radius = radius;
            if(figure.GetArea() < GetArea())
            {
                throw new Exception("The figure cannot be created.");
            }
        }

        /// <summary>
        /// Get the area of a circle
        /// </summary>
        /// <returns></returns>
        public override float GetArea()
        {
            return (float)(Math.PI * Radius * Radius);
        }

        /// <summary>
        /// Get the perimeter of a circle
        /// </summary>
        /// <returns></returns>
        public override float GetPerimeter()
        {
            return (float)(Math.PI * 2 * Radius);
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

            Circle cirlce = obj as Circle;
            if (cirlce == null)
                return false;

            return (Radius.Equals(cirlce.Radius));
        }

        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (4 * Radius.GetHashCode());
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Circle with Radius = " + Radius + "; Perimeter = " + GetPerimeter() + 
                   ", Area = " + GetArea();
        }
    }
}
