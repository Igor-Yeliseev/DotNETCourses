using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Class representing a film circle
    /// </summary>
    public class CircleFilm : Circle, IFilmFigure
    {
        /// <summary>
        /// Initializes a new instance of the CircleFilm class
        /// </summary>
        /// <param name="radius"> Circle radius</param>
        public CircleFilm(float radius) : base(radius)
        {
        }
    }
}
