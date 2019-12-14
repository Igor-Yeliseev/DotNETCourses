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
    public class TrianglePaper : Triangle, IPaperFigure
    {
        /// <summary>
        /// Figure's color
        /// </summary>
        private Сoloring color;

        /// <summary>
        /// Initializes a new instance of the TrianglePaper class
        /// </summary>
        /// <param name="a"> First side of a triangle</param>
        /// <param name="b"> Second side of a triangle</param>
        /// <param name="c"> Third side of a triangle</param>
        public TrianglePaper(float a, float b, float c) :base (a, b, c)
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
