using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

using model = cbox.model;

namespace cbox.generation.nodetype
{
    public class DiagnosisData : XMLSerializable<DiagnosisData>, INodeTypeData
    {
        public List<OutputSocket> OutputSockets = new List<OutputSocket>();
        public List<model.Diagnosis> Diagnosis = new List<model.Diagnosis>();
    }
}
