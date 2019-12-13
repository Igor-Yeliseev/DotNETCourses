using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Class representing a paper rectangle
    /// </summary>
    class RectanglePaper : Rectangle, IPaperFigure
    {
        /// <summary>
        /// Figure's color
        /// </summary>
        public Сoloring Сolor { get; set; }

        /// <summary>
        /// Initializes a new instance of the RectanglePaper class
        /// </summary>
        /// <param name="width"> Width of a rectangle</param>
        /// <param name="height"> Height of a rectangle</param>
        public RectanglePaper(float width, float height) :base (width, height)
        {
            Сolor = Сoloring.None;
        }

        /// <summary>
        /// Paint a rectangle in a specific color 
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
                throw new Exception("This rectangle is already painted");
            }
        }
    }
}
