using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.model;

namespace cbox.generation
{
    /// <summary>
    /// Holds information about an ongoing case generation.  It is give to each
    /// node in the build path, in sequence of the execution order. 
    /// </summary>
    public class ExecutionContext
    {
        // this field is the context we are called from if executing inside an include:
        public ExecutionContext ParentContext { get; set; }

        public Model CurrentModel { get; set; }
        public Problem CurrentProblem;
        public Case Case { get; set; }
        public Node CurrentNode { get; set; }
        public BuildPath BuildPath { get; set; }
        public Ontology Ontology { get; set; }
        public ComponentLibrary ComponentLibrary { get; set; }


        public Dictionary<Node, Problem> InstancedProblems = new Dictionary<Node, Problem>();

        public ExecutionContext()
        {
            Case = new Case();
        }


        internal Problem GetProblemByNode(Node node)
        {
            return InstancedProblems[node];
        }


        internal void RegisterProblem(Node node, Problem prob)
        {
            Case.AddProblem(prob);
            InstancedProblems.Add(node, prob);
        }

    }
}
