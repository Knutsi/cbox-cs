using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.generation;
using cbox.model;

namespace cbox.modelling.editors
{
    public interface IWindowedNodeEditor
    {
        Node Node { get; set; }
        Ontology Ontology { get; set; }
    }
}
