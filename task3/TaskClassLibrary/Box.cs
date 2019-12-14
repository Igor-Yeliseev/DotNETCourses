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
        public int Count => figures.Count;

        /// <summary>
        /// Add a new figure
        /// </summary>
        /// <param name="item"> Figure </param>
        public void Add(Figure item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if(figures.Count == 20)
            {
                throw new Exception("The box if full.");
            }

            if (!figures.Contains(item))
            {
                figures.Add(item);
            }
        }

        /// <summary>
        /// Extract figure by indext
        /// </summary>
        /// <param name="index"> Indext of the figure</param>
        /// <returns></returns>
        public Figure Extract(int index)
        {
            if(figures.ElementAt(index) == null)
            {
                throw new ArgumentNullException();
            }

            Figure figure = figures.ElementAt(index);

            Remove(figure);

            return figure;
        }
        
        /// <summary>
        /// Удалить элемент из множества.
        /// </summary>
        /// <param name="item"> Удаляемый элемент данных. </param>
        public void Remove(Figure item)
        {
            // Проверяем входные данные на пустоту.
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            // Если коллекция не содержит данный элемент, то мы не можем его удалить.
            if (!figures.Contains(item))
            {
                throw new KeyNotFoundException($"Элемент {item} не найден в множестве.");
            }

            // Удаляем элемент из коллекции.
            figures.Remove(item);
        }

        /// <summary>
        /// Total area of all figures
        /// </summary>
        /// <returns></returns>
        public float TotalArea()
        {
            float area = 0.0f;

            foreach (Figure figure in figures)
            {
                area += figure.GetArea();
            }

            return area;
        }

        /// <summary>
        /// Total perimeter of all figures
        /// </summary>
        /// <returns></returns>
        public float TotalPerimeter()
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
        /// Вернуть перечислитель, выполняющий перебор всех элементов множества.
        /// </summary>
        /// <returns> Перечислитель, который можно использовать для итерации по коллекции. </returns>
        public IEnumerator<Figure> GetEnumerator()
        {
            // Используем перечислитель списка элементов данных множества.
            return figures.GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            // Используем перечислитель списка элементов данных множества.
            return figures.GetEnumerator();
        }
    }
}
