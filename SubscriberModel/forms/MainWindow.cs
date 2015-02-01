using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OntologyEditor
{
    public partial class MainWindow : Form
    {
        const string TITLE_SUFFIX = "CBox Editor v0.1dev (DO NOT DEMO - knutsindre@gmail.com)";

        TestsWindow TestsWindowInstance;

        private bool _PreloadState = true;
        private bool IsNewOntology = true;


        public MainWindow()
        {
            InitializeComponent();

            Program.OnOpen += Program_OnOpen;
            Program.OnSave += Program_OnSave;
        }


        void Program_OnOpen(bool isNew)
        {
            // set window title to reflect load, and save:
            if(isNew)
                this.Text = "Unsaved ontology *" + " - CBox Ontology Editor";
            else
                this.Text = Program.OntologyFilePath + " - CBox Ontology Editor";

            this.Activate();
            this.PreloadState = false;

            UpdateTitle();
        }

        void Program_OnSave()
        {
            UpdateTitle();
        }

        private void UpdateTitle()
        {
            var title = "Unsaved ontology";
            var mark = "*";

            if(!Program.IsNewOntology)
                title = Program.OntologyFilePath;

            this.Text = String.Format("{0} {1} - {2}", title, mark, TITLE_SUFFIX);
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.PreloadState = true;

            // populate the recents menu:
            
            foreach (var entry in Program.Recents)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(entry.FilePath);
                openRecentMenu.DropDownItems.Add(item);
                item.Click += recentItem_Click;
            }
        }

        void recentItem_Click(object sender, EventArgs e)
        {
            var url = ((ToolStripMenuItem)sender).Text;
            Program.OpenOntology(url);
        }

        public bool PreloadState { 
            
            get 
            {
                return this._PreloadState;
            } 
            
            set 
            {
                this._PreloadState = value;

                if(PreloadState)
                {
                    // disable menues not needed:
                    editorsMenu.Enabled = false;
                    editMenu.Enabled = false;

                    saveMenuItem.Enabled = false;
                    makeCopyMenuItem.Enabled = false;
                }
                else
                {
                    // disable menues not needed:
                    editorsMenu.Enabled = true;
                    editMenu.Enabled = true;

                    saveMenuItem.Enabled = true;
                    makeCopyMenuItem.Enabled = true;
                }
            } 
        }


        private void newMenuItem_Click(object sender, EventArgs e) { Program.NewOntology(); }

        private void openMenuItem_Click(object sender, EventArgs e) { Program.OpenOntology();}

        private void saveMenuItem_Click(object sender, EventArgs e) { Program.SaveOntology(); }

        private void quitMenuItem_Click(object sender, EventArgs e) { Application.Exit(); }





        private void testEditorMenuItem_Click(object sender, EventArgs e)
        {
            if (TestsWindowInstance == null)
            {
                TestsWindowInstance = new TestsWindow();
                TestsWindowInstance.FormClosed += TestsWindowInstance_FormClosed;
                TestsWindowInstance.MdiParent = this;
                TestsWindowInstance.Show();
            }
            else
                TestsWindowInstance.Activate();
        }

        void TestsWindowInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            TestsWindowInstance.FormClosed -= TestsWindowInstance_FormClosed;
            TestsWindowInstance = null;
        }

        private void clientPreviewMenuItem_Click(object sender, EventArgs e)
        {
            var preview = new ClientPreview();
            preview.MdiParent = this;
            preview.Show();
        }



  

    }
}
