using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.generation.setter;

namespace cbox.generation.nodetype
{
    public class SetValue : INodeType
    {
        public const string TYPE_IDENT = "SET_VALUE";

        private Node _Node { get; set; }
        public SetValuesData Data { get; set; }

        /// <summary>
        /// Evaluates each setter we have assigned, and puts it's output into the case 
        /// currently being evaluted, in the problem currently bound.
        /// </summary>
        /// <param name="ctx"></param>
        public void Eval(ExecutionContext ctx)
        {
            foreach (var entry in Data.Entries)
            {
                // evaluate setter:
                var value = SetterLibrary.Default[entry.SetterIdent].Eval(
                    entry.SetterXmlData, 
                    ctx);

                // add value to current problem:
                ctx.CurrentProblem.Add(entry.Key, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctx"></param>
        public void Describe(ExecutionContext ctx)
        {
            throw new Exception("Not implemented!");
        }

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
            get { return this.Data.OutputSockets; }
        }

        public List<List<OutputSocket>> PossibleOutputCombos
        {
            get 
            {
                var list = new List<List<OutputSocket>>();
                list.Add(this.OutputSockets);
                return list;
            }
        }

        public object HandlerData
        {
            get { return this.Data; }
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
            Node.XmlData = this.Data.ToXML();
        }

        public void LoadData()
        {
            this.Data = SetValuesData.FromXML(Node.XmlData);
            this.Data.ParentNode = Node;
        }
    }
}
