using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
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
