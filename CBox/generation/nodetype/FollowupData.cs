using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using cbox.model;

namespace cbox.generation.nodetype
{
    public class FollowupData : XMLSerializable<FollowupData>, INodeTypeData
    {
        public List<OutputSocket> OutputSockets = new List<OutputSocket>();
        public BindingList<FollowupQuestion> Questions = new BindingList<FollowupQuestion>();
    }
}
