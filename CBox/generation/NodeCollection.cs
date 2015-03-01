using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

using System.Runtime.Serialization;

namespace cbox.generation
{
    public class NodeCollection : IdentProvider
    {
        public bool IsRoot = false;

        public List<Node> Nodes = new List<Node>();
        
        public Node StartNode;
        public Node EndNode;

        /// <summary>
        /// The sequence the nodes are executed in.
        /// </summary>
        [XmlIgnore]
        public List<Node> ExecutionOrder;

        /// <summary>
        /// Collection of all possible builds from this collection.
        /// </summary>
        [XmlIgnore]
        public BuildPathCollection BuildPaths = null;

        [XmlIgnore]
        private Model _ParentModel = null;

        [XmlIgnore]
        public List<ProblemSet> ProblemSets = new List<ProblemSet>();

        [XmlIgnore]
        public IssueReport Issues = null;

        public Model ParentModel
        {
            get { return _ParentModel; }
            set {_ParentModel = value; }
        }

        /// <summary>
        /// Adds a node to the model.
        /// </summary>
        /// <param name="node"></param>
        public void Add(Node node, bool invalidate=true)
        {
            node.Ident = this.NextIdent;
            this.Nodes.Add(node);
            node.ParentComponent = this;

            if(invalidate)
                Invalidate();
        }

        public void Add(bool invalidate, params Node[] nodes)
        {
            foreach (var node in nodes)
                Add(node, false);

            if(invalidate)
                Invalidate();
        }

        /// <summary>
        /// removes a node and clears all inbout and output connections.
        /// </summary>
        /// <param name="node"></param>
        public void Remove(Node node, bool invalidate=true)
        {
            this.Nodes.Remove(node);
            node.ParentComponent = null;

            // disconnect all output sockets leading to the removed ones:
            foreach (var socket in AllOutputSockets)
                if (socket.DoesTarget(node))
                    socket.Disconnect();

            if(invalidate)
                Invalidate();
        }

        private void AddProblemSet(ProblemSet problem_set)
        {
            this.ProblemSets.Add(problem_set);
        }

