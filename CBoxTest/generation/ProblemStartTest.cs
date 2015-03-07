using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using cbox.model;
using cbox.generation;
using cbox.generation.nodetype;
using cbox.generation.setter;

namespace CBoxTest.generation
{
    [TestClass]
    public class ProblemStartTest
    {
        [TestMethod]
        public void ProblemStartTypeSimpleTest()
        {
            // make a simple model with problem generatin nodes:
            var model = new Model(true);
            var comp = model.RootComponent;

            var A = new Node("A", BaseType.TYPE_IDENT);
            var B = new Node("B", ProblemStart.TYPE_IDENT);
            var C = new Node("C", SetValue.TYPE_IDENT);
            var D = new Node("D", ProblemEnd.TYPE_IDENT);
            var E = new Node("E", BaseType.TYPE_IDENT);

            comp.Add(false, A, B, C, D, E);

            // manually construct add a setter that should add a value to our problem:
            var setter_data = new StringSetterData();
            setter_data.Strings.Add("bound value");

            var sv_data = (SetValuesData)C.HandlerData;
            sv_data.Entries.Add(new SetValuesDataEntry()
            {
                Key = "demo.demo",
                SetterIdent = StringSetter.Ident,
                SetterXmlData = setter_data.ToXML()
            });

            C.HandlerData = sv_data;   

            // set start and end nodes:
            comp.StartNode = A;
            comp.EndNode = E;

            // connect nodes:
            A.FirstOutputSocket.Connect(B);
            B.FirstOutputSocket.Connect(C);
            C.FirstOutputSocket.Connect(D);
            D.FirstOutputSocket.Connect(E);

            comp.Invalidate();

            // get build path, execute it and look at context:
            var path = comp.BuildPaths[0];
            var ctx = comp.Execute(path);
            
            // context should now have a problem, pointing to B:
            Assert.IsTrue(ctx.CurrentProblem == ctx.Case.RootProblem);
            Assert.IsTrue(ctx.InstancedProblems.Count == 1);
            Assert.IsTrue(ctx.InstancedProblems[B].Title == B.Title);

            // the problem that is not root should now carry a value set by C:
            Assert.IsTrue(ctx.Case.Problems[1] != ctx.Case.RootProblem);
            Assert.IsTrue(ctx.Case.Problems[1]["demo.demo"].Value == "bound value");

        }
    }
}
