using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Xml.Serialization;

namespace cbox.model
{
    public delegate void OntolgyChangedHandler(object sender);

    [Serializable]
    public class Ontology
    {
        //public List<Test> Tests = new List<Test>();
        public List<Action> Actions = new List<Action>();
        public List<Test> Tests { get; set; }

        public event OntolgyChangedHandler OnChange;

        public Ontology()
        {
            Tests = new List<Test>();
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
    }
}
