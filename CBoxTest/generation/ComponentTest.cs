using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using System.IO;

using cbox.generation;

namespace CBoxTest
{
    [TestClass]
    public class ComponentTest
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
            model.Components.Add(MakeConnectionSetup1());


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

            // perform manipulations:
            NodeManipulation(postsave_model.RootComponent);
        }

        [TestMethod]
        public void ProblemsTest()
        {
            var model = MakeConnectionSetup2();
            var comp = model.RootComponent;

            Assert.AreEqual(0, comp.ProblemSets.Count);

            // make C into a problem, check if D is boud and F is not:
            comp.NodesByTitle("C").First().StartsProblem = true;
            comp.NodesByTitle("E").First().EndsProblem = true;
            comp.Invalidate();

            Assert.AreEqual(1, comp.ProblemSets.Count);
            Assert.IsNotNull(comp.NodesByTitle("D").First().BoundProblem);
            Assert.IsNull(comp.NodesByTitle("F").First().BoundProblem);

            // make B into a problem, and I to and ender, check that G and H is bound:
            comp.NodesByTitle("B").First().StartsProblem = true;
            comp.NodesByTitle("I").First().EndsProblem = true;
            comp.Invalidate();

            Assert.AreEqual(0, comp.Issues.Count);

            Assert.AreEqual(2, comp.ProblemSets.Count);
            Assert.AreEqual(
                comp.NodesByTitle("B").First(),
                comp.NodesByTitle("G").First().BoundProblem.StartNode);

            Assert.AreEqual(
                comp.NodesByTitle("B").First(),
                comp.NodesByTitle("H").First().BoundProblem.StartNode);

            // double check that D is still bound to problem started by C:
            Assert.AreEqual(
                comp.NodesByTitle("C").First(),
                comp.NodesByTitle("D").First().BoundProblem.StartNode);

            // make a circular connection and assert for error:
            var B = comp.NodesByTitle("B").First();
            comp.NodesByTitle("G").First().FirstOutputSocket.Connect(B);
            comp.Invalidate();

            Assert.AreEqual(1, comp.Issues.Count);
            Assert.AreEqual(comp.Issues.First().IssueType, IssueType.PROBLEM_CIRCULAR);

            // fix broken connection, remove E as endring, and check issue:
            var C = comp.NodesByTitle("C").First();
            var E = comp.NodesByTitle("E").First();
            var I = comp.NodesByTitle("I").First();
            comp.NodesByTitle("G").First().FirstOutputSocket.Connect(I);
            E.EndsProblem = false;
            comp.Invalidate();

            Assert.AreEqual(1, comp.Issues.Count);
            Assert.AreEqual(comp.Issues.First().IssueType, IssueType.PROBLEM_NO_END);
            Assert.AreEqual(comp.Issues.First().ObjectIdent, C.Ident);

        }

        public void NodeManipulation(Component comp = null)
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

        private Component MakeConnectionSetup1()
        {
            var comp = new Component() { IsRoot = true };

            // create five nodes A to E: 
            var A = new Node("A", true);
            var B = new Node("B", true);
            var C = new Node("C", true);
            var D = new Node("D", true);
            var E = new Node("E", true);

            B.AddSocket(new OutputSocket());

            comp.Add(A,B,C,D,E);

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

            var A = new Node("A", true);
            var B = new Node("B", true);
            var C = new Node("C", true);
            var D = new Node("D", true);
            var E = new Node("E", true);
            var F = new Node("F", true);
            var G = new Node("G", true);
            var H = new Node("H", true);
            var I = new Node("I", true);
            var J = new Node("J", true);

            comp.Add(A, B, C, D, E, F, G, H, I, J);

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
