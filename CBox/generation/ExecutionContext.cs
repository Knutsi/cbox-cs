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
        public Problem CurrentProblem;
        public Case Case { get; set; }
        public Node CurrentNode { get; set; }
        public BuildPath BuildPath { get; set; }

        Dictionary<ProblemSet, Problem> InstancedProblems = new Dictionary<ProblemSet, Problem>();

        public ExecutionContext()
        {
            Case = new Case();
        }

        internal Problem GetProblemBySet(ProblemSet set)
        {
            return InstancedProblems[set];
        }
    }
}
