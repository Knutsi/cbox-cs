using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cbox.generation;
using cbox.generation.nodetype;
using cbox.modelling;

namespace ModelEditor
{
    public partial class EditorWindow : Form
    {
        public NodeCollectionDiagram Diagram { get; set; }

        public EditorWindow()
        {
            InitializeComponent();
        }

        private void EditorWindow_Load(object sender, EventArgs e)
        {
            SetupMenus();

            Diagram = new NodeCollectionDiagram() { Dock = DockStyle.Fill };
            mainSplitLayout.Panel1.Controls.Add(Diagram);

            // new model by default:
            Program.NewModel();
        }

        private void SetupMenus()
        {
            // if we have recent menu items, we load them:
            if (Program.Recents.Count <= 0)
            {
                openMostRecentMenuItem.Enabled = false;
                recentMenuItem.Enabled = false;
            }
                
        }

        
        /// <summary>
        /// Sets the model currently being edited.
        /// </summary>
        public Model Model {
            get
            {
                return _Model;
            }
            set
            {
                _Model = value;
                this.Diagram.NodeCollection = _Model.RootComponent;
            } 
        }
        private Model _Model = null;


        private void openMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                Program.LoadModel(dialog.FileName);
        }

        private void openMostRecentMenuItem_Click(object sender, EventArgs e)
        {
            Program.LoadMostRecent();
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            Program.SaveModel();
        }

        private void saveACopyMenuItem_Click(object sender, EventArgs e)
        {
            Program.SaveModel(true);
        }

        private void quitMenuItem_Click(object sender, EventArgs e)
        {
            Program.Quit();
        }

        private void newMenuItem_Click(object sender, EventArgs e)
        {
            Program.NewModel();
        }

        private void selectAllMenuItem_Click(object sender, EventArgs e)
        {
            Diagram.SelectAll();
        }



    }
}
