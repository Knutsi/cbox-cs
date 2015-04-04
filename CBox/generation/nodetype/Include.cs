using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.nodetype
{
    public enum IncludeSource
    {
        LIBRARY, MODEL
    }

    public class Include : INodeType
    {
        public const string TYPE_IDENT = "INCLUDE_HANDLER";

        private Node _Node;
        private IncludeData Data;


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
            get { return Data.OuputSockets; }
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
                this.Data = (IncludeData)value;
                this.Node.UpdateInternals();
            }
        }

        public INodeTypeData DefaultData
        {
            get 
            {
                var data = new IncludeData();
                data.OuputSockets.Add(new OutputSocket());
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
            this.Data = IncludeData.FromXML(Node.XmlData);
        }

        /// <summary>
        /// We need to get the node collection we want, and do this by looking it up either
        /// in the model, or in component we get from the library.
        /// </summary>
        /// <param name="ctx"></param>
        public void Eval(ExecutionContext ctx)
        {
            foreach (var include in Data.Includes)
            {
                ExecutSubmodel(include, ctx);
            }
        }

        private void ExecutSubmodel(IncludeDataEntry include, ExecutionContext ctx) 
        {
            NodeCollection ncol = null;

            if (include.Local)
            {
                ncol = ctx.CurrentModel.GetNodeCollection(include.Ident);
                // ensure we never include root model:
                if (ncol == ncol.ParentModel.RootComponent)
                    throw new Exception("Include node is trying to incldue root model.  This would cause cyclic infinite loops.");
            }
            else
                ncol = ctx.ComponentLibrary.GetModel(include.Ident).RootComponent; 

            // if we cannot find the model, this is a serious error:
            if (ncol == null)
                throw new ModelIntegrityException(String.Format("The node collection {0} was not found", include.Ident));

            // *FIXME*: DO ALIGNMENT HERE BY LIMITING BUILD PATHS!
            // in absence of alignment, we'll just pick a random path:
            var rand = new Random();
            var paths = ncol.BuildPaths;
            var path = paths[rand.Next(paths.Count)];

            // execute:
            var include_ctx = ncol.Execute(
                path, 
                true, 
                false, 
                ctx, 
                ctx.ComponentLibrary);

            // now to add the collected values to case.  If we are bound, we add all values
            // on root problem to current problem.  If not, we add each problem that
            // is not root directly to case, then add values from root problem to our root
            // problem:
            if (ctx.CurrentProblem == ctx.Case.RootProblem)
            {
                // unbound (problems allowed):
                foreach (var problem in include_ctx.Case.Problems)
                {
                    if (!problem.IsRoot)
                        ctx.Case.AddProblem(problem);
                    else
                        foreach (var result in include_ctx.Case.RootProblem.TestResults)
                            ctx.Case.RootProblem.Add(result);
                }
            }
            else
            {
                // bound (only current problem allowed:
                foreach (var result in include_ctx.Case.RootProblem.TestResults)
                    ctx.CurrentProblem.Add(result);
            }
        }

        public void Describe(ExecutionContext ctx)
        {
            throw new NotImplementedException();
        }
    }
}
