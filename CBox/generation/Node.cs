using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace cbox.generation
{
    public class Node
    {
        public int Ident;
        public string Title;

        public int PosX;
        public int PosY;

        public int? BoundProblemIdent = null;
        public int? StartsProblemIdent = null;
        public bool EndsProblem = false;

        public List<string> ProvidesTags = new List<string>();

        public string Type { get; set; }
        public string Data { get; set; }

        public List<OutputSocket> OutputSockets = new List<OutputSocket>();

        [XmlIgnore]
        public Component ParentComponent = null;

        public Node()
        {
            Title = "Untitled";
        }

        public Node(string title="Untitled", bool create_default=false)
        {
            Title = title;

            if(create_default)
                this.AddSocket(new OutputSocket());
        }

        public OutputSocket FirstOutputSocket { get { return this.OutputSockets.First();  } }

        public void AddSocket(OutputSocket socket) 
        {
            this.OutputSockets.Add(socket);
            socket.ParentNode = this;
        }

        public void RemoveSocket(OutputSocket socket)
        {
            this.OutputSockets.Remove(socket);
            socket.ParentNode = null;
        }


        /// <summary>
        /// Updates all sockets to have this as their parent node.  This is
        /// called after derserializartion, as this reference cannot be serialized.
        /// </summary>
        internal void UpdateInternalReferences()
        {
            foreach (var socket in OutputSockets)
                socket.ParentNode = this;
        }
    }
}
