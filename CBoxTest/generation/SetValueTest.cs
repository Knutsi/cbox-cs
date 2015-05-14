using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using cbox.system;
using cbox.model;
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
            var A = new Node("A", BaseType.TYPE_IDENT);
            var B = new Node("B", SetValue.TYPE_IDENT);
            var C = new Node("C", BaseType.TYPE_IDENT);

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
            B.HandlerData = data;   // triggers nessesary updates and saves to model
            
            comp.Invalidate();

            // create dummy ontology and context to use in execution;
            var ontology = new Ontology();
            ontology.AddTest(new Test() { Key = "history.gender" });
            var system = new CBoxSystem(null);
            system.OverrideFilesystemOntology(ontology);

            // execute multiple times, and ensure we get both "male" and "female":
            var path = comp.BuildPaths.First();  // no branches, has only one
            var males = 0;
            var females = 0;

            for (int i = 0; i < 10; i++)
            {
                var ctx = comp.Execute(path, true, false, null, system);

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


        [TestMethod]
        public void SetValuesTest_DependentTest()
        {
            // create a fake ontology:
            var ontology = new Ontology();
            var target_test = new Test()
            {
                Key = "unittest.target",
                Datatype = "TEXT",
                Dependencies = new List<string> { "unittest.dep1", "unittest.dep2" }
            };

            var dep1_test = new Test()
            {
                Key = "unittest.dep1",
                Datatype = "TEXT",
                SetterIdent = "STRING",
                SetterXMLData = (new StringSetterData() { Strings = new List<string> { "DEP1" } }).ToXML()
            };

            var dep2_test = new Test()
            {
                Key = "unittest.dep2",
                Datatype = "TEXT",
                SetterIdent = "STRING",
                SetterXMLData = (new StringSetterData() { Strings = new List<string> { "DEP2" } }).ToXML()
            };

            ontology.AddTest(target_test);
            ontology.AddTest(dep1_test);
            ontology.AddTest(dep2_test);

            // create fake execution context and system:
            var case_ = new Case();
            case_.AddProblem( new Problem() { IsRoot = true});
            var system = new CBoxSystem(null);
            system.OverrideFilesystemOntology(ontology);    // fake ontology
            var ctx = new ExecutionContext() { Case = case_, CurrentProblem = case_.RootProblem, System = system };

            // create node and setter::
            var setter_data_xml = (new StringSetterData() { Strings = new List<string> { "NODE" } }).ToXML();
            var node = new SetValue();
            var data = new SetValuesData();
            data.Entries.Add(
                new SetValuesDataEntry() 
                { 
                    Key = "unittest.target", 
                    SetterIdent = "STRING", 
                    SetterXmlData = setter_data_xml
                } 
            );   

            // execute:
            node.Data = data;
            node.Eval(ctx);

            // assert that we now have three keys in the case: unittest.target with "NODE", and unittest.dep1 and unittest.dep2,
            // meaning those where called as dependencies and evaluated:
            Assert.AreEqual(3, ctx.Case.RootProblem.TestResults.Count);
            Assert.AreEqual("NODE", ctx.Case.RootProblem["unittest.target"].Value);
            Assert.AreEqual("DEP1", ctx.Case.RootProblem["unittest.dep1"].Value);
            Assert.AreEqual("DEP2", ctx.Case.RootProblem["unittest.dep2"].Value);
        }
    }
}
