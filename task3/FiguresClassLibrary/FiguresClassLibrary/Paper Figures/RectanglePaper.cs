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
    public class RectanglePaper : Rectangle, IPaperFigure
    {
        /// <summary>
        /// Figure's color
        /// </summary>
        private Сoloring color;

        /// <summary>
        /// Initializes a new instance of the RectanglePaper class
        /// </summary>
        /// <param name="width"> Width of a rectangle</param>
        /// <param name="height"> Height of a rectangle</param>
        public RectanglePaper(float width, float height) :base (width, height)
        {
            color = Сoloring.None;
        }

        /// <summary>
        /// Initializes a new instance of the RectanglePaper class, cutting from another figure
        /// </summary>
        /// <param name="figure"> Figure for cutting</param>
        /// <param name="width"> Width of a rectangle</param>
        /// <param name="height"> Height of a rectangle</param>
        public RectanglePaper(Figure figure, float width, float height) : base(figure, width, height)
        {
            if (!(figure is RectanglePaper))
            {
                throw new Exception("The figure cannot be created.");
            }
            color = ((RectanglePaper)figure).Сolor;
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

            RectanglePaper rect = obj as RectanglePaper;
            if (rect == null)
                return false;

            return (base.Equals(rect) && Сolor.Equals(rect.Сolor));
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
