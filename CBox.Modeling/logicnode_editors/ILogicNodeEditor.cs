using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.scoretree;
using cbox.model;

namespace cbox.modelling.editors
{
    public interface ILogicNodeEditor
    {
        LogicNode Node { get; set; }
        Ontology Ontology { get; set; }
        event EventHandler NodeChanged;
        void SaveBeforeClose();
    }
}
