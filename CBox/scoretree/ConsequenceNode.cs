using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.scoretree
{
    public class ConsequenceNode : LogicNode
    {
        public const string TYPE_FAIL_FOR = "FAIL_ON";
        public const string TYPE_HIGEST_OF = "HIGHEST_OF";
        public const string TYPE_SUM_OF = "SUM_OF";
        public const string TYPE_COMMENT_FOR = "COMMENT_ON";

        public string Group { get; set; }
        public string Consequence = TYPE_HIGEST_OF;
        public string MatchedComment = string.Empty;
        public string UnmatchedComment = string.Empty;

        public ConsequenceNode()
        {
            Type = "ConsequenceNode"; // for javascript to find on the other side
            Group = string.Empty;
        }

        override public string displayName
        {
            get {
                if (Group == string.Empty)
                    return Consequence;
                else
                    return String.Format("{0} [group: {1}]", Consequence, Group);
            }
        }


        public int Points {
            get
            {
                var points_nodes = from c in Children where c.Type == "PointsNode" && c.Eval() select c as PointsNode;

                var highest = 0;
                var sum = 0;

                foreach (var node in points_nodes) {
                    if (node.Points > highest)
                        highest = node.Points;

                    sum += node.Points;
                }

                if (this.Consequence == TYPE_HIGEST_OF)
                    return highest;
                else if (this.Consequence == TYPE_SUM_OF)
                    return sum;
                else
                    return 0;
            }
        }


        public int MaxPoints
        {
            get
            {
                var points = from c in Children where c.Type == "PointsNode" select (c as PointsNode).Points;
                return points.Sum();
            }

        }


        public bool Fail
        {
            get
            {
                return PositiveChildren > 0;
            }


        }

        public List<string> Comments
        {
            get
            {
                return new List<string>();
            }
        }
    }
}
