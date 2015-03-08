using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using cbox.model;
using cbox.generation;
using cbox.generation.nodetype;
using cbox.generation.setter;

namespace CBoxTest.generation
{
    [TestClass]
    public class IncludeNodeTest
    {
        [TestMethod]
        public void IncludeFromModelUnbound()
        {
            // make a root component and a sub-comp:
            var comp = MakeBasicCollection();
            comp.IsRoot = true;
            var model = new Model();
            model.AddComponent(comp);

            var subcomp = MakeBasicCollection();
            subcomp.Ident = "subcomp";
            model.AddComponent(subcomp);

            // get all nodes:
            var sA = subcomp.NodesByTitle("A")[0];
            var sB = subcomp.NodesByTitle("B")[0];
            var sC = subcomp.NodesByTitle("C")[0];
            var sD = subcomp.NodesByTitle("D")[0];
            var sE = subcomp.NodesByTitle("E")[0];

            var A = comp.NodesByTitle("A")[0];
            var B = comp.NodesByTitle("B")[0];
            var C = comp.NodesByTitle("C")[0];
            var D = comp.NodesByTitle("D")[0];
            var E = comp.NodesByTitle("E")[0];

            // make subcomp node C set a value:
            sC.ChangeType(SetValue.TYPE_IDENT);
            sC.FirstOutputSocket.Connect(sD);
            
            var setter_data = new StringSetterData();
            setter_data.Strings.Add("i_was_set_in_subcomp");
            var setter_entry = new SetValuesDataEntry()
            {
                Key = "demo.demo",
                SetterIdent = StringSetter.Ident,
                SetterXmlData = setter_data.ToXML()
            };

            ((SetValuesData)sC.HandlerData).Entries.Add(setter_entry);
            
            // make C an include node
            C.ChangeType(Include.TYPE_IDENT);
            C.FirstOutputSocket.Connect(D);

            var data = (IncludeData)C.HandlerData;
            data.Source = IncludeSource.MODEL;
            data.NodeCollectionIdent = "subcomp";

            // execute model and see if it includes the value from the subcomp:
            Assert.IsTrue(comp.Issues.Count == 0 && subcomp.Issues.Count == 0);
            var case_ = comp.Execute(comp.BuildPaths[0]).Case;
            Assert.IsTrue(case_.RootProblem["demo.demo"].Value == "i_was_set_in_subcomp");

            // PART 2 - bound node:

            // make include node bound:
            B.ChangeType(ProblemStart.TYPE_IDENT);
            B.FirstOutputSocket.Connect(C);
            D.ChangeType(ProblemEnd.TYPE_IDENT);
            D.FirstOutputSocket.Connect(E);

            // execute model and see if it includes the value from the subcomp:
            Assert.IsTrue(comp.Issues.Count == 0 && subcomp.Issues.Count == 0);
            case_ = comp.Execute(comp.BuildPaths[0]).Case;

            Assert.IsTrue(case_.Problems.Count == 2);
            Assert.IsTrue(case_.Problems[1]["demo.demo"].Value == "i_was_set_in_subcomp");

            // PART 3 - move subcom to component library:

            model.RemoveComponent(subcomp);
            var lib = new ComponentLibrary();
            var libmodel = new Model(false);
            libmodel.AddComponent(subcomp);
            subcomp.IsRoot = true;
            libmodel.Ident = "external";
            lib.Models.Add(libmodel);

            // change data to reflect using external model:
            data.Source = IncludeSource.LIBRARY;
            data.NodeCollectionIdent = "external";

            // see what we get (should give exactly the same result as in part 2:
            case_ = comp.Execute(comp.BuildPaths[0], true, false, null, lib).Case;
            Assert.IsTrue(case_.Problems.Count == 2);
            Assert.IsTrue(case_.Problems[1]["demo.demo"].Value == "i_was_set_in_subcomp");
        }


        private NodeCollection MakeBasicCollection()
        {
            var comp = new NodeCollection();

            var A = new Node("A", BaseType.TYPE_IDENT);
            var B = new Node("B", BaseType.TYPE_IDENT);
            var C = new Node("C", BaseType.TYPE_IDENT);
            var D = new Node("D", BaseType.TYPE_IDENT);
            var E = new Node("E", BaseType.TYPE_IDENT);

            comp.Add(true, A,B,C,D,E);

            comp.StartNode = A;
            comp.EndNode = E;

            A.FirstOutputSocket.Connect(B);
            B.FirstOutputSocket.Connect(C);
            C.FirstOutputSocket.Connect(D);
            D.FirstOutputSocket.Connect(E);

            comp.Invalidate();

            return comp;
        }
    }
}
