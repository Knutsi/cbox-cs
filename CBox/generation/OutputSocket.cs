using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation
{
    public class OutputSocket
    {
        //public int Ident;
        public int? TargetNodeIdent;


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
    }
}
