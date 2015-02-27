using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.nodetype
{
    public class BaseType : INodeTypeHandler
    {
        public const string TYPE_IDENT = "BASE_HANDLER";

        // internal fields:
        private Node _Node = null;
        private BaseHandlerData _Data = new BaseHandlerData();

        // fullfilling the interface:
        public bool StartsProblem { get; set; }
        public bool EndsProblem { get; set; }

        public List<OutputSocket> OutputSockets { get { return _Data.OutputSockets;  } }
        public List<List<OutputSocket>> PossibleOutputCombos
        {
            get
            {
                var combos = new List<List<OutputSocket>>();
                combos.Add(this.OutputSockets);
                return combos;
            }
        }

        public BaseType()
        {
            StartsProblem = false;
            EndsProblem = false;
        }

       
        public Node Node
        {
            get { return _Node; }

            set
            {
                _Node = value;
                LoadData();
            }
        }

        public void LoadData()
        {
            if (Node.Data != null)
            {
                _Data = BaseHandlerData.FromXML(Node.Data);
            }
        }


        public void SaveData()
        {
            Node.Data = this._Data.ToXML();
        }

    }
}
