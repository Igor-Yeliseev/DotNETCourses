using FiguresClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskClassLibrary
{
    /// <summary>
    /// Class representing a painter
    /// </summary>
    public class Painter
    {
        /// <summary>
        /// Paints a figure in a given color
        /// </summary>
        /// <param name="figure"> Figure</param>
        /// <param name="color"> Color</param>
        public void Colorize(Figure figure, Сoloring color)
        {
            if (figure is IPaperFigure)
            {
                IPaperFigure fig = (IPaperFigure)figure;

                fig.Сolor = color;
            }
            else
            {
                throw new Exception("This figure cannot be painted.");
            }
        }
    }
}
