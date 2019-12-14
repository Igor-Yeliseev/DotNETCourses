using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Enum representing material types
    /// </summary>
    public enum Material
    {
        /// <summary>
        /// A paper material
        /// </summary>
        Paper,
        /// <summary>
        /// A film material
        /// </summary>
        Film
    }

    /// <summary>
    /// Class Class representing a factory 
    /// </summary>
    public class FiguresFactory
    {
        /// <summary>
        /// Сreating a specific figure
        /// </summary>
        /// <param name="material"> Material type</param>
        /// <param name="data"> Figure's data</param>
        /// <returns></returns>
        private Figure Create(Material material, params float[] data)
        {
            Figure figure = null;
            switch (material)
            {
                case Material.Paper:
                    switch(data.Length)
                    {
                        case 1:
                            figure = new CirclePaper(data[0]);
                            break;
                        case 2:
                            figure = new RectanglePaper(data[0], data[1]);
                            break;
                        case 3:
                            figure = new TrianglePaper(data[0], data[1], data[2]);
                            break;
                    }
                    break;
                case Material.Film:
                    switch (data.Length)
                    {
                        case 1:
                            figure = new CircleFilm(data[0]);
                            break;
                        case 2:
                            figure = new RectangleFilm(data[0], data[1]);
                            break;
                        case 3:
                            figure = new TriangleFilm(data[0], data[1], data[2]);
                            break;
                    }
                    break;
            }

            return figure;
        }

        /// <summary>
        /// Get a new circle
        /// </summary>
        /// <param name="material"> Material type</param>
        /// <param name="radius"> Circle radius</param>
        /// <returns></returns>
        public Figure GetFigure(Material material, float radius)
        {
            return Create(material, radius);
        }

        /// <summary>
        /// Get a new rectangle
        /// </summary>
        /// <param name="material"> Material type</param>
        /// <param name="width"> Width of a rectangle</param>
        /// <param name="height"> Height of a rectangle</param>
        /// <returns></returns>
        public Figure GetFigure(Material material, float width, float height)
        {
            return Create(material, width, height);
        }

        /// <summary>
        /// Get a new triangle
        /// </summary>
        /// <param name="material"> Material type</param>
        /// <param name="a"> First side of a triangle</param>
        /// <param name="b"> Second side of a triangle</param>
        /// <param name="c"> Third side of a triangle</param>
        /// <returns></returns>
        public Figure GetFigure(Material material, float a, float b, float c)
        {
            return Create(material, a, b, c);
        }
    }
}
