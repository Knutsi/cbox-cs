using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.generation.nodetype;

namespace cbox.generation
{
    public class ProblemSet
    {
        public int Ident;
        public string Title;
        public Node StartNode;
        public Node EndNode; 

        public List<Node> BoundNodes = new List<Node>();

        public List<Node> BountNodesPlusStartEnd
        {
            get
            {
                var newlist = new List<Node>();
                newlist.AddRange(BoundNodes);
                newlist.Add(StartNode);
                newlist.Add(EndNode);

                return newlist;
            }
        }

        public List<string> Classes
        {
            get 
            {
                var data = StartNode.HandlerData as ProblemStartData;
                return data.Classes;
            }
            
        }
    }
}
