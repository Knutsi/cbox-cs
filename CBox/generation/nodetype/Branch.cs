using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.nodetype
{
    /// <summary>
    /// The branch node type has three modes: ALL, MAYBE and NOFF. 
    /// </summary>
    public class Branch : INodeType
    {
        public const string TYPE_IDENT = "BRANCH_HANDLER";
        private BranchData Data { get; set; }

        public bool StartsProblem { get { return false; } }
        public bool EndsProblem { get { return false; } }

        private Node _Node;

        public Branch()
        {
            this.Data = new BranchData();
        }

        /// <summary>
        /// Provides a list of all output sockets we have:
        /// </summary>
        public List<OutputSocket> OutputSockets
        {
            get
            {
                var sockets = new List<OutputSocket>();

                // guaraneed socket should go first:
                sockets.Add(Data.GuaranteedSocket);

                // all possible sockets:
                foreach (var entry in Data.PossibleSockets)
                    sockets.Add(entry.Socket);
 
                return sockets;
            }
        }

        /// <summary>
        /// Possible outputs change with out mode.  
        /// - In ALL, it's simply all sockets. 
        /// - In MAYBE, it's the powerset of possible with guarateed socket added to all
        /// - In NOFF, it's all subsetes with cardinality like N + with guaranteed socket added to each
        /// </summary>
        public List<List<OutputSocket>> PossibleOutputCombos
        {
            get 
            {
                switch (Data.Mode)
                {
                    case BranchMode.MAYBE:
                        return GetMaybeCombos();

                    case BranchMode.NOFF:
                        return GetNOffCombos();

                    case BranchMode.ALL:
                        var list = new List<List<OutputSocket>>();
                        list.Add(OutputSockets);
                        return list;


                    default:
                        throw new Exception("Handler data has faulty mode");
                }
            }
        }

        /// <summary>
        /// NOff combos are the same as maybe, but the guaranteed socket is equal to the others.
        /// We only want the subsets that include n number of items however.
        /// </summary>
        /// <returns></returns>
        private List<List<OutputSocket>> GetNOffCombos()
        {
            var all_subsets = from s in Tools.GetPowerSet(OutputSockets)
                              select s.ToList();

            var selected = from s in all_subsets
                          where s.Count == Data.N
                          select s;

            return selected.ToList();
        }


        /// <summary>
        /// Makes a powerset of the output sockets, then adds the guaranteed socket to each
        /// </summary>
        /// <returns></returns>
        private List<List<OutputSocket>> GetMaybeCombos()
        {
            // get output sockets, but remove the guaranteed:
            var outputs = this.OutputSockets;
            outputs.Remove(Data.GuaranteedSocket);

            // varibale to hold the resulting combos:
            var result = new List<List<OutputSocket>>();

            // for each possible subset, add guaranteed to subset and add to results list:
            foreach (var subset in Tools.GetPowerSet(outputs))
            {
                var sub_plus_guaranteed = subset.ToList();
                sub_plus_guaranteed.Add(Data.GuaranteedSocket);
                result.Add(sub_plus_guaranteed);
            }

            return result;
        }

        public object HandlerData
        {
            get
            {
                return this.Data;
            }
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
                this.Data.ParentNode = Node;
                LoadData();
            }
        }


        public void LoadData()
        {
            if (Node.XmlData != null && Node.XmlData != String.Empty)
            {
                this.Data = BranchData.FromXML(Node.XmlData);
                this.Data.ParentNode = Node;
            }
        }


        public void SaveData()
        {
            Node.XmlData = this.Data.ToXML();
        }


        /// <summary>
        /// Branch type does not add anything.
        /// </summary>
        /// <param name="ctx"></param>
        public void Eval(ExecutionContext ctx)
        {

        }

        /// <summary>
        /// Branch type does not describe anything.
        /// </summary>
        /// <param name="ctx"></param>
        public void Describe(ExecutionContext ctx)
        {
            throw new NotImplementedException();
        }
    }
}
