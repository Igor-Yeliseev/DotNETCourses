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
    }
}
