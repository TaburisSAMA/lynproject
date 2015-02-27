using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Text;
using MovieBrowser.Model;

namespace MovieBrowser.Controller
{
    /// <summary>
    /// Summary description for TreeViewSerializer.
    /// </summary>
    public class VirtualMovieFolderSerializer
    {

        // Xml tag for node, e.g. 'node' in case of <node></node>
        private const string XmlMovieTag = "movie";

        // Xml attributes for node e.g. <node text="Asia" tag="" imageindex="1"></node>
        private const string XmlMovieTitle = "title";
        private const string XmlMovieRating = "rating";
        private const string XmlMovieYear = "year";
        private const string XmlMovieImdb = "imdb";
        private const string XmlMovieFilename = "filename";
        private const string XmlMovieIsValid = "valid";
        private const string XmlMovieIsFolder = "folder";
        private const string XmlMovieImageIndex = "imageindex";


        public Movie DeserializeTreeView(string fileName)
        {

            var root = new Movie();

            Movie parentMovie = null;

            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader(fileName);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == XmlMovieTag)
                        {
                            var newMovie = new Movie();
                            newMovie.IsVirtual = true;
                            bool isEmptyElement = reader.IsEmptyElement;

                            // loading node attributes
                            int attributeCount = reader.AttributeCount;
                            if (attributeCount > 0)
                            {
                                for (int i = 0; i < attributeCount; i++)
                                {
                                    reader.MoveToAttribute(i);
                                    SetAttributeValue(newMovie, reader.Name, reader.Value);
                                }
                            }

                            if (parentMovie != null)
                            {
                                newMovie.Parent = parentMovie;
                                parentMovie.Children.Add(newMovie);
                            }
                            else
                            {
                                newMovie.Parent = root;
                                root.Children.Add(newMovie);
                            }

                            // making current node 'ParentNode' if its not empty);
                            if (!isEmptyElement)
                            {
                                parentMovie = newMovie;
                            }

                        }
                    }
                    // moving up to in TreeView if end tag is encountered
                    else if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        if (reader.Name == XmlMovieTag)
                        {
                            parentMovie = parentMovie.Parent;
                        }
                    }
                    else if (reader.NodeType == XmlNodeType.XmlDeclaration)
                    {
                        //Ignore Xml Declaration                    
                    }
                    else if (reader.NodeType == XmlNodeType.None)
                    {
                        return null;
                    }
                }
            }
            finally
            {
                reader.Close();
            }

            return root;
        }


        private static void SetAttributeValue(Movie node, string propertyName, string value)
        {
            if (propertyName == XmlMovieTitle)
            {
                node.Title = value;
            }
            else if (propertyName == XmlMovieFilename)
            {
                node.FilePath = value;
            }
            else if (propertyName == XmlMovieImdb)
            {
                node.ImdbId = value;
            }
            else if (propertyName == XmlMovieRating)
            {
                node.Rating = double.Parse(value);
            }
            else if (propertyName == XmlMovieYear)
            {
                node.Year = int.Parse(value);
            }
            else if (propertyName == XmlMovieIsValid)
            {
                node.IsValidMovie = bool.Parse(value);
            }
            else if (propertyName == XmlMovieIsFolder)
            {
                node.IsFolder = bool.Parse(value);
            }
        }

        public void LoadXmlFileInTreeView(TreeView treeView, string fileName)
        {
            XmlTextReader reader = null;
            try
            {
                treeView.BeginUpdate();
                reader = new XmlTextReader(fileName);

                TreeNode n = new TreeNode(fileName);
                treeView.Nodes.Add(n);
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        bool isEmptyElement = reader.IsEmptyElement;
                        StringBuilder text = new StringBuilder();
                        text.Append(reader.Name);
                        int attributeCount = reader.AttributeCount;
                        if (attributeCount > 0)
                        {
                            text.Append(" ( ");
                            for (int i = 0; i < attributeCount; i++)
                            {
                                if (i != 0) text.Append(", ");
                                reader.MoveToAttribute(i);
                                text.Append(reader.Name);
                                text.Append(" = ");
                                text.Append(reader.Value);
                            }
                            text.Append(" ) ");
                        }

                        if (isEmptyElement)
                        {
                            n.Nodes.Add(text.ToString());
                        }
                        else
                        {
                            n = n.Nodes.Add(text.ToString());
                        }
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        n = n.Parent;
                    }
                    else if (reader.NodeType == XmlNodeType.XmlDeclaration)
                    {

                    }
                    else if (reader.NodeType == XmlNodeType.None)
                    {
                        return;
                    }
                    else if (reader.NodeType == XmlNodeType.Text)
                    {
                        n.Nodes.Add(reader.Value);
                    }

                }
            }
            finally
            {
                treeView.EndUpdate();
                reader.Close();
            }
        }


        public void SerializeTreeView(StringCollection rootPaths, string fileName)
        {
            var xmlTextWriter = new XmlTextWriter(fileName, System.Text.Encoding.Unicode);

            // Format the xml automatically to a tree structure
            xmlTextWriter.Formatting = Formatting.Indented;

            xmlTextWriter.Indentation = 4;
            // writing the xml declaration tag
            xmlTextWriter.WriteStartDocument();
            //textWriter.WriteRaw("\r\n");
            // writing the main tag that encloses all node tags
            xmlTextWriter.WriteStartElement("Movies");

            foreach (var rootPath in rootPaths)
            {

                var directoryInfo = new DirectoryInfo(rootPath);
                SaveNodes(directoryInfo, xmlTextWriter);


            }
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.Close();
        }



        private static void SaveNodes(DirectoryInfo nodesCollection, XmlTextWriter textWriter)
        {
            Movie dirMovie = Movie.FromFolderName(nodesCollection.FullName);
            textWriter.WriteStartElement(XmlMovieTag);
            textWriter.WriteAttributeString(XmlMovieFilename, dirMovie.FilePath);
            textWriter.WriteAttributeString(XmlMovieImageIndex, dirMovie.ImageIndex.ToString());
            textWriter.WriteAttributeString(XmlMovieImdb, dirMovie.ImdbId);
            textWriter.WriteAttributeString(XmlMovieIsValid, dirMovie.IsValidMovie.ToString());
            textWriter.WriteAttributeString(XmlMovieIsFolder, true.ToString());
            textWriter.WriteAttributeString(XmlMovieRating, dirMovie.Rating.ToString());
            textWriter.WriteAttributeString(XmlMovieTitle, dirMovie.Title);
            textWriter.WriteAttributeString(XmlMovieYear, dirMovie.Year.ToString());

            foreach (DirectoryInfo node in nodesCollection.GetDirectories())
            {
                // add other node properties to serialize here
                SaveNodes(node, textWriter);
            }

            foreach (var fileInfo in nodesCollection.GetFiles())
            {
                Movie fileMovie = Movie.FromFolderName(fileInfo.FullName);

                textWriter.WriteStartElement(XmlMovieTag);
                textWriter.WriteAttributeString(XmlMovieFilename, fileMovie.FilePath);
                textWriter.WriteAttributeString(XmlMovieImageIndex, fileMovie.ImageIndex.ToString());
                textWriter.WriteAttributeString(XmlMovieImdb, fileMovie.ImdbId);
                textWriter.WriteAttributeString(XmlMovieIsValid, fileMovie.IsValidMovie.ToString());
                textWriter.WriteAttributeString(XmlMovieIsFolder, false.ToString());
                textWriter.WriteAttributeString(XmlMovieRating, fileMovie.Rating.ToString());
                textWriter.WriteAttributeString(XmlMovieTitle, fileMovie.Title);
                textWriter.WriteAttributeString(XmlMovieYear, fileMovie.Year.ToString());
                textWriter.WriteEndElement();
            }
            textWriter.WriteEndElement();
        }

        public void SerializeTreeView(List<Movie> rootPaths, string fileName)
        {
            var xmlTextWriter = new XmlTextWriter(fileName, Encoding.Unicode);

            // Format the xml automatically to a tree structure
            xmlTextWriter.Formatting = Formatting.Indented;

            xmlTextWriter.Indentation = 4;
            // writing the xml declaration tag
            xmlTextWriter.WriteStartDocument();
            //textWriter.WriteRaw("\r\n");
            // writing the main tag that encloses all node tags
            xmlTextWriter.WriteStartElement("Movies");

            foreach (var rootPath in rootPaths)
            {
                SaveNodes(rootPath, xmlTextWriter);
            }
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.Close();
        }



        private static void SaveNodes(Movie dirMovie, XmlTextWriter textWriter)
        {
           
            textWriter.WriteStartElement(XmlMovieTag);
            textWriter.WriteAttributeString(XmlMovieFilename, dirMovie.FilePath);
            textWriter.WriteAttributeString(XmlMovieImageIndex, dirMovie.ImageIndex.ToString());
            textWriter.WriteAttributeString(XmlMovieImdb, dirMovie.ImdbId);
            textWriter.WriteAttributeString(XmlMovieIsValid, dirMovie.IsValidMovie.ToString());
            textWriter.WriteAttributeString(XmlMovieIsFolder, dirMovie.IsFolder.ToString());
            textWriter.WriteAttributeString(XmlMovieRating, dirMovie.Rating.ToString());
            textWriter.WriteAttributeString(XmlMovieTitle, dirMovie.Title);
            textWriter.WriteAttributeString(XmlMovieYear, dirMovie.Year.ToString());

            foreach (var node in dirMovie.Children)
            {
                // add other node properties to serialize here
                SaveNodes(node, textWriter);
            }
            textWriter.WriteEndElement();
        }


    }
}
