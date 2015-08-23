using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

using cbox.model;

namespace cbox.generation.nodetype
{
    public class ProblemStartData : XMLSerializable<ProblemStartData>, INodeTypeData
    {
        public List<OutputSocket> OutputSockets = new List<OutputSocket>();
        public List<string> Classes = new List<string>();
        public BindingList<ProblemRevealCondition> Triggers = new BindingList<ProblemRevealCondition>();
    }
}
