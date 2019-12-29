using System.IO;
using System.Xml.Serialization;

namespace BinaryTreeLibrary
{
    /// <summary>
    /// A class representing xml serializer of a binary tree
    /// </summary>
    public class TreeSerializer
    {
        /// <summary>
        /// Serialize a binary tree
        /// </summary>
        /// <param name="tree"> Binary tree instance</param>
        /// <param name="path"> File path</param>
        public static void Serialize(Tree<Student> tree, string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Tree<Student>));
            
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, tree);
            }
        }

        /// <summary>
        /// Deserialize a binary tree from xml file
        /// </summary>
        /// <param name="path"> File path</param>
        /// <returns></returns>
        public static Tree<Student> Deserialize(string path)
        {
            Tree<Student> tree = null;

            XmlSerializer formatter = new XmlSerializer(typeof(Tree<Student>));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                tree = (Tree<Student>)formatter.Deserialize(fs);
            }

            return tree;
        }
    }
}
