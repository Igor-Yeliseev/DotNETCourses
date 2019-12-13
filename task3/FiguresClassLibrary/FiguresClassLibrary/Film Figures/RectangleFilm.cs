using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Class  representing a film rectangle
    /// </summary>
    class RectangleFilm : Rectangle, IFilmFigure
    {
        /// <summary>
        /// Initializes a new instance of the RectangleFilm class
        /// </summary>
        /// <param name="width"> Width of a rectangle</param>
        /// <param name="height"> Height of a rectangle</param>
        public RectangleFilm(float width, float height) : base(width, height)
        {
        }
    }
}
