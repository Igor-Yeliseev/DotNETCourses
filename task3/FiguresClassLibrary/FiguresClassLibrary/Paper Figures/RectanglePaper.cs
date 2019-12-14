﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Class representing a paper rectangle
    /// </summary>
    public class RectanglePaper : Rectangle, IPaperFigure
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

        
    }
}
