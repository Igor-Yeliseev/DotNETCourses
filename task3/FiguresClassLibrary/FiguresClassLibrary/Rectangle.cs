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
    class Rectangle : Figure
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


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Rectangle r = obj as Rectangle;
            if (r == null)
                return false;

            return (Width.Equals(r.Width) && Height.Equals(r.Height));
        }

        public override int GetHashCode()
        {
            return (2 * Width.GetHashCode() + 5 * Height.GetHashCode());
        }
    }
}
