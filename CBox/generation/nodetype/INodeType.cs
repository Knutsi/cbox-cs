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

        object HandlerData { get; }

        bool StartsProblem { get;  }
        bool EndsProblem { get; }

        void SaveData();
        void LoadData();

        void Eval(ExecutionContext ctx);
        void Describe(ExecutionContext ctx);
    }
}
