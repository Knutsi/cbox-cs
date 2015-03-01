using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.nodetype
{
    public class BaseType : INodeType
    {
        public const string TYPE_IDENT = "BASE_HANDLER";

        // internal fields:
        private Node _Node = null;
        public virtual BaseTypeData Data { get; set; }

        // fullfilling the interface:
        public bool StartsProblem { get; set; }
        public bool EndsProblem { get; set; }

        public virtual List<OutputSocket> OutputSockets { get { return Data.OutputSockets;  } }
        public virtual List<List<OutputSocket>> PossibleOutputCombos
        {
            get
            {
                var combos = new List<List<OutputSocket>>();
                
                if (this.OutputSockets.Count > 0) 
                    combos.Add(this.OutputSockets);

                return combos;
            }
        }

        public BaseType()
        {
            Data = new BaseTypeData();
            StartsProblem = false;
            EndsProblem = false;
        }

        public virtual object HandlerData
        {
            get
            {
                return this.Data;
            }
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
            if (Node.XmlData != null)
            {
                Data = BaseTypeData.FromXML(Node.XmlData);
            }
        }


        public void SaveData()
        {
            Node.XmlData = this.Data.ToXML();
        }


        /// <summary>
        /// Base type does not add anything.
        /// </summary>
        /// <param name="ctx"></param>
        public void Eval(ExecutionContext ctx)
        {
            
        }

        /// <summary>
        /// Base type does not describe anything.
        /// </summary>
        /// <param name="ctx"></param>
        public void Describe(ExecutionContext ctx)
        {
            throw new NotImplementedException();
        }
    }
}
