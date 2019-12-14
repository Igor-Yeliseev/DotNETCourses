using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Class representing a paper circle
    /// </summary>
    public class CirclePaper : Circle, IPaperFigure
    {
        /// <summary>
        /// Figure's color
        /// </summary>
        private Сoloring color;

        /// <summary>
        /// Initializes a new instance of the CirclePaper class
        /// </summary>
        /// <param name="radius"> Circle radius</param>
        public CirclePaper(float radius) :base (radius)
        {
            color = Сoloring.None;
        }

        /// <summary>
        /// Initializes a new instance of the CirclePaper class, cutting from another figure
        /// </summary>
        /// <param name="figure"> Figure for cutting</param>
        /// <param name="radius"> Circle radius</param>
        public CirclePaper(Figure figure, float radius) :base (figure, radius)
        {
            if(!(figure is IPaperFigure))
            {
                throw new Exception("The figure cannot be created.");
            }
            color = ((IPaperFigure)figure).Сolor;
        }

        /// <summary>
        /// Figure's color
        /// </summary>
        public Сoloring Сolor
        {
            get { return color; }

            set
            {
                if (color == Сoloring.None)
                {
                    color = value;
                }
                else
                {
                    throw new Exception("This figure is already painted.");
                }
            }
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

            CirclePaper cirlce = obj as CirclePaper;
            if (cirlce == null)
                return false;

            return (base.Equals(cirlce) && Сolor.Equals(cirlce.Сolor));
        }

        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (3 * Radius.GetHashCode());
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return color.ToString() + " " + base.ToString();
        }
    }
}
