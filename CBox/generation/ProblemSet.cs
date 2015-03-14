using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
