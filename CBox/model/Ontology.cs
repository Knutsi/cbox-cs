using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

using cbox.system;
using cbox.generation;
using cbox.generation.setter;

namespace cbox.model
{
    public delegate void OntolgyChangedHandler(object sender);

    /// <summary>
    /// The Ontology holds the majority of the CBox system, except the models of pathologies.
    /// It carries normal value descriptions and more.  
    /// 
    /// The onology is used to look up normal values when the pathology does no support them.
    /// </summary>
    [Serializable]
    [DataContract]
    public class Ontology
    {

        [DataMember]
        public BindingList<Action> Actions { get; set; }

        [DataMember]
        public BindingList<Test> Tests { get; set; }

        [DataMember]
        public BindingList<Form> Forms { get; set; }

        [DataMember]
        public BindingList<ChoiceList> ChoiceLists { get; set; }

        [DataMember]
        public BindingList<ProblemClass> Classes { get; set; }

        [XmlIgnore]
        public CBoxSystem ParentSystem { get; set; }

        public event OntolgyChangedHandler OnChange;


        public Ontology()
        {
            Tests = new BindingList<Test>();
            Forms = new BindingList<Form>();
            Classes = new BindingList<ProblemClass>();
            Actions = new BindingList<Action>();
            ChoiceLists = new BindingList<ChoiceList>();
        }


        public static Ontology LoadFromFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            TextReader reader = new StreamReader(fs);

            var serializer = new XmlSerializer(typeof(Ontology));
            var ontology = (Ontology)serializer.Deserialize(reader);

            reader.Close();
            fs.Close();

            return ontology;
        }


        public void SaveToFile(string path)
        {
            // clearn current contents of file:
            System.IO.File.WriteAllText(path, string.Empty);

            // prepare to serialize:
            var serializer = new XmlSerializer(this.GetType());

            /* Create a StreamWriter to write with. First create a FileStream
            object, and create the StreamWriter specifying an Encoding to use. */
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            TextWriter writer = new StreamWriter(fs, new UTF8Encoding());
            // Serialize using the XmlTextWriter.
            serializer.Serialize(writer, this);
            writer.Close();
            fs.Close();
        }

