using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation
{
    internal class ProblemAcumulatorCollection
    {
        public Node StartNode;

        public int EnderCount = 0;
        public Node Ender = null;
        public bool IsCircular = false;
        public bool EndNodeFound = false;
        public Dictionary<int, Node> Nodes = new Dictionary<int, Node>();
        

        public ProblemAcumulatorCollection(Node start_node)
        {
            StartNode = start_node;
        }

        /// <summary>
        /// True if all criteria of a valid problem trace is found.
        /// </summary>
        public bool IsValid
        {
            get
            {
                return !IsCircular 
                    && EnderCount == 1 
                    && !EndNodeFound 
                    && Nodes.Count > 0;
            }
        }

        /// <summary>
        /// If valid, this property holds the resulting ProblemSet.
        /// </summary>
        public ProblemSet ResultSet
        {
            get
            {
                if (IsValid)
                {
                    var set = new ProblemSet()
                    {
                        StartNode = StartNode,
                        EndNode = Ender,
                        Title = StartNode.Title
                    };

                    foreach (var kvp in this.Nodes)
                        set.BoundNodes.Add(kvp.Value);

                    return set;
                }
                else
                    throw new ProblemSetNotValidException();
            }
        }

        public List<IssueReportEntry> Issues
        {
            get
            {
                var issues = new List<IssueReportEntry>();

                if (IsCircular)
                    issues.Add(new IssueReportEntry()
                    {
                        IssueType = IssueType.PROBLEM_CIRCULAR,
                        ObjectType = ObjectType.NODE,
                        ObjectIdent = StartNode.Ident
                    });

                if(EndNodeFound || EnderCount > 1)
                    issues.Add(new IssueReportEntry()
                    {
                        IssueType = IssueType.PROBLEM_NO_END,
                        ObjectType = ObjectType.NODE,
                        ObjectIdent = StartNode.Ident
                    });

                return issues;
            }
        }
    }
}
