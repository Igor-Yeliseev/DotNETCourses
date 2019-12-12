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
    class Circle : Figure
    {
        /// <summary>
        /// Circle radius
        /// </summary>
        public float Radius { get; set; }

        /// <summary>
        /// Initializes a new instance of the Circle class
        /// </summary>
        /// <param name="radius"></param>
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

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Circle cirlce = obj as Circle;
            if (cirlce == null)
                return false;

            return (Radius.Equals(cirlce.Radius));
        }

        public override int GetHashCode()
        {
            return (4 * Radius.GetHashCode());
        }
    }
}
