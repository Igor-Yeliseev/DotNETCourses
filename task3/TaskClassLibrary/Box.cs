using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiguresClassLibrary;

namespace TaskClassLibrary
{
    /// <summary>
    /// List of 20 figures
    /// </summary>
    public class Box : IEnumerable<Figure>
    {

        /// <summary>
        /// List of figures
        /// </summary>
        private List<Figure> figures = new List<Figure>();


        /// <summary>
        /// Figures amount
        /// </summary>
        public int GetCount()
        {
            return figures.Count;
        }

        /// <summary>
        /// Add a new figure to the box
        /// </summary>
        /// <param name="figure"> Figure </param>
        public void Add(Figure figure)
        {
            if (figure == null)
            {
                throw new ArgumentNullException(nameof(figure));
            }

            if(figures.Count == 20)
            {
                throw new Exception("The box if full.");
            }

            if (!figures.Contains(figure))
            {
                figures.Add(figure);
            }
        }

        /// <summary>
        /// Find a figure by sample
        /// </summary>
        /// <param name="sample"> Figure's sample</param>
        /// <returns></returns>
        public Figure FindFigure(Figure sample)
        {
            if (sample == null)
            {
                throw new ArgumentNullException(nameof(sample));
            }

            foreach (Figure figure in figures)
            {
                if(figure.Equals(sample))
                {
                    return figure;
                }
            }
            
            return null;
        }

        /// <summary>
        /// Extract figure by number
        /// </summary>
        /// <param name="number"> Number of the figure</param>
        /// <returns></returns>
        public Figure Extract(int number)
        {
            if(figures[number] == null)
            {
                throw new ArgumentNullException();
            }

            Figure figure = figures[number - 1];

            figures.RemoveAt(number - 1);

            return figure;
        }

        /// <summary>
        /// Replace figure by number
        /// </summary>
        /// <param name="figure"> A new figure</param>
        /// <param name="number"> Number of the old figure</param>
        public void Replace(Figure figure, int number)
        {
            if (figure == null || figures[number - 1] == null)
            {
                throw new ArgumentNullException(nameof(figure));
            }

            figures[number] = figure;

            //figures.RemoveAt(number);
            //figures.Insert(number, figure);
        }

        /// <summary>
        /// Show figure by number
        /// </summary>
        /// <param name="number"> number of the figure</param>
        /// <returns></returns>
        public Figure ShowFigure(int number)
        {
            if (figures[number - 1] == null)
            {
                throw new ArgumentNullException();
            }

            return figures[number - 1];
        }
        
        /// <summary>
        /// Get a total area of all figures
        /// </summary>
        /// <returns></returns>
        public float GetTotalArea()
        {
            float area = 0.0f;

            foreach (Figure figure in figures)
            {
                area += figure.GetArea();
            }

            return area;
        }

        /// <summary>
        /// Get a total perimeter of all figures
        /// </summary>
        /// <returns></returns>
        public float GetTotalPerimeter()
        {
            float perimeter = 0.0f;

            foreach (Figure figure in figures)
            {
                perimeter += figure.GetPerimeter();
            }

            return perimeter;
        }

        /// <summary>
        /// Find all circles
        /// </summary>
        /// <returns></returns>
        public List<Figure> FindCircles()
        {
            List<Figure> circles = new List<Figure>();

            foreach (Figure figure in figures)
            {
                if(figure is Circle)
                {
                    circles.Add(figure);
                }
            }

            return circles;
        }

        /// <summary>
        /// Find all film figures
        /// </summary>
        /// <returns></returns>
        public List<Figure> FildFilmFigures()
        {
            List<Figure> filmFigures = new List<Figure>();

            foreach (Figure figure in figures)
            {
                if(figure is IFilmFigure)
                {
                    filmFigures.Add(figure);
                }
            }

            return filmFigures;
        }

        /// <summary>
        /// Return an enumerator that enumerates all elements of the set.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Figure> GetEnumerator()
        {
            return figures.GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return figures.GetEnumerator();
        }
    }
}
