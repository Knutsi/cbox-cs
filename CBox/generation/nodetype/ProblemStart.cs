using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.generation;
using cbox.model;

namespace cbox.generation.nodetype
{
    public class ProblemStart : INodeType
    {
        public new const string TYPE_IDENT = "PROBLEM_START";

        public bool StartsProblem { get; set; }
        public bool EndsProblem { get; set; }

        private Node _Node;
        private ProblemStartData Data;

        public ProblemStart()
        {
            StartsProblem = true;
            EndsProblem = false;
        }

        /// <summary>
        /// Nodes that are bound by the problem started by this node will have a ProblemSet 
        /// connected that points to this node. When evaluated, we need to create a problem,
        /// register it in the contex and relate it to us.
        /// </summary>
        /// <param name="ctx"></param>
        public void Eval(ExecutionContext ctx)
        {
            var prob = new Problem();
            prob.Title = this.Node.Title;
            prob.Ident = this.Node.Title;
            prob.Classes = Data.Classes;
            prob.Triggers = Data.Triggers;

            ctx.RegisterProblem(this.Node, prob);
        }

        public Node Node
        {
            get
            {
                return _Node;
            }
            set
            {
                _Node = value;
                LoadData();
            }
        }

        public List<OutputSocket> OutputSockets
        {
            get { return Data.OutputSockets; }
        }

        public List<List<OutputSocket>> PossibleOutputCombos
        {
            get 
            {
                return new List<List<OutputSocket>> { OutputSockets };
            }
        }

        public INodeTypeData HandlerData
        {
            get { return Data;  }
            set
            {
                this.Data = (ProblemStartData)value;
                SaveData();
                this.Node.UpdateInternals();
            }
        }

        public INodeTypeData DefaultData
        {
            get 
            { 
                var data = new ProblemStartData();
                data.OutputSockets.Add(new OutputSocket());

                return data;
            }
        }


        public void SaveData()
        {
            Node.XmlData = Data.ToXML();
        }

        public void LoadData()
        {
            Data = ProblemStartData.FromXML(Node.XmlData);
        }

        public void Describe(ExecutionContext ctx)
        {
            throw new NotImplementedException();
        }
    }
}
