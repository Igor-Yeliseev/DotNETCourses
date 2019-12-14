using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Class  representing a rectangle
    /// </summary>
    public abstract class Rectangle : Figure
    {
        /// <summary>
        /// Get the width of a rectangle
        /// </summary>
        public float Width { get; private set; }

        /// <summary>
        /// Get the height of a rectangle
        /// </summary>
        public float Height { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Rectangle class
        /// </summary>
        /// <param name="width"> Width of a rectangle</param>
        /// <param name="height"> Height of a rectangle</param>
        public Rectangle(float width, float height)
        {
            if(width > 0 && height > 0)
            {
                Width = width;
                Height = height;
            }
            else
            {
                throw new Exception("Such a rectangle cannot exist.");
            }
        }

        /// <summary>
        /// Initializes a new instance of the Rectangle class, cutting from another figure
        /// </summary>
        /// <param name="figure"> Figure for cutting</param>
        /// <param name="width"> Width of a rectangle</param>
        /// <param name="height"> Height of a rectangle</param>
        public Rectangle(Figure figure, float width, float height)
        {
            if (figure == null)
            {
                throw new ArgumentNullException(nameof(figure));
            }
            if (width <= 0 || height <= 0)
            {
                throw new Exception("Invalid figure's parameters");
            }

            Width = width;
            Height = height;

            if (figure.GetArea() < GetArea())
            {
                throw new Exception("The figure cannot be created.");
            }
        }

        /// <summary>
        /// Get the area of a rectangle
        /// </summary>
        /// <returns></returns>
        public override float GetArea()
        {
            return (Width * Height);
        }

        /// <summary>
        /// Get the perimeter of a rectangle
        /// </summary>
        /// <returns></returns>
        public override float GetPerimeter()
        {
            return (2 * Width + 2 * Height);
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

            Rectangle r = obj as Rectangle;
            if (r == null)
                return false;

            return (Width.Equals(r.Width) && Height.Equals(r.Height));
        }

        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (2 * Width.GetHashCode() + 5 * Height.GetHashCode());
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Rectangle with Width = " + Width + " Height = " + Height + "; Perimeter = "
                + GetPerimeter() + ", Area = " + GetArea();
        }


    }
}
