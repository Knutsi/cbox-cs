using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.model;
using cbox.scoretree;

namespace cbox.generation.nodetype
{
    public class ScoreData : XMLSerializable<ScoreData>, INodeTypeData
    {
        public List<OutputSocket> OutputSockets = new List<OutputSocket>();

        public ScoreTree LogicTree = new ScoreTree();
    }
}
