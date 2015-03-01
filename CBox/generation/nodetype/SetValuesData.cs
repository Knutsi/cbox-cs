using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace cbox.generation.nodetype
{
    public class SetValuesData : XMLSerializable<SetValuesData>
    {
        public List<OutputSocket> OutputSockets = new List<OutputSocket>();
        public List<SetValuesDataEntry> Entries = new List<SetValuesDataEntry>();

        [XmlIgnore]
        public Node _ParentNode;

        [XmlIgnore]
        public Node ParentNode { 
            get
            {
                return _ParentNode;
            }
            set
            {
                _ParentNode = value;
                foreach (var socket in OutputSockets)
                    socket.ParentNode = ParentNode;
            }
        }

        public SetValuesData()
        {
            // default setup:
            OutputSockets.Add(new OutputSocket() { Label = "A" });

        }
    }
}
