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
        }

        [TestMethod]
        public void ProblemsTest()
        {
            var model = MakeConnectionSetup2();
            var comp = model.RootComponent;

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
            C.AddSocket(new OutputSocket());
            C.FirstOutputSocket.Connect(D);

            E.ChangeType(ProblemEnd.TYPE_IDENT);
            E.AddSocket(new OutputSocket());
            E.FirstOutputSocket.Connect(F);
            comp.Invalidate();

            Assert.AreEqual(1, comp.ProblemSets.Count);
            Assert.IsNotNull(D.BoundProblem);
            Assert.IsNull(F.BoundProblem);

            // make B into a problem, and I to and ender, check that G and H is bound:
            B.ChangeType(ProblemStart.TYPE_IDENT);
            B.AddSocket(new OutputSocket());
            B.AddSocket(new OutputSocket());
            B.FirstOutputSocket.Connect(G);
            B.OutputSockets[1].Connect(H);

            I.ChangeType(ProblemEnd.TYPE_IDENT);
            I.AddSocket(new OutputSocket());
            I.FirstOutputSocket.Connect(F);
            comp.Invalidate();

            Assert.AreEqual(0, comp.Issues.Count);

            Assert.AreEqual(2, comp.ProblemSets.Count);
            Assert.AreEqual(B, G.BoundProblem.StartNode);

            Assert.AreEqual(B, H.BoundProblem.StartNode);

            // double check that D is still bound to problem started by C:
            Assert.AreEqual(C, D.BoundProblem.StartNode);

            // make a circular connection and assert for error:
            G.FirstOutputSocket.Connect(B);
            comp.Invalidate();

            Assert.AreEqual(1, comp.Issues.Count);
            Assert.AreEqual(comp.Issues.First().IssueType, IssueType.PROBLEM_CIRCULAR);

            // fix broken connection, remove E as endring, and check issue:
            G.FirstOutputSocket.Connect(I);
            E.ChangeType(BaseType.TYPE_IDENT);
            E.AddSocket(new OutputSocket());
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

        [TestMethod]
        public void BuildPathTest()
        {
            
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
            var A = new Node("A", BaseType.TYPE_IDENT, true);
            var B = new Node("B", BaseType.TYPE_IDENT, true);
            var C = new Node("C", BaseType.TYPE_IDENT, true);
            var D = new Node("D", BaseType.TYPE_IDENT, true);
            var E = new Node("E", BaseType.TYPE_IDENT, true);

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

            var A = new Node("A", BaseType.TYPE_IDENT, true);
            var B = new Node("B", BaseType.TYPE_IDENT, true);
            var C = new Node("C", BaseType.TYPE_IDENT, true);
            var D = new Node("D", BaseType.TYPE_IDENT, true);
            var E = new Node("E", BaseType.TYPE_IDENT, true);
            var F = new Node("F", BaseType.TYPE_IDENT, true);
            var G = new Node("G", BaseType.TYPE_IDENT, true);
            var H = new Node("H", BaseType.TYPE_IDENT, true);
            var I = new Node("I", BaseType.TYPE_IDENT, true);
            var J = new Node("J", BaseType.TYPE_IDENT, true);

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

            return model;
        }

    }
}
