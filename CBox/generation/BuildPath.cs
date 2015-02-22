using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation
{
    /// <summary>
    /// Represents a sequence of nodes to be executed to build a given veresion of 
    /// a case. 
    /// </summary>
    public class BuildPath
    {
        public string Title;
        public List<string> Tags = new List<string>();
        public List<TestReferenceRange> ReferenceRanges = new List<TestReferenceRange>();

        // the actual sequence of nodes, in order to be executed:
        public List<Node> NodeSequence = new List<Node>();
    }
}
