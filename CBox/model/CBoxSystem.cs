using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.Web.Script.Serialization;


namespace cbox.model
{
    public delegate void SystemChangedHandler(object sender);
    public delegate void DiagnosisChangedHandler(object sender);

    public class CBoxSystem
    {
        // action data stored:
        public List<Diagnosis> Diagnosis = new List<Diagnosis>();
        public List<cbox.model.Form> Forms = new List<Form>();
        public List<Headline> Headlines = new List<Headline>();
        public List<cbox.model.Action> Actions = new List<cbox.model.Action>();
        public List<Test> Tests = new List<Test>();


        // events on data changed in model:
        public event SystemChangedHandler OnSystemChanged;
        public event DiagnosisChangedHandler OnDiagnosisChanged;

        
        public CBoxSystem()
        {
            this.Diagnosis.Add(new Diagnosis("Demo 1"));
            this.Diagnosis.Add(new Diagnosis("Demo 2"));
            this.Diagnosis.Add(new Diagnosis("Demo 3"));

            var a = new Action();
            this.Actions.Add(a);

            System.Console.WriteLine("CBoxSystem created");
        }

        public void TestFire() 
        {
            OnSystemChanged(this);
        }

        /// <summary>
        /// Loads an entire system from a 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static public CBoxSystem LoadFromFile(string path) 
        {
            throw new Exception("Not implemented");
        }

        /// <summary>
        /// Save the system to file.
        /// </summary>
        /// <param name="path"></param>
        public void SaveToFile(string path) 
        {
            throw new Exception("Not implemented");
        }
    }
}
