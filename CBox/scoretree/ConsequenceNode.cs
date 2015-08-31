using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace cbox.scoretree
{
    [DataContract]
    public class ConsequenceNode : LogicNode
    {
        public const string TYPE_FAIL_FOR = "FAIL_ON";
        public const string TYPE_HIGEST_OF = "HIGHEST_OF";
        public const string TYPE_SUM_OF = "SUM_OF";
        public const string TYPE_COMMENT_FOR = "COMMENT_ON";

        [DataMember] public string Group { get; set; }
        [DataMember] public string Consequence = TYPE_HIGEST_OF;
        [DataMember] public string MatchedComment = string.Empty;
        [DataMember] public string UnmatchedComment = string.Empty;

        public ConsequenceNode()
        {
            Type = "ConsequenceNode"; // for javascript to find on the other side
            Group = string.Empty;
        }

        [XmlIgnore]
        override public string displayName
        {
            get {
                if (Group == string.Empty)
                    return Consequence;
                else
                    return String.Format("{0} [group: {1}]", Consequence, Group);
            }
        }

        [XmlIgnore]
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

        [XmlIgnore]
        public int MaxPoints
        {
            get
            {
                var points = from c in Children where c.Type == "PointsNode" select (c as PointsNode).Points;

                if(Consequence == TYPE_SUM_OF)
                    return points.Sum();

                else if(Consequence == TYPE_HIGEST_OF)
                {
                    var highest = 0;
                    foreach (var point in points)
                        if (point > highest)
                            highest = point;

                    return highest;
                }

                return 0;
            }

        }

        [XmlIgnore]
        public bool Fail
        {
            get
            {
                return PositiveChildren > 0;
            }


        }

        [XmlIgnore]
        public List<string> Comments
        {
            get
            {
                var comments = new List<string>();

                // are we a comments node?
                if(Consequence == TYPE_COMMENT_FOR)
                {
                    if (Eval())
                        comments.Add(MatchedComment);
                    else
                        comments.Add(UnmatchedComment);
                }

                // are we a points node?
                if(Consequence == TYPE_HIGEST_OF || Consequence == TYPE_SUM_OF)
                {
                    // get matched comments:
                    var matched_comments = from n in Children
                                         where n.Type == "PointsNode" && n.Matched 
                                         select (n as PointsNode).MatchedComment;

                    // get unmatched comments from negative nodes:
                    var unmatched_comments = from n in Children
                                           where n.Type == "PointsNode" && !n.Matched
                                           select (n as PointsNode).UnmatchedComment;

                    comments.AddRange(matched_comments);
                    comments.AddRange(unmatched_comments);
                }

                // clearn unmatched comments:
                var cleaned_comments = (from c in comments where c.Trim() != string.Empty select c).ToList();

                return cleaned_comments;
            }
        }
    }
}
