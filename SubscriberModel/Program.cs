using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;

using cbox.model;

namespace OntologyEditor
{
    public delegate void OpenOntologyHandler(bool isNew);
    public delegate void SaveOntologyHandler();

    static class Program
    {

        const string CONFIG_KEY_RECENTS = "RECENTS";
    
        public static MainWindow MainWindowInstance;
        public static Ontology OntologyInstance { get; set; }
        public static string OntologyFilePath { get; set; }
        public static bool IsNewOntology = false;
       

        public static RecentMenuEntryCollection Recents;

        public static event OpenOntologyHandler OnOpen;
        public static event SaveOntologyHandler OnSave;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Program.LoadRecents();

            // create main windows and run app:
            Program.MainWindowInstance = new MainWindow();
            Application.Run(Program.MainWindowInstance);
        }

        public static void SaveRecents() {
            XmlSerializer serializer = new XmlSerializer(typeof(RecentMenuEntryCollection));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, Program.Recents);

            Properties.Settings.Default.Recents = writer.ToString(); ;
            Properties.Settings.Default.Save();

            Console.WriteLine("Saved recents");
        }

        public static void LoadRecents() {
            var data = Properties.Settings.Default.Recents;
            if (data != null && data != String.Empty)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(RecentMenuEntryCollection));
                StringReader reader = new StringReader(data);
                Program.Recents = (RecentMenuEntryCollection)serializer.Deserialize(reader);
            }
            else
            {
                Program.Recents = new RecentMenuEntryCollection();
                SaveRecents();
            }

            Console.WriteLine(String.Format("Loaded {0} recents", Program.Recents.Count));
        }

        public static void NewOntology()
        {
            Program.OntologyInstance = new cbox.model.Ontology();
            Program.IsNewOntology = true;

            // install default classes:
            Program.OntologyInstance.AddDefaultClasses();

            Program.OnOpen(true);
        }

        public static void OpenOntology(string path=null)
        {
            if (path == null)
            {
                var dialog = new OpenFileDialog()
                {
                    Title = "Locate ontology file",
                    Filter = "ontology files (*.cboxontology)|*.txt|All files (*.*)|*.*"
                };

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    path = dialog.FileName;
                else
                    return; // no path given, none selected.. cancel
            }

            // load the file:
            try
            {
                Program.OntologyInstance = cbox.model.Ontology.LoadFromFile(path);
            }
            catch (Exception exp)
            {
                MessageBox.Show(
                    String.Format("Failed to read the ontology file\n\nGuru meditation: {0}", exp.Message), 
                    "Error on load", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);

                return; 
            }

            Program.OntologyFilePath = path;
            Program.IsNewOntology = false;

            // add to recents menu:
            Program.Recents.Add(Program.OntologyFilePath);
            Program.SaveRecents();

            // fire event:
            Program.OnOpen(false);

        }

        public static bool SaveOntology()
        {
            if (Program.IsNewOntology)
            {
                var dialog = new SaveFileDialog()
                {
                    Title = "Save ontology as.."
                };

                var result = dialog.ShowDialog();
                if (result != System.Windows.Forms.DialogResult.OK)
                    return false;
                else
                {
                    Program.OntologyFilePath = dialog.FileName;
                    Program.IsNewOntology = false;
                }
            }

            Program.OntologyInstance.SaveToFile(Program.OntologyFilePath);
            Program.Recents.Add(Program.OntologyFilePath);
            Program.SaveRecents();

            Program.OnSave();

            return true;
        }


        public static void AddToRecents(string title, string filepath)
        {
                Program.Recents.Add(filepath);
                SaveRecents();
        }
    }
}
