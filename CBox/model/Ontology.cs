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

namespace cbox.model
{
    public delegate void OntolgyChangedHandler(object sender);

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
        public BindingList<ProblemClass> Classes { get; set; }

        public event OntolgyChangedHandler OnChange;

        public Ontology()
        {
            Tests = new BindingList<Test>();
            Forms = new BindingList<Form>();
            Classes = new BindingList<ProblemClass>();
            Actions = new BindingList<Action>();
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
        public string ExportClientPackage()
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

            if(triggerEvent)
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
            //OnChange(this);
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

       
    }
}
