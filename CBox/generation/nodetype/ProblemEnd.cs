using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.nodetype
{
    public class ProblemEnd :  BaseType
    {
        public new const string TYPE_IDENT = "PROBLEM_END";

        public ProblemEnd()
        {
            EndsProblem = true;
        }
    }
}
