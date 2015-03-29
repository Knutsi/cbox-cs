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
    

    public partial class OutputView : UserControl
    {
        private Model _Model;
        private BackgroundWorker Worker = new BackgroundWorker();
        private Random Random = new Random();
        private Case LatestCase;

        public OutputView()
        {
            InitializeComponent();

            // ensure we pick up new models that are loaded:
            Program.ModelLoaded += Program_ModelLoaded;

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


        public void Clear()
        {
            rawOutput.Text = string.Empty;
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
                rawOutput.Text = LatestCase.toJSON();
            } 
            else
            {
                if (Model.RootComponent.Issues.Count > 0)
                    rawOutput.Text = String.Format("{0} issues prevented build", Model.RootComponent.Issues.Count);
                else
                    rawOutput.Text = "Could nto build";
            }
        }




    }
}
