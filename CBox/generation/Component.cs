using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

using System.Runtime.Serialization;

namespace cbox.generation
{
    public class Component : IdentProvider
    {
        public bool IsRoot = false;

        public List<Node> Nodes = new List<Node>();

        private List<BuildPath> _BuildPaths = null;

        /// <summary>
        /// Adds a node to the model.
        /// </summary>
        /// <param name="node"></param>
        public void Add(Node node)
        {
            node.Ident = this.NextIdent;
            this.Nodes.Add(node);
        }


        public void Add(params Node[] nodes)
        {
            foreach (var node in nodes)
                Add(node);
        }

        /// <summary>
        /// removes a node and clears all inbout and output connections.
        /// </summary>
        /// <param name="node"></param>
        public void Remove(Node node)
        {
            this.Nodes.Remove(node);

            // disconnect all output sockets leading to the removed ones:
            foreach (var socket in AllOutputSockets)
                if (socket.DoesTarget(node))
                    socket.Disconnect();
        }

        /// <summary>
        /// Returns all output sockets in the model.
        /// </summary>
        [XmlIgnore] 
        public List<OutputSocket> AllOutputSockets
        {
            get
            {
                var sockets = new List<OutputSocket>();
                foreach (var node in this.Nodes)
                    foreach (var socket in node.OutputSockets)
                        sockets.Add(socket);

                return sockets;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [XmlIgnore] 
        public List<Connection> Connections
        {

            get
            {
                var connections = new List<Connection>();

                foreach (var node in Nodes)
                {
                    foreach (var socket in node.OutputSockets)
                    {
                        if (socket.IsConnected)
                        {
                            var con = new Connection()
                            {
                                FromSocket = socket,
                                FromNode = node,
                                ToNode = NodeByIdent(socket.TargetNodeIdent.Value)
                            };

                            connections.Add(con);
                        }
                    }
                }

                return connections;
            }
        }

        /// <summary>
        /// Gets the single node with mathcing ident, or null.
        /// </summary>
        /// <param name="ident"></param>
        /// <returns></returns>
        private Node NodeByIdent(int ident)
        {
            foreach (var node in Nodes)
                if (node.Ident == ident)
                    return node;

            return null;
        }


        /// <summary>
        /// Gives nodes with a matching title.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public List<Node> NodesByTitle(string title)
        {
            var list = new List<Node>();

            foreach (var node in Nodes)
                if (node.Title == title)
                    list.Add(node);

            return list;
        }

        public string ToXML()
        {
            // prepare to serialize:
            var serializer = new XmlSerializer(this.GetType());

            /* Create a StreamWriter to write with. First create a FileStream
            object, and create the StreamWriter specifying an Encoding to use. */
            using (MemoryStream ms = new MemoryStream())
            {
                using(TextWriter writer = new StreamWriter(ms, new UTF8Encoding()))
                {
                    // Serialize using the XmlTextWriter.
                    serializer.Serialize(writer, this);

                    ms.Position = 0;
                    StreamReader reader = new StreamReader(ms);
                    return reader.ReadToEnd();
                }
            }
        }


        /// <summary>
        /// Loads the model from XML.
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static Component FromXML(string xml)
        {
            using (var reader = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(Component));
                return (Component)serializer.Deserialize(reader);
            }
        }


        /// <summary>
        /// Generates a list of build paths.
        /// </summary>
        private List<BuildPath> GenerateBuildPaths()
        {
            return null;
        }

        public List<BuildPath> BuildPaths { 
            get { 
                // use cached build path if possible:
                if (_BuildPaths == null)
                    _BuildPaths = GenerateBuildPaths();

                return _BuildPaths;
            } 
        }


    }
}
