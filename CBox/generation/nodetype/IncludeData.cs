using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.nodetype
{
    public class IncludeData : XMLSerializable<IncludeData>, INodeTypeData
    {
        public List<OutputSocket> OuputSockets = new List<OutputSocket>();

        public IncludeSource Source { get; set; }
        public string NodeCollectionIdent { get; set; }
    }
}
