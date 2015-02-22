using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace cbox.generation
{
    public class OutputSocket
    {
        //public int Ident;
        public int? TargetNodeIdent;

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

        public Node TargetNode 
        {
            get
            {
                if (!IsConnected)
                    return null;

                return ParentNode.ParentComponent.NodeByIdent(TargetNodeIdent.Value);
            }
        }
    }
}