        /// <summary>
        /// Serializes a client package to JSON.
        /// </summary>
        /// <returns></returns>
        public string ExportClientPackageString()
        {
            using(var mstream = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(Ontology)
                    );

                ser.WriteObject(mstream, this);

                StreamReader reader = new StreamReader(mstream);
                mstream.Position = 0;
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Serializes a client package to JSON.
        /// </summary>
        /// <returns></returns>
        public object ExportClientPackage()
        {
            return this;
        }

        /// <summary>
        /// Returns a list og all headlines in all forms.  The list consists of
        /// a tuble with the form and the headline as item 1 and 2.
        /// </summary>
        [XmlIgnore]
        public List<Tuple<Form, Headline>> AllHeadlines
        {
            get
            {
                var collection = new List<Tuple<Form, Headline>>();

                foreach (Form form in this.Forms)
                {
                    foreach (Headline headline in form.Headlines)
                    {
                        var tuple = new Tuple<Form, Headline>(form, headline);
                        collection.Add(tuple);
                    }
                }

                return collection;
            }
        }

        /// <summary>
        /// Adds a test to the list, and fires the change event unless specifically asked not to.
        /// </summary>
        /// <param name="test"></param>
        public void AddTest(Test test, bool triggerEvent = true)
        {
            if(!this.Tests.Contains(test))
                this.Tests.Add(test);

            if(triggerEvent && OnChange != null)
                OnChange(this);
        }


        /// <summary>
        /// Removes a test from the list and fires the change event unless specifically asked not to.
        /// </summary>
        /// <param name="test"></param>
        /// <param name="triggerEvent"></param>
        public void RemoveTest(Test test, bool triggerEvent=true)
        {
            if (this.Tests.Contains(test))
                this.Tests.Remove(test);

            if(triggerEvent)
                OnChange(this);
        }


        public void RemoveTest(List<Test> tests, bool triggerEvent = true)
        {
            foreach (var test in tests)
                this.RemoveTest(test, false);
            
            if(triggerEvent)
                OnChange(this);
        }


        /// <summary>
        /// Adds a form to the system.
        /// </summary>
        /// <param name="form"></param>
        public void AddForm(cbox.model.Form form) 
        {
            this.Forms.Add(form);
            form.Ident = NextFormIdent;

            if(OnChange != null)
                OnChange(this);
        }

        public void RemoveForm(cbox.model.Form form)
        {
            this.Forms.Remove(form);
            OnChange(this);
        }

        public Headline GetHeadlineByformIdent(int ident)
        {
            foreach (var form_headline in AllHeadlines)
                if (form_headline.Item2.ActionIdents.Contains(ident))
                    return form_headline.Item2;

            return null;
        }




        public Form FormByTitle(string title)
        {
            foreach (var form in this.Forms)
                if (form.Title == title)
                    return form;

            return null;
        }


        private int NextFormIdent
        {
            get
            {
                var highest = 1;
                foreach(cbox.model.Form entry in this.Forms)
                    if(entry.Ident > highest)
                        highest = entry.Ident;

                return highest + 1;
            }
        }



        private int NextActionIdent { 
            get {
                var highest = 1;
                foreach (cbox.model.Action action in this.Actions)
                    if (action.Ident > highest)
                        highest = action.Ident;

                return highest + 1;
            }
        }

        /// <summary>
        /// Adds a problem class.
        /// </summary>
        /// <param name="ident"></param>
        /// <param name="title"></param>
        public void AddClass(string ident, string title)
        {
            if (ClassByIdent(ident) != null)
                return;

            var cls = new ProblemClass(ident, title);
            Classes.Add(cls);
            //OnChange(this);
        }

        public ProblemClass ClassByIdent(string ident) {
            foreach (var cls in Classes)
                if (cls.Ident == ident)
                    return cls;

            return null;
        }

        public void AddDefaultClasses()
        {
            AddClass("temporal", "Temporal");
            AddClass("spatial", "Spatial");
            AddClass("swabbable", "Swabbable");
            AddClass("palpable", "Palpable");
            AddClass("emesis", "Emesis");
            AddClass("faecal", "Faecal");
            AddClass("feeling", "Feeling");
            AddClass("general", "General");
        }

        /// <summary>
        /// Adds an action with the given title, and all other fields blank.
        /// </summary>
        /// <param name="title"></param>
        public void AddAction(string title)
        {
            var action = new Action()
            {
                Title = title,
                Ident = this.NextActionIdent
            };

            AddAction(action);
            Console.WriteLine("Adding action :" + title);
            
        }

        public void AddAction(Action action)
        {
            this.Actions.Add(action);
            action.Ident = this.NextActionIdent;
        }

        public void RemoveAction(Action action)
        {
            if(this.Actions.Contains(action))
            {
                this.Actions.Remove(action);
                //OnChange(this);
            }
        }

        public void AssignActionToHeadline(Action action, Headline headline)
        {
            // remove previous entry - if any:
            var previous_headline = GetHeadlineByformIdent(action.Ident);
            if (previous_headline != null)
                previous_headline.ActionIdents.Remove(action.Ident);

            // add action to headline:
            headline.ActionIdents.Add(action.Ident);
        }


        public void AddChoiceList(ChoiceList list)
        {
            this.ChoiceLists.Add(list);
        }

        public void RemoveChoiceList(ChoiceList list)
        {
            this.ChoiceLists.Remove(list);
        }

        /// <summary>
        /// Gets a ChoiceList by ident, or null if not found.
        /// </summary>
        /// <param name="ident"></param>
        /// <returns></returns>
        public ChoiceList GetChoiceListByIdent(string ident)
        {
            foreach (var list in this.ChoiceLists)
                if (list.Ident == ident)
                    return list;

            return null;
        }


        /// <summary>
        /// Gets tests that can be applied in a given class. Classes are assigned on a Action level, so 
        /// the results are derived by looking at the actions,  and determining what tests they include.
        /// </summary>
        /// <param name="class_"></param>
        /// <returns></returns>
        public List<string> TestsByClass(string class_)
        {
            var results = new List<string>();

            foreach (var action in Actions)
                if (action.TargetClasses.Contains(class_))
                    foreach (var key in action.Yield)
                        if (!results.Contains(key))
                            results.Add(key);
            
            return results;
        }

        /// <summary>
        /// Returns a list of all tests available in provided classes.
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        public List<string> TestsByClasses(List<string> classes)
        {
            var tests = new List<string>();

            foreach (var class_ in classes)
            {
                var class_tests = TestsByClass(class_);

                foreach (var test in class_tests)
                    if (!tests.Contains(test))
                        tests.Add(test); 
            }

            return tests;
        }



        public Test TestByKey(string key)
        {
            foreach (var test in Tests)
                if (test.Key == key)
                    return test;

            return null;
        }

        /// <summary>
        /// Retuns a list of actions possible on class with provided name.
        /// </summary>
        /// <param name="class_"></param>
        /// <returns></returns>
        public List<Action> ActionsByClass(string class_)
        {
            var results = new List<Action>();

            foreach (var action in Actions)
                if (action.TargetClasses.Contains(class_) && !results.Contains(action))
                    results.Add(action);

            return results;
        }


        public Action ActionByIdent(int ident)
        {
            foreach (var action in Actions)
                if (action.Ident == ident)
                    return action;

            return null;
        }


        public Action ActionByTitle(string title)
        {
            foreach (var action in Actions)
                if (action.Title == title && title != string.Empty)
                    return action;

            return null;
        }


        /// <summary>
        /// Looks up a test for a key-problem-pair.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="case_"></param>
        /// <param name="target_problem"></param>
        /// <returns></returns>
        public TestResult Lookup(string key, Case case_, Problem target_problem)
        {
            // get test associated with key:
            var test = this.TestByKey(key);

            // make some error checks:
            if (test == null)
                return new TestResult() { Key = key, Value = "ERROR: test does not exist: " + key };

            if (test.SetterIdent == null)
                return new TestResult() { Key = key, Value = "ERROR: no setter for test: " + key };

            if (test.SetterXMLData == null || test.SetterXMLData == string.Empty)
                return new TestResult() { Key = key, Value = "ERROR: no setter XML data for " + test.SetterIdent + " on " + key };

            // if no problem is provided, we use root problem:
            var problem = target_problem;
            if (problem == null)
                problem = case_.RootProblem;

            // all well? Then get setter, and request value:
            var setter = SetterLibrary.Default.SetterByIdent(test.SetterIdent);
            var ctx = new ExecutionContext()
            {
                Case = case_, 
                System = ParentSystem,
                IsOntologyLookup = true,
                Purpose = ExecutionPurpose.LOOKUP,
                CurrentProblem = problem
            };

            // do we need to look up dependencies?
            ResolveDependencies(test, case_, problem);
            var value = setter.Eval(test.SetterXMLData, ctx, test);
            
            // return the value retrieved:
            return new TestResult()
            {
                Key = key,
                Value = value,
                Prefix = test.Prefix,
                Unit = test.Unit,
                Abnormal = false,
                ParentKey = test.ParentKey
            };
        }

        private void ResolveDependencies(Test test, Case case_, Problem problem)
        {
            foreach (var dependency_key in test.Dependencies)
            {
                if(problem[dependency_key] == null)
                {
                    // dependency not fullfilled, we need to look it up:
                    var result = this.Lookup(dependency_key, case_, problem);
                    problem.Add(result);
                }
            }
        }


        /// <summary>
        /// Expands case by solving for every single key available in ontology.
        /// </summary>
        /// <param name="case_"></param>
        public void ExpandCompletely(Case case_, List<string> error_list, bool rethrow)
        {
            // expand each problem:
            foreach (var problem in case_.Problems)
            {
                // get tests for the classes on this problem:
                var tests = this.TestsByClasses(problem.Classes);
                foreach (var key in tests)
                {

                    if (rethrow)
                    {
                        var result = this.Lookup(key, case_, problem);
                        problem.Add(result);
                    }
                    else
                    {
                        try
                        {
                            var result = this.Lookup(key, case_, problem);
                            problem.Add(result);
                        }
                        catch (Exception exp)
                        {
                            var message = string.Format("ERROR! '{0}' throws {1}", key, exp.Message);
                            error_list.Add(message);

                        }
                    }
                }
            }
        }


    }
}

