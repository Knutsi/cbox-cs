using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using System.IO;

using cbox.generation;
using cbox.generation.nodetype;

namespace CBoxTest
{
    [TestClass]
    public class NodeCollectionTest
    {
        [TestMethod]
        public void NodeManipulationTest()
        {
            NodeManipulation(null);

        }

        [TestMethod]
        public void SaveAndLoadTest()
        {
            var model = new Model(false);
            var comp = MakeConnectionSetup1();
            comp.IsRoot = true;
            model.Components.Add(comp);

            // alter E to be EndProblem node:
            comp.NodesByTitle("E").First().ChangeType(ProblemEnd.TYPE_IDENT);

            // assert start and end nodes exists:
            Assert.IsTrue(model.RootComponent.StartNode != null);
            Assert.IsTrue(model.RootComponent.EndNode != null);

            // write a component to drive:
            var tfile_path = Path.GetTempFileName();
            Console.WriteLine("Tempfile: " + tfile_path);

            var xml = model.ToXML();
            File.WriteAllText(tfile_path, xml);

            // load the component back, and valdiate that it still works:
            var load_xml = File.ReadAllText(tfile_path);
            var postsave_model = Model.FromXML(load_xml);

            // check that the internal references are intact:
            Assert.AreEqual(postsave_model, postsave_model.RootComponent.ParentModel);
            Assert.AreEqual(
                postsave_model.RootComponent.Nodes.First().ParentComponent,
                postsave_model.RootComponent,
                "Parent component of nodes is not correct");


            // check that "E" still is the correct type and that it's handler has been loaded:
            var E = postsave_model.RootComponent.NodesByTitle("E").First();
            Assert.AreEqual(E.Type, ProblemEnd.TYPE_IDENT);
            Assert.AreEqual(E.Handler.GetType(), typeof(ProblemEnd));
            Assert.IsTrue(E.EndsProblem);

            // perform manipulations:
            NodeManipulation(postsave_model.RootComponent);

            // ensure start and end nodes are preserved:
            Assert.IsTrue(postsave_model.RootComponent.StartNode != null);
            Assert.IsTrue(postsave_model.RootComponent.EndNode != null);

            // save model again (to this cause some bugs!)
            var postsave_xml = postsave_model.ToXML();

           
        }

        [TestMethod]
        public void ProblemsAssigmentTest()
        {
            var comp = MakeConnectionSetup2().RootComponent;

            var A = comp.NodesByTitle("A").First();
            var B = comp.NodesByTitle("B").First();
            var C = comp.NodesByTitle("C").First();
            var D = comp.NodesByTitle("D").First();
            var E = comp.NodesByTitle("E").First();
            var F = comp.NodesByTitle("F").First();
            var G = comp.NodesByTitle("G").First();
            var H = comp.NodesByTitle("H").First();
            var I = comp.NodesByTitle("I").First();

            Assert.AreEqual(0, comp.ProblemSets.Count);

            // turn C into a problem, check if D is boud and F is not:
            C.ChangeType(ProblemStart.TYPE_IDENT);
            C.FirstOutputSocket.Connect(D);

            E.ChangeType(ProblemEnd.TYPE_IDENT);
            E.FirstOutputSocket.Connect(F);

            comp.Invalidate();

            Assert.AreEqual(1, comp.ProblemSets.Count);
            Assert.IsNotNull(D.BoundProblemSet);
            Assert.IsNull(F.BoundProblemSet);

            // make B into a problem, and I to and ender, check that G and H is bound:
            B.ChangeType(ProblemStart.TYPE_IDENT);
            B.AddSocket(new OutputSocket());    // add one extra socket for debugging
            B.FirstOutputSocket.Connect(G);
            B.OutputSockets[1].Connect(H);

            I.ChangeType(ProblemEnd.TYPE_IDENT);
            I.FirstOutputSocket.Connect(F);
            comp.Invalidate();

            Assert.AreEqual(2, comp.ProblemSets.Count);
            Assert.AreEqual(B, G.BoundProblemSet.StartNode);

            Assert.AreEqual(B, H.BoundProblemSet.StartNode);

            // double check that D is still bound to problem started by C:
            Assert.AreEqual(C, D.BoundProblemSet.StartNode);

            // make a circular connection and assert for error:
            G.FirstOutputSocket.Connect(B);
            comp.Invalidate();

            Assert.IsTrue(comp.Issues.IsCyclic);

            // fix broken connection, remove E as endring, and check issue:
            G.FirstOutputSocket.Connect(I);
            E.ChangeType(BaseType.TYPE_IDENT);
            E.FirstOutputSocket.Connect(F);

            comp.Invalidate();

            Assert.AreEqual(1, comp.Issues.Count);
            Assert.AreEqual(comp.Issues.First().IssueType, IssueType.PROBLEM_NO_END);
            Assert.AreEqual(comp.Issues.First().ObjectIdent, C.Ident);
        }



