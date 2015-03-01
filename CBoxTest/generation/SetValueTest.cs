using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using cbox.generation;
using cbox.generation.nodetype;
using cbox.generation.setter;

namespace CBoxTest
{
    [TestClass]
    public class SetValueTest
    {
        [TestMethod]
        public void SetValuesTest()
        {
            // three sequenctial nodes, the middle being a SetValue node adding a test value:
            var comp = new Model(true).RootComponent;
            var A = new Node("A", BaseType.TYPE_IDENT, true);
            var B = new Node("B", SetValue.TYPE_IDENT);
            var C = new Node("C", BaseType.TYPE_IDENT, true);

            comp.Add(true, A, B, C);
            comp.StartNode = A;
            comp.EndNode = C;

            A.FirstOutputSocket.Connect(B);
            B.FirstOutputSocket.Connect(C);

            // make B set history.gender to "male" or "female":
            var setter_data = new StringSetterData();
            setter_data.Strings.Add("male");
            setter_data.Strings.Add("female");

            var setter_entry = new SetValuesDataEntry()
            {
                Key = "history.gender",
                SetterIdent = StringSetter.Ident,
                SetterXmlData = setter_data.ToXML()
            };
            
            var data = (SetValuesData)B.HandlerData;
            data.Entries.Add(setter_entry);
            B.Handler.SaveData();
            
            comp.Invalidate();

            // execute multiple times, and ensure we get both "male" and "female":
            var path = comp.BuildPaths.First();  // no branches, has only one
            var males = 0;
            var females = 0;

            for (int i = 0; i < 10; i++)
            {
                var ctx = comp.Execute(path);

                switch (ctx.Case.RootProblem["history.gender"].Value)
                {
                    case "male":
                        males += 1;
                        break;

                    case "female":
                        females += 1;
                        break;

                    default:
                        throw new Exception("Got wrong value");
                }
            }

            Assert.IsTrue(males > 0);
            Assert.IsTrue(females > 0);
        }

    }
}
