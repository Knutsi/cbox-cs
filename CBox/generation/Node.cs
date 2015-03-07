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
        public INodeTypeData HandlerData { 
            get { return Handler.HandlerData; }
            set { this.Handler.HandlerData = value; }
        }

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

        public Node(string title="Untitled", string type=BaseType.TYPE_IDENT)
        {
            Title = title;
            ChangeType(type);
        }

        public ProblemSet BoundProblemSet
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



        public void ChangeType(string new_type)
        {
            this.Type = new_type;

            // type changes changes handler, and makes data incompatible.  We need to erase it:
            this.XmlData = null;
            this.Handler = null;

            // this will fix handler and it's data, and set sockets to correct home:
            UpdateInternals();
        }

        /// <summary>
        /// After deserialization or handler change, nodes need to update it's data, reinstance it's
        /// handler and ensure it has data.  All sockets also need to have their respective parents
        /// set (us!). 
        /// </summary>
        public void UpdateInternals()
        {
            // if no handler, load the correct one:
            if (Handler == null)
                Handler = TypeHandlerLibrary.GetHandler(this);

            // if no handler data, load the default one:
            if (XmlData == null || XmlData == string.Empty)
            {
                XmlData = Handler.DefaultData.ToXML();
                Handler.LoadData();
            }

            // ensure all output sockets are set to this:
            foreach (var socket in OutputSockets)
                socket.ParentNode = this;
        }



        public override string ToString()
        {
            return String.Format("Node: \"{0}\":{1}({2})", this.Title, this.Ident, this.Type);
        }

        /// <summary>
        /// Evalutes the node.
        /// </summary>
        /// <param name="ctx"></param>
        public void Eval(ExecutionContext ctx)
        {
            Handler.Eval(ctx);
        }

        /// <summary>
        /// Asks handler to describe outputs possible from this node.
        /// </summary>
        /// <param name="ctx"></param>
        public void Describe(ExecutionContext ctx)
        {
            Handler.Describe(ctx);
        }

    }

}
