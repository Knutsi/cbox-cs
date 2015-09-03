using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.nodetype
{
    public class Score : INodeType
    {
        public const string TYPE_IDENT = "SCORE_HANDLER";

        private Node _Node;
        private ScoreData Data;


        public Node Node
        {
            get
            {
                return this._Node;
            }
            set
            {
                this._Node = value;
                LoadData();
            }
        }

        public List<OutputSocket> OutputSockets
        {
            get { return Data.OutputSockets; }
        }

        public List<List<OutputSocket>> PossibleOutputCombos
        {
            get { return new List<List<OutputSocket>> { this.OutputSockets }; }
        }

        public INodeTypeData HandlerData
        {
            get
            {
                return Data;
            }
            set
            {
                this.Data = (ScoreData)value;
                this.Node.UpdateInternals();
            }
        }

        public INodeTypeData DefaultData
        {
            get
            {
                var data = new ScoreData();
                data.OutputSockets.Add(new OutputSocket());
                return data;
            }
        }

        public bool StartsProblem
        {
            get { return false; }
        }

        public bool EndsProblem
        {
            get { return false; }
        }



        public void SaveData()
        {
            Node.XmlData = Data.ToXML();
        }

        public void LoadData()
        {
            this.Data = ScoreData.FromXML(Node.XmlData);
        }

        /// <summary>
        /// We need to get the node collection we want, and do this by looking it up either
        /// in the model, or in component we get from the library.
        /// </summary>
        /// <param name="ctx"></param>
        public void Eval(ExecutionContext ctx)
        {
            ctx.Case.ScoreTree.Merge(Data.LogicTree.Clone());
        }


        public void Describe(ExecutionContext ctx)
        {
            throw new NotImplementedException();
        }
    }
}
