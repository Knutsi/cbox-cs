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
    public class Component : IdentProvider
    {
        public bool IsRoot = false;

        public List<Node> Nodes = new List<Node>();
        
        public Node StartNode;
        public Node EndNode;

        private List<BuildPath> _BuildPaths = null;

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

        public void Add(params Node[] nodes)
        {
            foreach (var node in nodes)
                Add(node, false);

            Invalidate();
        }

        /// <summary>
        /// removes a node and clears all inbout and output connections.
        /// </summary>
        /// <param name="node"></param>
        public void Remove(Node node)
        {
            this.Nodes.Remove(node);
            node.ParentComponent = null;

            // disconnect all output sockets leading to the removed ones:
            foreach (var socket in AllOutputSockets)
                if (socket.DoesTarget(node))
                    socket.Disconnect();

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
        public List<Connection> Connections
        {

            get
            {
                var connections = new List<Connection>();

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
        /// Causes problem sets to be regenerated.
        /// </summary>
        public void Invalidate() 
        {
            this.Issues = new IssueReport();

            UpdateProblems();
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
        /// Generates a list of build paths.
        /// </summary>
        private List<BuildPath> GenerateBuildPaths()
        {
            return null;
        }

        public List<BuildPath> BuildPaths { 
            get { 
                // use cached build path if possible:
                if (_BuildPaths == null)
                    _BuildPaths = GenerateBuildPaths();

                return _BuildPaths;
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
                node.UpdateInternalReferences();
            }

            Invalidate();
        }

    }
}