        /// <summary>
        /// Returns all output sockets in the model.
        /// </summary>
        [XmlIgnore] 
        public List<OutputSocket> AllOutputSockets
        {
            get
            {
                var sockets = new List<OutputSocket>();
                foreach (var node in this.Nodes)
                    foreach (var socket in node.OutputSockets)
                        sockets.Add(socket);

                return sockets;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [XmlIgnore] 
        public ConnectionCollection Connections
        {

            get
            {
                var connections = new ConnectionCollection();

                foreach (var node in Nodes)
                {
                    foreach (var socket in node.OutputSockets)
                    {
                        if (socket.IsConnected)
                        {
                            var con = new Connection()
                            {
                                FromSocket = socket,
                                FromNode = node,
                                ToNode = NodeByIdent(socket.TargetNodeIdent.Value)
                            };

                            connections.Add(con);
                        }
                    }
                }

                return connections;
            }
        }

        /// <summary>
        /// Gets the single node with mathcing ident, or null.
        /// </summary>
        /// <param name="ident"></param>
        /// <returns></returns>
        public Node NodeByIdent(int ident)
        {
            foreach (var node in Nodes)
                if (node.Ident == ident)
                    return node;

            return null;
        }

        /// <summary>
        /// Gives nodes with a matching title.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public List<Node> NodesByTitle(string title)
        {
            var list = new List<Node>();

            foreach (var node in Nodes)
                if (node.Title == title)
                    list.Add(node);

            return list;
        }

        /// <summary>
        /// Returns the problem set node is bound to, or null if not bound.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public ProblemSet ProblemSetByNode(Node node)
        {
            foreach (var problem_set in ProblemSets)
                if (problem_set.BoundNodes.Contains(node))
                    return problem_set;

            return null;
        }

        /// <summary>
        /// Causes problem sets to be regenerated, execution order to be recalculated and build paths to be 
        /// collected.
        /// </summary>
        public void Invalidate() 
        {
            this.Issues = new IssueReport();

            ValidateNodes();
            UpdateProblems();
            UpdateExecutionOrder();

            if(Issues.Valid)
                UpdateBuildPaths();
        }

        /// <summary>
        /// Evaluates the integrity of the nods.  All sockets must be connected. No nodes except
        /// end node can be have no output sockets.
        /// </summary>
        private void ValidateNodes()
        {
            // are all nodes connected?
            foreach (var socket in this.AllOutputSockets)
                if (socket.TargetNode == null && socket.ParentNode != EndNode)
                {
                    this.Issues.HasUnconnectedNodes = true;
                    this.Issues.Add(new IssueReportEntry()
                    {
                        IssueType = IssueType.SOCKET_DISCONNECTED,
                        ObjectIdent = socket.ParentNode.Ident
                    });
                }
                
            
            // all nodes have output sockets?
            foreach (var node in this.Nodes)

                if (node.OutputSockets.Count <= 0 && node != EndNode)
                {
                    this.Issues.NodeMissingOutputSocket = true;
                    this.Issues.Add(new IssueReportEntry()
                    {
                        IssueType = IssueType.NODE_MISSING_OUTPUT_SOCKET,
                        ObjectIdent = node.Ident
                    });
                }            
        }

        /// <summary>
        /// This method collections all build paths in the NodeCollection.
        /// </summary>
        private void UpdateBuildPaths()
        {
            this.BuildPaths = new BuildPathCollection() { ParentNodeCollection = this };

            var start_path = new BuildPath();
            start_path.Untraced.Push(this.StartNode);

            this.BuildPaths.Add(start_path);

            start_path.Trace();

        }

        /***
        * Calculates the order in which the nodes are executed. We use a topographical sort.
        * This will make a list which corresponds to all nodes being executed, and ensuring
        * that nodes are executed in order of depenedency.  When the actual execution happens,
        * many of the nodes will be skipped as M- as NO- branches execute.   Still, the order
        * of dependency has not changed, and we are guaranteed to have at least one path through
        * the model.
        *
        * Topsort algorithm taken from http://en.wikipedia.org/wiki/Topological_sorting
        * The variable names below are aligned with the algorithm for the same of my sanity
        * when debugging this thing.
        *
        *   L ← Empty list that will contain the sorted elements
        *   S ← Set of all nodes with no incoming edges
        *
        *   while S is non-empty do
        *      remove a node n from S
        *      add n to tail of L
        *      for each node m with an edge e from n to m do
        *          remove edge e from the graph
        *          if m has no other incoming edges then
        *              insert m into S
        *   if graph has edges then
        *       return error (graph has at least one cycle)
        *   else
        *       return L (a topologically sorted order)
        */
        private void UpdateExecutionOrder()
        {
            this.ExecutionOrder = new List<Node>();

            // check for important issues:
            this.Issues.MissingStartNode = StartNode == null;
            this.Issues.MissingEndNode = EndNode == null;

            if (this.Issues.MissingStartNode || this.Issues.MissingEndNode)
                return;

            // do the topsort:
            var S = new Stack<Node>();
            S.Push(StartNode);

            var edges = this.Connections;

            var L = new List<Node>();

            // implemented algorithm:
            while (S.Count > 0)
            {
                var n = S.Pop();
                L.Add(n);

                foreach (var e in edges.From(n))
                {
                    var m = e.ToNode;
                    edges.Remove(e);

                    if (edges.To(m).Count <= 0)
                        S.Push(m);

                }
            }

            if (edges.Count > 0) 
            {
                this.Issues.Add(new IssueReportEntry() { IssueType = IssueType.CYCLIC_CONNECTION });
                this.Issues.IsCyclic = true;
            }   
            else
                this.ExecutionOrder = L;
        }

        

        /// <summary>
        /// Looks for nodes which starts problems, and generates a list of all nodes in that problem.
        /// It traces all connections that follow after a problem-starting node, and checks if the paths
        /// all accumulate in the same problem-ending node. 
        /// </summary>
        private void UpdateProblems()
        {
            // clear old:
            this.ProblemSets.Clear();

            // get nodes that start problems:
            var problem_starters = from node in Nodes
                                   where node.StartsProblem == true
                                   select node;

            // trace each of these nodes:
            foreach (var start_node in problem_starters)
            {
                ProblemAcumulatorCollection collected = new ProblemAcumulatorCollection(start_node);
                _traceProblemPath(collected, new List<Node>(), start_node);

                if (collected.IsValid)
                    this.AddProblemSet(collected.ResultSet);
                else
                    this.Issues.AddRange(collected.Issues);
            }
        }


        private void _traceProblemPath(ProblemAcumulatorCollection collected, List<Node> history, Node node)
        {
            if (!node.StartsProblem && !node.EndsProblem)
                collected.Nodes[node.Ident] = node;

            // are we going in circles?
            if (history.Contains(node))
            {
                collected.IsCircular = true;
                return;
            }

            if(node.EndsProblem)
            {
                // if it ends problems, but is not the ender, we regiser it as the ender and
                // update the total number of enders found (shoukd only be one!):
                if (node != collected.Ender)
                {
                    collected.EnderCount += 1;
                    collected.Ender = node;
                }
            } 
            else
            {
                // if it does not end problems, we trace it's connections:
                foreach (var socket in node.OutputSockets)
                {
                    if(socket.IsConnected) 
                    {
                        // notify if we have found the end node
                        if (socket.TargetNode == this.EndNode)
                            collected.EndNodeFound = true;

                        history.Add(node);
                        _traceProblemPath(collected, history, socket.TargetNode);
                    }
                }
            }   
        }
        
        

        /// <summary>
        /// Updates all nodes to refer tot his collection as their parent.  Used after 
        /// deserialization to reestablish this unserialized property.
        /// </summary>
        internal void UpdateInternalReferences()
        {
            foreach (var node in Nodes)
            {
                node.ParentComponent = this;
                node.UpdateInternals();
            }

            Invalidate();
        }

        /// <summary>
        /// Will build a case using he build path provided.  This is done by iterating through 
        /// the execution order, and calling "Eval" on each of the nodes found that also exists
        /// in the builkd path.
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public ExecutionContext Execute(BuildPath path, bool generate_values=true, bool generate_ranges=false)
        {
            // ensure we are ready to go:
            Invalidate();
            if (!Issues.Valid)
                throw new ExecutingInvalidNodeCollectionException(Issues);

            // create execution context:
            var ctx = new ExecutionContext() { BuildPath = path };

            // step through execution order, execute nodes in path provided:
            foreach (var node in this.ExecutionOrder)
            {
                if(path.Nodes.Contains(node))
                {
                    // the node we are working on:
                    ctx.CurrentNode = node;

                    // specify current problem (might be the root one):
                    if (node.BoundProblemSet != null)
                        ctx.CurrentProblem = ctx.GetProblemBySet(node.BoundProblemSet);
                    else
                        ctx.CurrentProblem = ctx.Case.RootProblem;
                        
                    // run the evaluator:
                    if (generate_values)
                        node.Eval(ctx);
                    if (generate_ranges)
                        node.Describe(ctx);
                }
            }

            return ctx;
        }
    }
}
