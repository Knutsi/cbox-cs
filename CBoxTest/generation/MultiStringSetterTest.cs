using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using cbox.generation.setter;
using cbox.generation;
using cbox.model;


namespace CBoxTest.generation
{
    [TestClass]
    public class MultiStringSetterTest
    {

        [TestMethod]
        public void Setter_MultiStringDataTest()
        {
            // add ranges:
            var data = new MultiStringSetterData();
            var F0_100 = new MultiStringSetterDataEntry() { AgeStart = 0, AgeEnd = 100, Gender = "F", Value="A" };
            var M0_100 = new MultiStringSetterDataEntry() { AgeStart = 0, AgeEnd = 100, Gender = "M", Value="B" };
            data.Ranges.Add(F0_100);
            data.Ranges.Add(M0_100);

            var xml = data.ToXML();

            // check that is works:
            var ctx = MakeCtx(30, "M");
            var setter = new MultiStringSetter();
            var value = setter.Eval(xml, ctx, null);
            Assert.AreEqual(value, "B");
        }

        [TestMethod]
        public void Setter_MultiStringRangesTest()
        {
            // add ranges:
            var data = new MultiStringSetterData();
            var F0_50 = new MultiStringSetterDataEntry() { AgeStart = 0, AgeEnd = 50, Gender = "F", Value = "A" };
            var F50_100 = new MultiStringSetterDataEntry() { AgeStart = 51, AgeEnd = 100, Gender = "F", Value = "B" };
            var M0_100 = new MultiStringSetterDataEntry() { AgeStart = 0, AgeEnd = 100, Gender = "M", Value = "C" };

            data.Ranges.Add(F0_50);
            data.Ranges.Add(F50_100);
            data.Ranges.Add(M0_100);

            var setter = new MultiStringSetter();
            var xml = data.ToXML();

            // check that this works:
            var f20 = MakeCtx(20, "F");
            var f60 = MakeCtx(60, "F");
            var m60 = MakeCtx(60, "M");

            Assert.AreEqual("C", setter.Eval(xml, m60, null));
            Assert.AreEqual("B", setter.Eval(xml, f60, null));
            Assert.AreEqual("A", setter.Eval(xml, f20, null));        
        }

        [TestMethod]
        public void Setter_MultiStringBRangesTest()
        {
            var data = new MultiStringSetterData();
            var B0_100 = new MultiStringSetterDataEntry() { AgeStart = 0, AgeEnd = 100, Gender = "B", Value = "X" };
            data.Ranges.Add(B0_100);

            var setter = new MultiStringSetter();
            var xml = data.ToXML();

            var f60 = MakeCtx(60, "F");
            var m60 = MakeCtx(60, "M");

            Assert.AreEqual("X", setter.Eval(xml, f60, null));
            Assert.AreEqual("X", setter.Eval(xml, m60, null));
        }

        public ExecutionContext MakeCtx(int age, string gender)
        {
            var ctx = new ExecutionContext();
            ctx.Case = new cbox.model.Case();

            ctx.Case.RootProblem.Add("history.age", age.ToString(), null);
            ctx.Case.RootProblem.Add("history.gender", gender, null);

            return ctx;
        }
    }
}
