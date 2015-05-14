using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.model;
using cbox.generation;
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
                // check if we need to resolve dependencies:
                /*if (ctx.System != null)
                {
                    var test = ctx.System.Ontology.TestByKey(entry.Key);
                    if (test != null)
                        ResolveDependencies(test, ctx);
                }*/

                /* Actually, settesr should probably not resolve dependencies, but the
                 lookup values should.  If we resolve here, we might accidentaly
                 overwrite values set in the model, and we dont want this.  The modeller
                 might be given a warning however, that there are dependencsies to consider
                 for the given key.. and that they might want to model those too. */

                // evaluate setter:
                var value = SetterLibrary.Default[entry.SetterIdent].Eval(
                    entry.SetterXmlData, 
                    ctx);

                // add value to current problem:
                ctx.CurrentProblem.Add(entry.Key, value);
            }
        }

        /// <summary>
        /// Checks if dependencies of the given test is present, and executes a setter for each
        /// that is not.
        /// </summary>
        /// <param name="test"></param>
        /// <param name="ctx"></param>
        private void ResolveDependencies(model.Test target_test, ExecutionContext ctx)
        {
            foreach (var dependency_key in target_test.Dependencies)
            {
                // check if the current problem already has an entry for this test:
                if (ctx.CurrentProblem[dependency_key] == null)
                {
                    // key not present - need to resolve..

                    // get test from ontology (provides the default setter and setter data)
                    var dependency = ctx.System.Ontology.TestByKey(dependency_key);

                    // does this test too have it's own dependencies - go go gadget recursive?
                    ResolveDependencies(dependency, ctx);

                    // execute the test from the ontology;:
                    var value = SetterLibrary.Default[dependency.SetterIdent].Eval(
                        dependency.SetterXMLData,
                        ctx);
                    
                    // append result to current problem:
                    ctx.CurrentProblem.Add(dependency_key, value);
                }
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

        public INodeTypeData HandlerData
        {
            get { return this.Data; }
            set
            {
                this.Data = (SetValuesData)value;
                SaveData();
                this.Node.UpdateInternals();
            }
        }

        public INodeTypeData DefaultData
        {
            get 
            {
                var data = new SetValuesData();
                data.OutputSockets.Add(new OutputSocket() {  Label = "Default socket" });
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
            Node.XmlData = this.Data.ToXML();
        }

        public void LoadData()
        {
            this.Data = SetValuesData.FromXML(Node.XmlData);
            this.Data.ParentNode = Node;
        }
    }
}
