using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Enum representing the material type of a sheet
    /// </summary>
    public enum MaterialType
    {
        /// <summary>
        /// Represents paper
        /// </summary>
        Paper,
        /// <summary>
        /// Represents some film material
        /// </summary>
        Film
    }

    /// <summary>
    /// Enum representing figure's color
    /// </summary>
    public enum Сoloring
    {
        /// <summary>
        /// Red color
        /// </summary>
        Red,
        /// <summary>
        /// Black color
        /// </summary>
        Black,
        /// <summary>
        /// White color
        /// </summary>
        White,
        /// <summary>
        /// Blue color
        /// </summary>
        Blue,
        /// <summary>
        /// Yellow color
        /// </summary>
        Yellow,
        /// <summary>
        /// Green color
        /// </summary>
        Green,
        /// <summary>
        /// Orange color
        /// </summary>
        Orange,
        /// <summary>
        /// Gray color
        /// </summary>
        Gray,
        /// <summary>
        /// Pink color
        /// </summary>
        Pink,
        /// <summary>
        /// No color
        /// </summary>
        None
    }

    /// <summary>
    /// Class representing a common figure
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Get perimeter of the figure
        /// </summary>
        /// <returns></returns>
        public abstract float GetPerimeter();

        /// <summary>
        /// Get area of the figure
        /// </summary>
        /// <returns></returns>
        public abstract float GetArea();

        
    }
}