        [TestMethod]
        public void ExecutionOrderTest()
        {
            var comp = MakeConnectionSetup2().RootComponent;

            comp.Invalidate();
            var order = comp.ExecutionOrder;

            var A = comp.NodesByTitle("A").First();
            var B = comp.NodesByTitle("B").First();
            var C = comp.NodesByTitle("C").First();
            var D = comp.NodesByTitle("D").First();
            var E = comp.NodesByTitle("E").First();
            var F = comp.NodesByTitle("F").First();
            var I = comp.NodesByTitle("I").First();
            var G = comp.NodesByTitle("G").First();
            var H = comp.NodesByTitle("H").First();

            // A has to be first node, F last:
            Assert.IsTrue(order.IndexOf(A) == 0);
            Assert.IsTrue(order.IndexOf(F) == order.Count - 1);

            // both G and H has to come before B:
            Assert.IsTrue(order.IndexOf(G) > order.IndexOf(B));
            Assert.IsTrue(order.IndexOf(H) > order.IndexOf(B));

            // E has to be before D, and C before D:
            Assert.IsTrue(order.IndexOf(E) > order.IndexOf(D));
            Assert.IsTrue(order.IndexOf(D) > order.IndexOf(C));
        }

        [TestMethod]
        public void CyclicPathTest()
        {
            var comp = MakeConnectionSetup2().RootComponent;
            var B = comp.NodesByTitle("B").First();
            var I = comp.NodesByTitle("I").First();

            // should be fine initially:
            comp.Invalidate();
            Assert.IsFalse(comp.Issues.IsCyclic);

            // make path cyclical:
            I.FirstOutputSocket.Connect(B);
            comp.Invalidate();
            Assert.IsTrue(comp.Issues.IsCyclic);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void BuildPathSimpleTest()
        {
            // start simple.  This collection has no branches, thus only on build path:
            var comp = MakeConnectionSetup1();
            comp.Invalidate();
            Assert.AreEqual(1, comp.BuildPaths.Count);
            Assert.AreEqual(
                comp.Nodes.Count, 
                comp.BuildPaths.First().Nodes.Count);

        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void BuildPathSimpleBranchingTest()
        {
            // start simple.  This collection has no branches, thus only on build path:
            var comp = MakeConnectionSetup1();
            var B = comp.NodesByTitle("B").First();
            var C = comp.NodesByTitle("C").First();
            var D = comp.NodesByTitle("D").First();

            // convert B to a "maybe" branch with C as guaranteed and D as possible.  
            // We should now have two build paths:
            B.ChangeType(Branch.TYPE_IDENT);
            var data = (BranchData)B.HandlerData;
            data.Mode = BranchMode.MAYBE;
            data.GuaranteedSocket.Connect(C);
            data.PossibleSockets.First().Socket.Connect(D);

            comp.Invalidate();

            // we should now have two build paths:
            Assert.AreEqual(2, comp.BuildPaths.Count);

            // C should be in both:
            Assert.IsTrue(
                comp.BuildPaths[0].Nodes.Contains(C)
                && comp.BuildPaths[1].Nodes.Contains(C));

            // D should only be in one:
            var found = 0;
            foreach (var path in comp.BuildPaths)
                if (path.Nodes.Contains(D))
                    found += 1;

            Assert.AreEqual(1, found);
        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void BuildPathComplexBranchingTest()
        {
            /* This test will have nodes A to G.  A will branch to B,C,D and be a 
             * '2off'.  B will branch to E and F as 'maybe'.  C will go to B,
             * D will go to G which will go to F. */
            
            var comp = new Model(true).RootComponent;

            var A = new Node("A", Branch.TYPE_IDENT);
            var B = new Node("B", Branch.TYPE_IDENT);
            var C = new Node("C", BaseType.TYPE_IDENT);
            var D = new Node("D", BaseType.TYPE_IDENT);
            var E = new Node("E", BaseType.TYPE_IDENT);
            var F = new Node("F", BaseType.TYPE_IDENT);
            var G = new Node("G", BaseType.TYPE_IDENT);

            comp.Add(true, A, B, C, D, E, F, G);
            comp.StartNode = A;
            comp.EndNode = F;

            // setup branch at A:
            var a_data = (BranchData)A.HandlerData;
            a_data.Mode = BranchMode.NOFF;
            a_data.N = 2;
            a_data.GuaranteedSocket.Label = "A-socket";
            a_data.PossibleSockets.First().Socket.Label = "B-socket";
            a_data.AddPossibleSocket(new BranchDataSocketEntry("C-socket"));

            // setup branch at B:
            var b_data = (BranchData)B.HandlerData;
            b_data.Mode = BranchMode.MAYBE;

            // connections:
            a_data.GuaranteedSocket.Connect(B);
            a_data.PossibleSockets[0].Socket.Connect(C);
            a_data.PossibleSockets[1].Socket.Connect(D);

            b_data.GuaranteedSocket.Connect(F);
            b_data.PossibleSockets[0].Socket.Connect(E);

            C.OutputSockets[0].Connect(F);
            D.OutputSockets[0].Connect(G);
            E.OutputSockets[0].Connect(F);
            G.OutputSockets[0].Connect(F);

            comp.Invalidate();
            Assert.AreEqual(0, comp.Issues.Count);

            // at this point, we have two branches. One yields three possible paths,
            // the other in nested under one of these, and yields two.  
            // that leaves us with 5 possible paths:
            Assert.AreEqual(5, comp.BuildPaths.Count);

            // only one of these paths include E, all include F and two include C:
            var found_c = 0;
            var found_e = 0;
            var found_f = 0;

            foreach (var path in comp.BuildPaths)
            {
                if (path.Nodes.Contains(C))
                    found_c += 1;
                if (path.Nodes.Contains(E))
                    found_e += 1;
                if (path.Nodes.Contains(F))
                    found_f += 1;
            }

            Assert.AreEqual(3, found_c);
            Assert.AreEqual(2, found_e);
            Assert.AreEqual(5, found_f);
        }

        public void NodeManipulation(NodeCollection comp = null)
        {
            if (comp == null)
                comp = MakeConnectionSetup1();

            // we should have five connections, and five nodes:
            Assert.AreEqual(5, comp.Connections.Count);
            Assert.AreEqual(5, comp.Nodes.Count);

            // assert that C is connected to E:
            Assert.AreEqual(
                comp.NodesByTitle("C").First().OutputSockets.First().TargetNodeIdent,
                comp.NodesByTitle("E").First().Ident);


            // remove C and D, and assert that we now have only one connection and three nodes:
            var nodes = new List<Node>();
            foreach (var node in comp.Nodes)
                if (node.Title == "C" || node.Title == "D")
                    nodes.Add(node);

            Assert.AreEqual(nodes.Count(), 2);

            foreach (var node in nodes)
                comp.Remove(node);

            Assert.AreEqual(3, comp.Nodes.Count);
            Assert.AreEqual(1, comp.Connections.Count);

            // assert that A is connected to B, in two ways:
            Assert.AreEqual(
                comp.NodesByTitle("B").First(),
                comp.Connections.First().ToNode);

            Assert.AreEqual(
                comp.NodesByTitle("A").First().FirstOutputSocket.TargetNode,
                comp.NodesByTitle("B").First());

            // assert internal reference correct:
            Assert.AreEqual(
                comp.Nodes.First().ParentComponent,
                comp);
        }

        private NodeCollection MakeConnectionSetup1()
        {
            var comp = new NodeCollection() { IsRoot = true };

            // create five nodes A to E: 
            var A = new Node("A", BaseType.TYPE_IDENT);
            var B = new Node("B", BaseType.TYPE_IDENT);
            var C = new Node("C", BaseType.TYPE_IDENT);
            var D = new Node("D", BaseType.TYPE_IDENT);
            var E = new Node("E", BaseType.TYPE_IDENT);

            B.AddSocket(new OutputSocket());

            comp.Add(false, A,B,C,D,E);

            comp.StartNode = A;
            comp.EndNode = E;

            A.FirstOutputSocket.Connect(B);
            B.FirstOutputSocket.Connect(C);
            B.OutputSockets[1].Connect(D);
            C.FirstOutputSocket.Connect(E);
            D.FirstOutputSocket.Connect(E);

            return comp;
        }

        private Model MakeConnectionSetup2()
        {
            var model = new Model(true);
            var comp = model.RootComponent;

            var A = new Node("A", BaseType.TYPE_IDENT);
            var B = new Node("B", BaseType.TYPE_IDENT);
            var C = new Node("C", BaseType.TYPE_IDENT);
            var D = new Node("D", BaseType.TYPE_IDENT);
            var E = new Node("E", BaseType.TYPE_IDENT);
            var F = new Node("F", BaseType.TYPE_IDENT);
            var G = new Node("G", BaseType.TYPE_IDENT);
            var H = new Node("H", BaseType.TYPE_IDENT);
            var I = new Node("I", BaseType.TYPE_IDENT);
            var J = new Node("J", BaseType.TYPE_IDENT);

            comp.Add(false, A, B, C, D, E, F, G, H, I, J);


            // add branching sockets:
            A.AddSocket(new OutputSocket());    // index 1 
            A.AddSocket(new OutputSocket());    // index 2

            B.AddSocket(new OutputSocket());

            // connect:
            A.OutputSockets[0].Connect(B);
            A.OutputSockets[1].Connect(C);
            A.OutputSockets[2].Connect(J);

            B.OutputSockets[0].Connect(G);
            B.OutputSockets[1].Connect(H);

            C.FirstOutputSocket.Connect(D);
            D.FirstOutputSocket.Connect(E);
            E.FirstOutputSocket.Connect(F);

            G.FirstOutputSocket.Connect(I);
            H.FirstOutputSocket.Connect(I);

            I.FirstOutputSocket.Connect(F);

            J.FirstOutputSocket.Connect(F);

            // define start and stop:
            comp.StartNode = A;
            comp.EndNode = F;

            // remove output socket form end node:
            F.OutputSockets.RemoveAt(0);   

            return model;
        }

    }
}
