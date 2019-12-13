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
    class CirclePaper : Circle, IPaperFigure
    {
        /// <summary>
        /// Figure's color
        /// </summary>
        public Сoloring Сolor { get; set; }

        /// <summary>
        /// Initializes a new instance of the CirclePaper class
        /// </summary>
        /// <param name="radius"> Circle radius</param>
        public CirclePaper(float radius) :base (radius)
        {
            Сolor = Сoloring.None;
        }

        /// <summary>
        /// Paint a circle in a specific color 
        /// </summary>
        /// <param name="color"> Fill color</param>
        public void Paint(Сoloring color)
        {
            if(Сolor == Сoloring.None)
            {
                Сolor = color;
            }
            else
            {
                throw new Exception("This circle is already painted");
            }
        }
    }
}
