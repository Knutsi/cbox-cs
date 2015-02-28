using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace cbox.generation
{
    public enum OutputSocketType
    {
        GUARANTEED,
        POSSIBLE
    }

    public class OutputSocket
    {
        public int? TargetNodeIdent;
        public string Label;
        public OutputSocketType Type = OutputSocketType.GUARANTEED;


        [XmlIgnore]
        public Node ParentNode;

        public void Connect(Node node)
        {
            this.TargetNodeIdent = node.Ident;
        }


        public void Disconnect()
        {
            this.TargetNodeIdent = null;
        }


        public bool IsConnected 
        {
            get
            {
                return TargetNodeIdent.HasValue;
            }

        }
       
        public bool DoesTarget(Node node)
        {
            return node.Ident == TargetNodeIdent;
        }

        [XmlIgnore]
        public Node TargetNode 
        {
            get
            {
                if (!IsConnected)
                    return null;

                return ParentNode.ParentComponent.NodeByIdent(TargetNodeIdent.Value);
            }
        }

        public string ToString()
        {
            return String.Format("Socket '{0}' ({1}), target: {2}", this.Label, this.Type, this.TargetNode);
        }
    }
}
