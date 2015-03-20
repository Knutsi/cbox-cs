using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

using cbox.generation;
using cbox.model;
using cbox.generation.nodetype;

namespace ModelEditor
{
    static class Program
    {
        public static EditorWindow MainWindow { get; set; }
        public static string CurrentFilePath;
        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainWindow = new EditorWindow();
            Application.Run(MainWindow);
        }

        private static Model _CurrentModel;
        public static Model CurrentModel { 
            get
            {
                return _CurrentModel;
            }

            set
            {
                _CurrentModel = value;
                Program.MainWindow.Model = CurrentModel;
            }
        }

        public static Ontology CurrentOntology 
        { 
            get; set; 
        }


        /// <summary>
        /// Creates a new model.
        /// </summary>
        internal static void NewModel()
        {
            var model = new Model(true);
            var comp = model.RootComponent;

            var A = new Node("Starter", BaseType.TYPE_IDENT) { PosX = 100, PosY = 150 };
            var B = new Node("Problem #1", ProblemStart.TYPE_IDENT) { PosX = 250, PosY = 150 };
            var C = new Node("C", BaseType.TYPE_IDENT) { PosX = 400, PosY = 150 };
            var D = new Node("D", ProblemEnd.TYPE_IDENT) { PosX = 550, PosY = 150 };
            var E = new Node("Ender", BaseType.TYPE_IDENT) { PosX = 700, PosY = 150 };

            comp.Add(true, A, B, C, D, E);

            A.FirstOutputSocket.Connect(B);
            B.FirstOutputSocket.Connect(C);
            C.FirstOutputSocket.Connect(D);
            D.FirstOutputSocket.Connect(E);

            A.FirstOutputSocket.Label = "Demo label";

            comp.StartNode = A;
            comp.EndNode = E;

            comp.Invalidate();

            CurrentModel = model;
        }

        /// <summary>
        /// Loads the app with a new model to edit.
        /// </summary>
        /// <param name="filepath"></param>
        public static void LoadModel(string filepath)
        {
            // check if file exists, cancel if it does not:
            if(!File.Exists(filepath))
            {
                MessageBox.Show(String.Format("File does not exist: {0}", filepath));
                return;
            }

            // load the model:
            string xml = File.ReadAllText(filepath);
            CurrentModel = Model.FromXML(xml);
            CurrentFilePath = filepath;
            MainWindow.Text = CurrentFilePath;

            Console.WriteLine("Opened model {0}", filepath);

            // remember that we used this file:
            SaveToRecents(filepath);
            
        }

        /// <summary>
        /// Saves current model to file. 
        /// </summary>
        /// <param name="ask_path"></param>
        public static void SaveModel(bool ask_path=false)
        {
            // do we need to ask for a file path?
            if(ask_path || CurrentFilePath == null)
            {
                var dialog = new SaveFileDialog();
                if ((dialog.ShowDialog()) == DialogResult.OK)
                    CurrentFilePath = dialog.FileName;
                else
                    return;
            }

            // actually save the file:
            var xml = CurrentModel.ToXML();
            File.WriteAllText(CurrentFilePath, xml);

            // remember this file, if we dont already:
            if (!Recents.Contains(CurrentFilePath))
                SaveToRecents(CurrentFilePath);

            Console.WriteLine("Saved model to {0}", CurrentFilePath);
        }

        /// <summary>
        /// Loads more recently opened file, if any.
        /// </summary>
        public static void LoadMostRecent()
        {
            if (Recents.Count > 0)
                Program.LoadModel(Recents.Last());
        }

        /// <summary>
        /// Adds the file path provided to the recents list.
        /// </summary>
        /// <param name="filepath"></param>
        private static void SaveToRecents(string filepath)
        {
            var recents = Recents;
            recents.Add(filepath);

            if (recents.Count > 5)
                recents.RemoveAt(0);

            // persist this list:
            var ser = new XmlSerializer(typeof(List<string>));
            var stream = new StringWriter();
            ser.Serialize(stream, recents);
            Properties.Settings.Default.recent_files = stream.ToString();
            Properties.Settings.Default.Save();

            Console.WriteLine("Added {0} to recently opened", filepath);
        }

        /// <summary>
        /// List of recent files opened by the application.
        /// </summary>
        public static List<string> Recents 
        {
            get
            {
                if (Properties.Settings.Default.recent_files == string.Empty)
                    return new List<string>();

                var ser = new XmlSerializer(typeof(List<string>));
                var reader = new StringReader(Properties.Settings.Default.recent_files);
                var list = (List<string>)ser.Deserialize(reader);

                return list;
            }
        }

        public static void Quit()
        {
            Application.Exit();
        }

    }
}
