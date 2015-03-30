using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.nodetype
{
    public class ProblemStartData : XMLSerializable<ProblemStartData>, INodeTypeData
    {
        public List<OutputSocket> OutputSockets = new List<OutputSocket>();
        public List<string> Classes = new List<string>();
    }
}
