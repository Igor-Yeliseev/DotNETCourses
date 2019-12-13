﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Class representing a film triangle
    /// </summary>
    class TriangleFilm : Triangle, IFilmFigure
    {
        /// <summary>
        /// Initializes a new instance of the TriangleFilm class
        /// </summary>
        /// <param name="a"> First side of a triangle</param>
        /// <param name="b"> Second side of a triangle</param>
        /// <param name="c"> Third side of a triangle</param>
        public TriangleFilm(float a, float b, float c) : base(a, b, c)
        {
        }
    }
}
