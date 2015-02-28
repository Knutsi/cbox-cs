using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace cbox.generation.nodetype
{
    public class BaseTypeData : XMLSerializable<BaseTypeData>
    {
        public List<OutputSocket> OutputSockets = new List<OutputSocket>();

    }
}
