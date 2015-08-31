using System;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace cbox.scoretree
{
    [Serializable]
    [XmlInclude(typeof(LogicNode))]
    [DataContract]
    [KnownType(typeof(List<LogicNode>))]
    [KnownType(typeof(List<PointsNode>))]
    [KnownType(typeof(List<TreatmentNode>))]
    [KnownType(typeof(List<DiagnosisNode>))]
    [KnownType(typeof(List<TestNode>))]
    public class LogicNode
    {
        public const string LOGIC_ALL_OF = "IF_ALL_OF";
        public const string LOGIC_EITHER_OF = "IF_EITHER_OF";
        public const string LOGIC_NONE_OF = "IF_NONE_OF";

        [XmlIgnore]
        private List<object> Objects_ = new List<object>();

        [DataMember]
        public string Type = "LogicNode"; // for javascript to find on the other side

        [XmlArray("Children")]
        [XmlArrayItem("LogicNode", typeof(LogicNode))]
        [XmlArrayItem("PointsNode", typeof(PointsNode))]
        [XmlArrayItem("TreatmentNode", typeof(TreatmentNode))]
        [XmlArrayItem("DiagnosisNode", typeof(DiagnosisNode))]
        [XmlArrayItem("ConsequenceNode", typeof(ConsequenceNode))]
        [XmlArrayItem("TestNode", typeof(TestNode))]
        [DataMember]
        public List<LogicNode> Children = new List<LogicNode>();

        [DataMember]
        public string Logic = LOGIC_EITHER_OF;

        public LogicNode()
        {

        }

        [XmlIgnore]
        [IgnoreDataMember]
        virtual public string displayName
        {
            get { return Logic; }
        }

        virtual public bool Eval()
        {
            switch (Logic)
            {
                case LOGIC_ALL_OF:
                    return Children.Count > 0 && PositiveChildren == Children.Count;

                case LOGIC_EITHER_OF:
                    return PositiveChildren > 0;

                case LOGIC_NONE_OF:
                    return PositiveChildren == 0;

                default:
                    throw new Exception("LogicNode with unknown logic setting: " + Logic);
            }
        }

        [XmlIgnore]
        [IgnoreDataMember]
        public List<object> Objects {
            get { return Objects_; }
            set
            {
                // set, and spread on children:
                Objects_ = value;
                foreach (var child in this.Children)
                    child.Objects = value;
            }
        }

        [XmlIgnore]
        [IgnoreDataMember]
        public bool Matched
        {
            get { return Eval(); }
        }

        [XmlIgnore]
        [IgnoreDataMember]
        public int PositiveChildren
        {
            get
            {
                var positives = from c in this.Children where c.Eval() select c;
                return positives.Count();
            }
        }


    }
}
