using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

using cbox.generation.nodetype;

namespace cbox.generation
{
    public class Node
    {
        public int Ident;
        public string Title;

        public int PosX;
        public int PosY;

        public List<string> ProvidesTags = new List<string>();

        public string Type { get; set; }
        public string XmlData { get; set; }

        [XmlIgnore]
        public object HandlerData { get { return Handler.HandlerData; } }

        [XmlIgnore]
        public INodeType Handler { get; set; }

        [XmlIgnore]
        public bool StartsProblem { get { return this.Handler.StartsProblem; } }

        [XmlIgnore]
        public bool EndsProblem { get { return this.Handler.EndsProblem; } }

        [XmlIgnore]
        public List<OutputSocket> OutputSockets { get { return this.Handler.OutputSockets; } }

        [XmlIgnore]
        public List<List<OutputSocket>> PossibleOutputCombos { get { return this.Handler.PossibleOutputCombos; } }

        [XmlIgnore]
        public NodeCollection ParentComponent = null;


        public Node()
        {

        }

        public Node(string title="Untitled", string type=BaseType.TYPE_IDENT, bool create_default=false)
        {
            Title = title;
            ChangeType(type);
            Handler = TypeHandlerLibrary.GetHandler(this);

            if(create_default)
                this.AddSocket(new OutputSocket());
        }

        public ProblemSet BoundProblem
        {
            get
            {
                return this.ParentComponent.ProblemSetByNode(this);
            }
        }

        public OutputSocket FirstOutputSocket { 
            get 
            {
                if (this.OutputSockets.Count > 0)
                    return this.OutputSockets.First();
                else
                    return null;
            } 
        }

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
        /// Updates all sockets to have this as their parent node and restores handler.  
        /// This is called after derserializartion, as these fields cannot be serialzied.
        /// </summary>
        public void UpdateInternals()
        {
            if(Handler == null)
                Handler = TypeHandlerLibrary.GetHandler(this);

            foreach (var socket in OutputSockets)
                socket.ParentNode = this;
        }

       

        public void ChangeType(string new_type)
        {
            Type = new_type;
            
            // type changes changes handler, and makes data incompatible.  We need to erase it:
            XmlData = null;
            Handler = null;

            // this will fix handler and it's data, and set sockets to correct home:
            UpdateInternals();
        }

        public override string ToString()
        {
            return String.Format("Node: \"{0}\":{1}({2})", this.Title, this.Ident, this.Type);
        }
    }

}
