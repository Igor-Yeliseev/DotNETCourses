using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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
            if(figures[number - 1] == null)
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
        /// Write all figures to XML file
        /// </summary>
        /// <param name="path"> File path</param>
        public void WriteToXml(string path)
        {
            using (XmlWriter writer = XmlWriter.Create(path))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Figures");
                foreach (Figure figure in figures)
                {
                    writer.WriteStartElement("Figure");
                    writer.WriteAttributeString("type", figure.GetType().ToString());
                    if (figure is IPaperFigure)
                    {
                        int colorIndex = (int)(figure as IPaperFigure).Сolor;
                        writer.WriteAttributeString("color", colorIndex.ToString());
                    }
                    if (figure is Circle)
                    {
                        Circle circle = figure as Circle;
                        writer.WriteAttributeString("shape", "Circle");
                        writer.WriteElementString("Radius", circle.Radius.ToString());
                        writer.WriteEndElement();
                    }
                    else if (figure is Rectangle)
                    {
                        Rectangle rect = figure as Rectangle;
                        writer.WriteAttributeString("shape", "Rectangle");
                        writer.WriteElementString("Width", rect.Width.ToString());
                        writer.WriteElementString("Height", rect.Height.ToString());
                        writer.WriteEndElement();
                    }
                    else if (figure is Triangle)
                    {
                        Triangle triangle = figure as Triangle;
                        writer.WriteAttributeString("shape", "Triangle");
                        writer.WriteElementString("SideA", triangle.SideA.ToString());
                        writer.WriteElementString("SideB", triangle.SideB.ToString());
                        writer.WriteElementString("SideC", triangle.SideC.ToString());
                        writer.WriteEndElement();
                    }
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        /// <summary>
        /// Write marterial figures to XML file
        /// </summary>
        /// <param name="material"> Material type</param>
        /// <param name="path"> File path</param>
        public void WriteToXml(Material material, string path)
        {
            Type figureType = (material == Material.Paper) ? typeof(IPaperFigure) : typeof(IFilmFigure);
            
            using (XmlWriter writer = XmlWriter.Create(path))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement($"{material}Figures");
                foreach (Figure figure in figures)
                {
                    if (figureType.IsAssignableFrom(figure.GetType()))
                    {
                        writer.WriteStartElement("Figure");
                        writer.WriteAttributeString("type", figure.GetType().ToString());
                        if (figureType == typeof(IPaperFigure))
                        {
                            int colorIndex = (int)(figure as IPaperFigure).Сolor;
                            writer.WriteElementString("Color", colorIndex.ToString());
                        }
                        if (figure is Circle)
                        {
                            Circle circle = figure as Circle;
                            writer.WriteElementString("Radius", circle.Radius.ToString());
                            writer.WriteEndElement();
                        }
                        else if (figure is Rectangle)
                        {
                            Rectangle rect = figure as Rectangle;
                            writer.WriteElementString("Width", rect.Width.ToString());
                            writer.WriteElementString("Height", rect.Height.ToString());
                            writer.WriteEndElement();
                        }
                        else if (figure is Triangle)
                        {
                            Triangle triangle = figure as Triangle;
                            writer.WriteElementString("SideA", triangle.SideA.ToString());
                            writer.WriteElementString("SideB", triangle.SideB.ToString());
                            writer.WriteElementString("SideC", triangle.SideC.ToString());
                            writer.WriteEndElement();
                        }
                    }
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        /// <summary>
        /// Read all figures from XML file
        /// </summary>
        /// <param name="path"> File path</param>
        public static Box ReadFromXml(string path)
        {
            Figure figure = null;
            Box box = new Box();
            Сoloring color = Сoloring.None;
            bool isColored = false;

            using (XmlReader reader = XmlReader.Create(path))
            {
                int count = 0;

                while (reader.Read())
                {
                    if(reader.NodeType == XmlNodeType.Element && reader.Name == "Figure")
                    {
                        //string type = reader.GetAttribute("type");
                        //figType = Type.GetType(type + ", FiguresClassLibrary", false, true);
                        //Console.WriteLine(figType.Equals(typeof(CirclePaper)));
                        string shape = reader.GetAttribute("shape");
                        
                        if(reader.AttributeCount == 3)
                        {
                            color = (Сoloring)int.Parse(reader.GetAttribute("color"));
                            isColored = true;
                        }

                        figure = LoadFigure(reader, shape);

                        if(isColored)
                            Painter.Colorize(figure, color);
                        isColored = false;

                        box.Add(figure);

                        count++;
                    }
 
                }
            }

            return box;
        }

        /// <summary>
        /// Get a blend figure
        /// </summary>
        /// <param name="reader"> XmlReader instance</param>
        /// <param name="shape"> Figure type</param>
        /// <returns></returns>
        private static Figure LoadFigure(XmlReader reader, string shape)
        {
            Figure figure = null;
            float radius, width, height, a, b, c;
            FiguresFactory factory = new FiguresFactory();
            Material material = (reader.AttributeCount == 3)? Material.Paper : Material.Film;
            reader.Read();
            switch (shape)
            {
                case "Circle":
                    //reader.Read();
                    radius = float.Parse(reader.ReadInnerXml());
                    figure = factory.GetFigure(material, radius);
                    break;
                case "Rectangle":
                    //reader.Read();
                    width = float.Parse(reader.ReadInnerXml());
                    //reader.Read();
                    height = float.Parse(reader.ReadInnerXml());
                    figure = factory.GetFigure(material, width, height);
                    break;
                case "Triangle":
                    //reader.Read();
                    a = float.Parse(reader.ReadInnerXml());
                    b = float.Parse(reader.ReadInnerXml());
                    c = float.Parse(reader.ReadInnerXml());
                    figure = factory.GetFigure(material, a, b, c);
                    break;
            }
            
            return figure;
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






/*
 *                                     break;
                                case "Color":
                                    color = (Сoloring)(int.Parse(reader.ReadInnerXml()));
                                    isColored = true;
                                    break;
                                case "Radius":
                                    data.Add(float.Parse(reader.ReadInnerXml()));
                                    break;
                                case "Width":
                                    data.Add(float.Parse(reader.ReadInnerXml()));
                                    break;
                                case "Height":
                                    data.Add(float.Parse(reader.ReadInnerXml()));
                                    break;
                                case "SideA":
                                    data.Add(float.Parse(reader.ReadInnerXml()));
                                    break;
                                case "SideB":
                                    data.Add(float.Parse(reader.ReadInnerXml()));
                                    break;
                                case "SideC":
                                    data.Add(float.Parse(reader.ReadInnerXml()));
                                    break;
*/