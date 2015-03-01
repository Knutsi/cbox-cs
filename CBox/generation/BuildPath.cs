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
        public List<string> Tags = new List<string>();
        public List<TestReferenceRange> ReferenceRanges = new List<TestReferenceRange>();
        
        public BuildPathCollection ParentPathCollection = null;

        // the actual sequence of nodes, in order to be executed:
        public List<Node> Nodes = new List<Node>();

        internal Stack<Node> Untraced = new Stack<Node>();

        /// <summary>
        /// Traces the untraced nodes to collect their branching etc.
        /// 
        /// Pesudocode:
        /// 
        /// while in traced exists in path:
        //      take an untraced node
        //      get possible output combos
        //      if more than one 
        //          for each combo i above first:
        //              make clone of self
        //              add clone to parent collection
        //              add targets in i to clone as untraced
        //               apply recursive trace
        //      take first output combo
        //          add targets to self as untraced
        /// 
        /// </summary>
        internal void Trace()
        {
            while (Untraced.Count > 0)
            {
                var node = Untraced.Pop();

                // we do not retrace a node we have already visited:
                if (!this.Nodes.Contains(node))
                {
                    this.Nodes.Add(node);

                    // only trace if it's not the end node:
                    if (node == ParentPathCollection.ParentNodeCollection.EndNode)
                        continue;

                    // get all possible outputs:
                    var branches = node.PossibleOutputCombos;

                    if (branches.Count > 1)
                    {
                        // handle tail :
                        var tail = branches.GetRange(1, branches.Count - 1);
                        foreach (var sockets in tail)
                        {
                            BuildPath clone = this.Clone();
                            this.ParentPathCollection.Add(clone);
                            foreach (var socket in sockets)
                                clone.Untraced.Push(socket.TargetNode);
                            clone.Trace();
                        }
                    }

                    // handle head ourselves:
                    foreach (var socket in branches[0])
                        this.Untraced.Push(socket.TargetNode);

                }
            }
        }

        /// <summary>
        /// Creates a shallow copy of the path to use in tracing.
        /// </summary>
        /// <returns></returns>
        private BuildPath Clone()
        {
            var clone = new BuildPath();
            
            // clone members:
            clone.ParentPathCollection = this.ParentPathCollection;
            clone.Nodes = new List<Node>(this.Nodes);
            clone.Untraced = new Stack<Node>(this.Untraced);

            return clone;
        }

        public string Title
        {
            get
            {
                var sbuilder = new StringBuilder();
                sbuilder.AppendFormat("BuildPath {0} nodes: ", Nodes.Count);
                foreach (var node in Nodes)
                    sbuilder.AppendFormat("{0} - ", node.Title);

                return sbuilder.ToString();
            }

        }

        public new string ToString()
        {
            return Title;
        }
    }
}
