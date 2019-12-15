using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using FiguresClassLibrary;

namespace TaskClassLibrary
{
    /// <summary>
    /// Class representing a box of 20 figures
    /// </summary>
    public class Box
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
        /// Write all figures to XML file with XmlWriter
        /// </summary>
        /// <param name="path"> File path</param>
        public void WriteToXml(string path)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            using (XmlWriter writer = XmlWriter.Create(path, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Figures");
                foreach (Figure figure in figures)
                {
                    writer.WriteStartElement("Figure");
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
        /// Write marterial figures to XML file with XmlWriter
        /// </summary>
        /// <param name="material"> Material type</param>
        /// <param name="path"> File path</param>
        public void WriteToXml(Material material, string path)
        {
            Type figureType = (material == Material.Paper) ? typeof(IPaperFigure) : typeof(IFilmFigure);
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            using (XmlWriter writer = XmlWriter.Create(path, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Figures");
                foreach (Figure figure in figures)
                {
                    if (figureType.IsAssignableFrom(figure.GetType()))
                    {
                        writer.WriteStartElement("Figure");
                        if (figureType == typeof(IPaperFigure))
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
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        /// <summary>
        /// Read all figures from XML file with XmlReader
        /// </summary>
        /// <param name="path"> File path</param>
        /// <returns> Figures collection</returns>
        public static Box ReadFromXml(string path)
        {
            Figure figure = null;
            Box box = new Box();
            Сoloring color = Сoloring.None;
            bool isColored = false;

            using (XmlReader reader = XmlReader.Create(path))
            {
                while (reader.Read())
                {
                    if(reader.NodeType == XmlNodeType.Element && reader.Name == "Figure")
                    {
                        string shape = reader.GetAttribute("shape");
                        // Colored figure (third attribute - color)
                        if(reader.AttributeCount == 2)
                        {
                            color = (Сoloring)int.Parse(reader.GetAttribute("color"));
                            isColored = true;
                        }
                        // Get colorless figure
                        figure = LoadFigure(reader, shape);
                        // Paint if it is a paper figure 
                        if(isColored)
                        {
                            Painter.Colorize(figure, color);
                            isColored = false;
                        }
                        box.Add(figure);
                    }
                }
            }

            return box;
        }

        /// <summary>
        /// Get a colorless figure
        /// </summary>
        /// <param name="reader"> XmlReader instance</param>
        /// <param name="shape"> Figure type</param>
        /// <returns></returns>
        private static Figure LoadFigure(XmlReader reader, string shape)
        {
            Figure figure = null;
            float radius, width, height, a, b, c;
            FiguresFactory factory = new FiguresFactory();
            Material material = (reader.AttributeCount == 2)? Material.Paper : Material.Film;

            reader.Read();
            reader.Read();
            switch (shape)
            {
                case "Circle":
                    radius = float.Parse(reader.ReadInnerXml());
                    figure = factory.GetFigure(material, radius);
                    break;
                case "Rectangle":
                    width = float.Parse(reader.ReadInnerXml());
                    reader.Read();
                    height = float.Parse(reader.ReadInnerXml());
                    figure = factory.GetFigure(material, width, height);
                    break;
                case "Triangle":
                    a = float.Parse(reader.ReadInnerXml());
                    reader.Read();
                    b = float.Parse(reader.ReadInnerXml());
                    reader.Read();
                    c = float.Parse(reader.ReadInnerXml());
                    figure = factory.GetFigure(material, a, b, c);
                    break;
            }

            return figure;
        }
        
        /// <summary>
        /// Write all figures to XML file with StreamWriter
        /// </summary>
        /// <param name="path"> File path</param>
        public void StreamWriteToXml(string path)
        {
            StreamWriter stream = new StreamWriter(path);
            XDocument xmlDocument = new XDocument();
            XElement xmlFigures = new XElement("Figures");

            foreach (Figure figure in figures)
            {
                XElement xmlFigure = new XElement("Figure");
                if (figure is IPaperFigure)
                {
                    int colorIndex = (int)(figure as IPaperFigure).Сolor;
                    xmlFigure.SetAttributeValue("color", colorIndex.ToString());
                }
                if (figure is Circle)
                {
                    Circle circle = figure as Circle;
                    xmlFigure.SetAttributeValue("shape", "Circle");
                    XElement xmlRadius = new XElement("Radius", circle.Radius.ToString());
                    xmlFigure.Add(xmlRadius);
                }
                else if (figure is Rectangle)
                {
                    Rectangle rect = figure as Rectangle;
                    xmlFigure.SetAttributeValue("shape", "Rectangle");
                    XElement xmlWidth = new XElement("Width", rect.Width.ToString());
                    XElement xmlHeight = new XElement("Height", rect.Height.ToString());
                    xmlFigure.Add(xmlWidth, xmlHeight);
                }
                else if (figure is Triangle)
                {
                    Triangle triangle = figure as Triangle;
                    xmlFigure.SetAttributeValue("shape", "Triangle");
                    XElement xmlSideA = new XElement("SideA", triangle.SideA.ToString());
                    XElement xmlSideB = new XElement("SideB", triangle.SideB.ToString());
                    XElement xmlSideC = new XElement("SideC", triangle.SideC.ToString());
                    xmlFigure.Add(xmlSideA, xmlSideB, xmlSideC);
                }
                xmlFigures.Add(xmlFigure);
            }
            xmlDocument.Add(xmlFigures);
            xmlDocument.Save(stream);
            stream.Close();
        }

        /// <summary>
        /// Write marterial figures to XML file with StreamWriter
        /// </summary>
        /// <param name="material"> Material type</param>
        /// <param name="path"> File path</param>
        public void StreamWriteToXml(Material material, string path)
        {
            Type figureType = (material == Material.Paper) ? typeof(IPaperFigure) : typeof(IFilmFigure);
            StreamWriter stream = new StreamWriter(path);
            XDocument xmlDocument = new XDocument();
            XElement xmlFigures = new XElement("Figures");

            foreach (Figure figure in figures)
            {
                if (figureType.IsAssignableFrom(figure.GetType()))
                {
                    XElement xmlFigure = new XElement("Figure");
                    if (figure is IPaperFigure)
                    {
                        int colorIndex = (int)(figure as IPaperFigure).Сolor;
                        xmlFigure.SetAttributeValue("color", colorIndex.ToString());
                    }
                    if (figure is Circle)
                    {
                        Circle circle = figure as Circle;
                        xmlFigure.SetAttributeValue("shape", "Circle");
                        XElement xmlRadius = new XElement("Radius", circle.Radius.ToString());
                        xmlFigure.Add(xmlRadius);
                    }
                    else if (figure is Rectangle)
                    {
                        Rectangle rect = figure as Rectangle;
                        xmlFigure.SetAttributeValue("shape", "Rectangle");
                        XElement xmlWidth = new XElement("Width", rect.Width.ToString());
                        XElement xmlHeight = new XElement("Height", rect.Height.ToString());
                        xmlFigure.Add(xmlWidth, xmlHeight);
                    }
                    else if (figure is Triangle)
                    {
                        Triangle triangle = figure as Triangle;
                        xmlFigure.SetAttributeValue("shape", "Triangle");
                        XElement xmlSideA = new XElement("SideA", triangle.SideA.ToString());
                        XElement xmlSideB = new XElement("SideB", triangle.SideB.ToString());
                        XElement xmlSideC = new XElement("SideC", triangle.SideC.ToString());
                        xmlFigure.Add(xmlSideA, xmlSideB, xmlSideC);
                    }
                    xmlFigures.Add(xmlFigure);
                }
            }
            xmlDocument.Add(xmlFigures);
            xmlDocument.Save(stream);
            stream.Close();
        }
        
        /// <summary>
        /// Read all figures from XML file with StreamReader
        /// </summary>
        /// <param name="path"> File path</param>
        /// <returns></returns>
        public static Box StreamReadFromXml(string path)
        {
            Figure figure = null;
            Сoloring color = Сoloring.None;
            bool isColored = false;
            Box box = new Box();
            StreamReader stream = new StreamReader(path);
            XDocument xmlDocument = XDocument.Load(stream);
            XElement xmlRoot = xmlDocument.Element("Figures");

            foreach (XElement xmlElem in xmlRoot.Elements("Figure").ToList())
            {
                string shape = xmlElem.Attribute("shape").Value;
                // Colored figure (third attribute - color)
                if (xmlElem.Attributes().Count() == 2)
                {
                    color = (Сoloring)int.Parse(xmlElem.Attribute("color").Value);
                    isColored = true;
                }
                // Get colorless figure
                figure = LoadFigure(xmlElem, shape);
                // Paint if it is a paper figure 
                if (isColored)
                {
                    Painter.Colorize(figure, color);
                    isColored = false;
                }
                box.Add(figure);
            }
            stream.Close();
            return box;
        }
        
        /// <summary>
        /// Get a colorless figure
        /// </summary>
        /// <param name="xmlElement"> XmlReader instance</param>
        /// <param name="shape"> Figure type</param>
        /// <returns></returns>
        private static Figure LoadFigure(XElement xmlElement, string shape)
        {
            Figure figure = null;
            float radius, width, height, a, b, c;
            FiguresFactory factory = new FiguresFactory();
            Material material = (xmlElement.Attributes().Count() == 2) ? Material.Paper : Material.Film;

            switch (shape)
            {
                case "Circle":
                    radius = float.Parse(xmlElement.Element("Radius").Value);
                    figure = factory.GetFigure(material, radius);
                    break;
                case "Rectangle":
                    width = float.Parse(xmlElement.Element("Width").Value);
                    height = float.Parse(xmlElement.Element("Height").Value);
                    figure = factory.GetFigure(material, width, height);
                    break;
                case "Triangle":
                    a = float.Parse(xmlElement.Element("SideA").Value);
                    b = float.Parse(xmlElement.Element("SideB").Value);
                    c = float.Parse(xmlElement.Element("SideC").Value);
                    figure = factory.GetFigure(material, a, b, c);
                    break;
            }

            return figure;
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

            Box box = obj as Box;
            if (box == null)
                return false;
            
            if(box.GetCount() != GetCount())
            {
                return false;
            }

            bool answer = true;

            for (int i = 1; i <= GetCount(); i++)
            {
                if(!box.ShowFigure(i).Equals(ShowFigure(i)))
                {
                    answer = false;
                }
            }
            
            return answer;
        }

        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (2 * figures.GetHashCode() + 5);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Box with " + figures.Count + " figures";
        }
    }
}
