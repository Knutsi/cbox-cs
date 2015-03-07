using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.nodetype
{
    public class BranchDataSocketEntry
    {
        public OutputSocket Socket = new OutputSocket() { Type = OutputSocketType.POSSIBLE };
        public double Chance = 1.0;

        public BranchDataSocketEntry() : this(null)
        {
            
        }

        public BranchDataSocketEntry(string label = null)
        {
            if (label != null)
                Socket.Label = label;
        }
    }
}
