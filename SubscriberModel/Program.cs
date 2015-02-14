using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

using cbox.server;

using cbox.model;

namespace OntologyEditor
{
    public delegate void OpenOntologyHandler(bool isNew);
    public delegate void SaveOntologyHandler();

    static class Program
    {
        const string CONFIG_KEY_RECENTS = "RECENTS";

        // internal server:
        public static TestServer TestServerInstance { get; set; }
        public static bool _InternalServerRunning = false;
    
        // UI elements the app needs to know about (in MDI-mode):
        public static MainWindow MainWindowInstance;
        public static bool UseMDI { get { return true; } }
        public static RecentMenuEntryCollection Recents;

        // holds the model:
        public static Ontology OntologyInstance { get; set; }
        public static string OntologyFilePath { get; set; }
        public static bool IsNewOntology = false;

        // events to trigger form updats etc.:
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

            // load the list of recent files:
            Program.LoadRecents();

            // create the test server used for running client previews:
            Program.TestServerInstance = new TestServer();

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

            // run server
            Program.InternalServerRunning = true;

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

            // run server:
            Program.InternalServerRunning = true;

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

        public static bool InternalServerRunning {
            
            get { return _InternalServerRunning; }
            set
            {
                try
                {
                    if (value == true)
                    {
                        // start server (with default root directory, if set):
                        Program.TestServerInstance.RootDirectory = ServerRootAutoload;
                        Program.TestServerInstance.Start();
                    }
                    else
                        Program.TestServerInstance.Stop();

                    _InternalServerRunning = value;
                }
                catch (System.Net.HttpListenerException)
                {
                    MessageBox.Show("Could not start server. You probably need to enable access on your system.  Run the following command in the command line as an administrator:\n\n'netsh http add urlacl http://+:8008/ user=Everyone listen=yes'");
                }
                
            }
        }

        /// <summary>
        /// If set to something other than null, the server will automatically 
        /// load this value as it's root when started.
        /// </summary>
        public static string ServerRootAutoload { 
            get
            {
                return Properties.Settings.Default.ServerRoot;
            }

            set
            {
                Properties.Settings.Default.ServerRoot = value;
                Properties.Settings.Default.Save();
                TestServerInstance.RootDirectory = value;

            }

        }

        public static void OpenInternalURL(string url)
        {
            if(!url.StartsWith("http://"))
                url = "http://localhost:8008" + url;

            var process = Process.Start(url);
        }
        
    }
}
