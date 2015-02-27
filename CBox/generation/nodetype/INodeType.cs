using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.nodetype
{
    public interface INodeType
    {
        Node Node { get; set; }    // cant define static interaces...

        List<OutputSocket> OutputSockets { get; }
        List<List<OutputSocket>> PossibleOutputCombos { get; }

        bool StartsProblem { get; set; }
        bool EndsProblem { get; set; }

        void SaveData();
        void LoadData();
    }
}
