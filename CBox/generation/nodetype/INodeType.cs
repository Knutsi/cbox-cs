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

        INodeTypeData HandlerData { get; set; }  // current data of the node
        INodeTypeData DefaultData { get; }  // data that gets set when initialized

        bool StartsProblem { get;  }
        bool EndsProblem { get; }

        void SaveData();    // saves data to XML on node
        void LoadData();    // loads data from node XML

        void Eval(ExecutionContext ctx);    
        void Describe(ExecutionContext ctx);
    }
}
