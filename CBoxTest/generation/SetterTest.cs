using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using cbox.generation;
using cbox.generation.setter;
using cbox.model;

namespace CBoxTest.generation
{
    [TestClass]
    public class SetterTest
    {
        private SetterLibrary Library = new SetterLibrary();

        [TestMethod]
        public void Setter_RangeTest()
        {
            var data = new RangeSetterData() { Min = 10.0, Max = 100.0 };
            
            // run 100 tests, ensure all are in range:
            for (int i = 0; i < 100; i++)
            {
                var value = Library[RangeSetter.Ident].Eval(data.ToXML(), null);
                var value_dbl = Convert.ToDouble(value);
                Assert.IsTrue(value_dbl > 10 && value_dbl < 100);
                Console.WriteLine(value);
            }
        }

        [TestMethod]
        public void Setter_StringTestBasic()
        {
            var data = new StringSetterData();
            data.Strings.Add("Hello");
            data.Strings.Add("World");

            // ensure we can get both words:
            var hellos = 0;
            var worlds = 0;
            for (int i = 0; i < 100; i++)
            {
                var value = Library[StringSetter.Ident].Eval(data.ToXML(), null);
                if (value == "Hello")
                    hellos += 1;
                else if (value == "World")
                    worlds += 1;
            }

            Assert.IsTrue(hellos > 0);
            Assert.IsTrue(worlds > 0);

            Console.WriteLine("{0} hellos, {1} worlds", hellos, worlds);

        }

        [TestMethod]
        public void Setter_StringTestComplex()
        {
            var data = new StringSetterData();
            data.Strings.Add("Hello {WORLD}. {GREETING}");
            data.Strings.Add("{GREETING} Shall we be friends?");
            data.Strings.Add("Dear Sir, {GREETING}");

            var world_synonyms = new List<string>() { "world", "universe", "cosmos" };
            var greeting_synonyms = new List<string>() { "How are you?", "How do you do?", "We come in peace." };

            var world_t = new ThesaurusEntry() { Word = "WORLD", Synonyms = world_synonyms };
            var greeting_t = new ThesaurusEntry() { Word = "GREETING", Synonyms = greeting_synonyms };

            data.Thesaurus.Add(world_t);
            data.Thesaurus.Add(greeting_t);

            // run 100 samples to see if it crashes etc:
            for (int i = 0; i < 100; i++)
            {
                var value = Library[StringSetter.Ident].Eval(data.ToXML(), null);
                Console.WriteLine(value);
            }
        }

        /// <summary>
        /// Tests choice setters ability to get a value from own data
        /// </summary>
        [TestMethod]
        public void Setter_ChoiceSetterTestOwnData()
        {
            var setter = new ChoiceSetter();
            var data = new ChoiceSetterData();
            data.SourceListIdent = "na";
            data.Choices.Add("male");
            data.Choices.Add("female");
            var xml_data = data.ToXML();

            // check that both gets chosen:
            var males = 0;
            var females = 0;
            for (int i = 0; i < 1000; i++)
            {
                var value = setter.Eval(xml_data, null);
                if (value == "male")
                    males += 1;
                else if (value == "female")
                    females += 1;
            }

            // statistically check this:
            Assert.IsTrue(males > 300);
            Assert.IsTrue(females > 300);
        }

        /// <summary>
        /// Tests choice setters ability to get a value from source list
        /// </summary>
        [TestMethod]
        public void Setter_ChoiceSetterTestSourceList()
        {
            // make a fake ontology with a list:
            var ont = new Ontology();
            var list = new ChoiceList() { Ident = "Result" };
            list.Add("Positive");
            list.Add("Negative");
            ont.AddChoiceList(list);

            // fake execution context using the ontology:
            var ctx = new ExecutionContext();
            ctx.Ontology = ont;

            // make a setter:
            var setter = new ChoiceSetter();
            var data = new ChoiceSetterData() { SourceListIdent = "Result" };
            var xml_data = data.ToXML();

            // check that choice list gets used, and covered:
            var positives = 0;
            var negatives = 0;
            for (int i = 0; i < 1000; i++)
            {
                var value = setter.Eval(xml_data, ctx);
                if (value == "Positive")
                    positives += 1;
                else if (value == "Negative")
                    negatives += 1;
            }

            // statistically check this:
            Assert.IsTrue(positives > 300);
            Assert.IsTrue(negatives > 300);   
        }
    }
}
