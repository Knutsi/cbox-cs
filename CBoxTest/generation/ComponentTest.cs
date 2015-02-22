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
        public void NodeManipulation(Component comp = null)
        {
            if(comp == null)
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
            
            // assert that A is connected to B:
            Assert.AreEqual(
                comp.NodesByTitle("B").First(),
                comp.Connections.First().ToNode);
        }


        [TestMethod]
        public void SaveAndLoad()
        {
            var model = new Model(false);
            var comp = MakeConnectionSetup1();
            model.Components.Add(MakeConnectionSetup1();
            model.RootComponent = comp;


            // write a component to drive:
            var tfile_path = Path.GetTempFileName();
            var xml = model.ToXML();
            File.WriteAllText(tfile_path, xml);

            // load the component back, and valdiate that it still works:
            var load_xml = File.ReadAllText(tfile_path);
            var postsave_model = Model.FromXML(load_xml);

            NodeManipulation(postsave_model.RootComponent);
            Console.WriteLine("Tempfile: " + tfile_path);
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

            B.OutputSockets.Add(new OutputSocket());

            comp.Add(A,B,C,D,E);

            // connect A to B, B to C and D, and C and D to E:
            /*comp.Connect(A.FirstOutputSocket, B);
            comp.Connect(B.FirstOutputSocket, C);
            comp.Connect(B.OutputSockets[1], D);
            comp.Connect(C.FirstOutputSocket, E);
            comp.Connect(D.FirstOutputSocket, E);*/

            A.FirstOutputSocket.Connect(B);
            B.FirstOutputSocket.Connect(C);
            B.OutputSockets[1].Connect(D);
            C.FirstOutputSocket.Connect(E);
            D.FirstOutputSocket.Connect(E);

            return comp;
        }

    }
}
