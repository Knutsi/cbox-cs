using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace cbox.scoretree
{

    [XmlInclude(typeof(PointsNode))]
    [XmlInclude(typeof(LogicNode))]
    public class PointsNode: LogicNode
    {
        public int Points { get; set; }
        public string MatchedComment { get; set; }
        public string UnmatchedComment { get; set; }

        public PointsNode()
        {
            Type = "PointsNode"; // for javascript to find on the other side
            Logic = LOGIC_EITHER_OF;
        }

        public override string displayName
        {
            get
            {
                if(Points == 1)
                    return String.Format("{0} POINT", Points);
                else
                    return String.Format("{0} POINTS", Points);
            }
        }

    }
}
