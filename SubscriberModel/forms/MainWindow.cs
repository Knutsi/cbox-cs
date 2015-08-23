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
        TestSpreadsheetImportTool TestImportInstance;
        FormsEditor FormsEditorInstance;
        ActionEditor ActionEditorInstance;

        private bool _PreloadState = true;

        public MainWindow()
        {
            InitializeComponent();
            //this.IsMdiContainer = Program.UseMDI;

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

        private void openMostRecentMenuItem_Click(object sender, EventArgs e)
        {
            var url = Program.Recents[0].FilePath;
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
                    toolsMenu.Enabled = false;

                    saveMenuItem.Enabled = false;
                    makeCopyMenuItem.Enabled = false;

                    exportClientPackageMenuItem.Enabled = false;
                    exportClientPackagAgainToolStripMenuItem.Enabled = false;
                }
                else
                {
                    // disable menues not needed:
                    editorsMenu.Enabled = true;
                    editMenu.Enabled = true;
                    toolsMenu.Enabled = true;

                    saveMenuItem.Enabled = true;
                    makeCopyMenuItem.Enabled = true;

                    exportClientPackageMenuItem.Enabled = true;
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
                if (Program.UseMDI)
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
            if(Program.UseMDI)
                preview.MdiParent = this;
            preview.Show();
        }

        /// <summary>
        /// Creats a new forms editor:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formsMenuItem_Click(object sender, EventArgs e)
        {
            if (this.FormsEditorInstance == null)
            {
                this.FormsEditorInstance = new FormsEditor();
                if(Program.UseMDI)
                    this.FormsEditorInstance.MdiParent = this;
                this.FormsEditorInstance.Show();
                this.FormsEditorInstance.FormClosed += FormsEditorInstance_FormClosed;

                /*var page = new TabPage("Forms editor");
                tabControl.Controls.Add(page);

                FormsEditorInstance.TopLevel = false;
                FormsEditorInstance.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                FormsEditorInstance.Visible = true;
                FormsEditorInstance.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                FormsEditorInstance.Dock = DockStyle.Fill;
                page.Controls.Add(this.FormsEditorInstance);*/

            }
            else
                this.FormsEditorInstance.Activate();
        }

        void FormsEditorInstance_FormClosed(object sender, FormClosedEventArgs e) { this.FormsEditorInstance = null; }


        private void testImportMenuItem_Click(object sender, EventArgs e)
        {
            this.TestImportInstance = new TestSpreadsheetImportTool();
            if(Program.UseMDI)
                this.TestImportInstance.MdiParent = this;

            this.TestImportInstance.Show();
        }

 


        /// <summary>
        /// Inserts the standard classes into the ontolgy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insStdClassesMenuItem_Click(object sender, EventArgs e)
        {
            /*var check = MessageBox.Show("Are you sure you want to reistall all default classes?", "Add default classes", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(check == System.Windows.Forms.DialogResult.OK)
                Program.OntologyInstance.AddDefaultClasses();*/
        }


        /// <summary>
        /// Opens the action editor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actionEditorMenuItem_Click(object sender, EventArgs e)
        {
            if (ActionEditorInstance == null)
            {
                ActionEditorInstance = new ActionEditor();
                if (Program.UseMDI)
                    ActionEditorInstance.MdiParent = this;
                ActionEditorInstance.Show();
                ActionEditorInstance.FormClosed += ActionEditorInstance_FormClosed;
            }
            else
                ActionEditorInstance.Activate();
            
        }

        void ActionEditorInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            ActionEditorInstance = null;
        }

        private void exportClientPackageMenuItem_Click(object sender, EventArgs e)
        {
            var export_dialog = new DataExportView(
                Program.OntologyInstance.ExportClientPackageString(),
                "Client package");

            export_dialog.Show();
        }

        private void serverMenuIItem_Click(object sender, EventArgs e)
        {
            var server_config = new ServerConfig();
            if(Program.UseMDI)
                server_config.MdiParent = this;

            server_config.Show();
        }

        private void OpenURLFromMenuItemText(object sender, EventArgs e)
        {
            Console.WriteLine("Opening: " + ((ToolStripMenuItem)sender).Text);
            Program.OpenInternalURL(((ToolStripMenuItem)sender).Text);
        }


  

    }
}
