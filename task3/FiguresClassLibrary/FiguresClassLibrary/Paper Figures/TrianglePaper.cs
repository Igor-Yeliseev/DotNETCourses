using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Class representing a paper triangle
    /// </summary>
    class TrianglePaper : Triangle, IPaperFigure
    {
        /// <summary>
        /// Figure's color
        /// </summary>
        public Сoloring Сolor { get; set; }

        /// <summary>
        /// Initializes a new instance of the TrianglePaper class
        /// </summary>
        /// <param name="a"> First side of a triangle</param>
        /// <param name="b"> Second side of a triangle</param>
        /// <param name="c"> Third side of a triangle</param>
        public TrianglePaper(float a, float b, float c) :base (a, b, c)
        {
            Сolor = Сoloring.None;
        }

        /// <summary>
        /// Paint a triangle in a specific color 
        /// </summary>
        /// <param name="color"> Fill color </param>
        public void Paint(Сoloring color)
        {
            if (Сolor == Сoloring.None)
            {
                Сolor = color;
            }
            else
            {
                throw new Exception("This triangle is already painted");
            }
        }
    }
}
