using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cbox.generation;
using cbox.model;

namespace ModelEditor.forms
{
    public enum OutputViewMode
    {
        TEXT, TABLE, JSON, TREE
    }

    public partial class OutputView : UserControl
    {
        private Model _Model;
        private OutputViewMode _Mode;
        private BackgroundWorker Worker = new BackgroundWorker();
        private Random Random = new Random();
        private Case LatestCase;

        public OutputView()
        {
            InitializeComponent();

            // ensure we pick up new models that are loaded:
            Program.ModelLoaded += Program_ModelLoaded;

            // wire events:
            SetupUIEvents();
            SetupModelEvents();

            // default mode is either null, or stored in app settings:
            if (Properties.Settings.Default.default_output_view == null)
                Mode = OutputViewMode.TEXT;
            else
                Mode = (OutputViewMode)Properties.Settings.Default.default_output_view;
        }

        public void SetupUIEvents()
        {
            // wire the mode swithcing radio buttons:
            textViewCheck.CheckedChanged += (object s, EventArgs e) =>
            {
                if (textViewCheck.Checked)
                    Mode = OutputViewMode.TEXT;
            };

            tableViewCheck.CheckedChanged += (object s, EventArgs e) =>
            {
                if (tableViewCheck.Checked)
                    Mode = OutputViewMode.TABLE;
            };

            treeViewCheck.CheckedChanged += (object s, EventArgs e) =>
            {
                if (treeViewCheck.Checked)
                    Mode = OutputViewMode.TREE;
            };

            jsonViewCheck.CheckedChanged += (object s, EventArgs e) =>
            {
                if (jsonViewCheck.Checked)
                    Mode = OutputViewMode.JSON;
            };
        }


        private void SetupModelEvents()
        {
            // wire worker:
            Worker.DoWork += Worker_DoWork;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }



        public void WireEvents()
        {

        }


        public Model Model 
        {
            get { return _Model; }
            set { _Model = value; WireEvents(); }
        }


        public OutputViewMode Mode
        {
            get
            {
                return _Mode;
            }

            set
            {
                _Mode = value;

                // remmeber for next time:
                Properties.Settings.Default.default_output_view = (int)value;
                Properties.Settings.Default.Save();

                // load the ui needed:
                LoadMode();
            }
        }

        private void LoadMode()
        {
            outputViewPanel.Controls.Clear();

            switch (Mode)
            {
                case OutputViewMode.TEXT:
                    textViewCheck.Checked = true;
                    outputViewPanel.Controls.Add(textView);
                    textView.Dock = DockStyle.Fill;
                    break;

                case OutputViewMode.TABLE:
                    tableViewCheck.Checked = true;
                    outputViewPanel.Controls.Add(dataView);
                    dataView.Dock = DockStyle.Fill;
                    break;

                case OutputViewMode.JSON:
                    jsonViewCheck.Checked = true;
                    outputViewPanel.Controls.Add(jsonView);
                    jsonView.Dock = DockStyle.Fill;
                    break;

                case OutputViewMode.TREE:
                    treeViewCheck.Checked = true;
                    outputViewPanel.Controls.Add(treeView);
                    treeView.Dock = DockStyle.Fill;
                    break;

                default:
                    break;
            }
        }


        public void Clear()
        {
            textView.Text = string.Empty;
        }


        public void Build()
        {
            if (this.Model == null)
                return;

            // build in background:
            //Worker.RunWorkerAsync();
            Worker_DoWork(null, null);
            Worker_RunWorkerCompleted(null, null);
        }

        public void PopulateTree()
        {

        }

        public void PopulateTable()
        {
            var table = new DataTable();
            table.Columns.Add("Problem");
            table.Columns.Add("Key");
            table.Columns.Add("Value");

            foreach (var problem in LatestCase.Problems)
            {
                foreach (var result in problem.TestResults)
                {
                    var row = table.NewRow();
                    row["Problem"] = problem.Ident;
                    row["Key"] = result.Key;
                    row["Value"] = result.ToString(Program.CurrentOntology);

                    table.Rows.Add(row);
                }
            }

            dataView.DataSource = table;
        }

        public void PopulateTextOutput()
        {
            StringBuilder output = new StringBuilder();

            foreach (var problem in LatestCase.Problems)
            {
                var values = from t in problem.TestResults
                             select t.ToString(Program.CurrentOntology);

                output.AppendFormat("{0}: {1}\r\n\r\n", problem.Title, string.Join("", values));
            }

            textView.Text = output.ToString();
        }

        public void PopulateJSONOutput()
        {
            jsonView.Text = LatestCase.toJSON();
        }

        // EVENTS

        void Program_ModelLoaded() { this.Model = Program.CurrentModel; this.Clear(); }

        private void buildButton_Click(object sender, EventArgs e) { this.Build(); }

        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.Out.WriteLine("Builder worker DoWork");
            LatestCase = Model.RandomCase;
        }

        void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (LatestCase != null)
            {
                PopulateJSONOutput();
                PopulateTextOutput();
                PopulateTable();
                PopulateTree();

            } 
            else
            {
                if (Model.RootComponent.Issues.Count > 0)
                    textView.Text = String.Format("{0} issues prevented build", Model.RootComponent.Issues.Count);
                else
                    textView.Text = "Could not build";
            }
        }




    }
}
