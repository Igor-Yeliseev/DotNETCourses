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
        /// Initializes a new instance of the TrianglePaper class, cutting from another figure
        /// </summary>
        /// <param name="figure"> Figure for cutting</param>
        /// <param name="a"> First side of a triangle</param>
        /// <param name="b"> Second side of a triangle</param>
        /// <param name="c"> Third side of a triangle</param>
        public TrianglePaper(Figure figure, float a, float b, float c) : base(figure, a, b, c)
        {
            if (!(figure is TrianglePaper))
            {
                throw new Exception("The figure cannot be created.");
            }
            color = ((TrianglePaper)figure).Сolor;
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

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj"> The object to compare with the current object.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            TrianglePaper tr = obj as TrianglePaper;
            if (tr == null)
                return false;

            return (base.Equals(tr) && Сolor.Equals(tr.Сolor));
        }

        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (base.GetHashCode() - color.GetHashCode());
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return color.ToString() + " " + base.ToString();
        }
    }
}
