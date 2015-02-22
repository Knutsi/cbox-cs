using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Node()
        {
            Title = "Untitled";
        }

        public Node(string title="Untitled", bool create_default=false)
        {
            Title = title;

            if(create_default)
                this.OutputSockets.Add(new OutputSocket());
        }

        public OutputSocket FirstOutputSocket { get { return this.OutputSockets.First();  } }

    }
}
