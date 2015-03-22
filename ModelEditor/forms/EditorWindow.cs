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
using cbox.modelling.editors;

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
            // setup menus, and call again when recent files change:
            SetupRecentMenu();
            SetupInsertMenu();
            Program.RecentFilesChanged += this.SetupRecentMenu;

            Diagram = new NodeCollectionDiagram() { Dock = DockStyle.Fill };
            mainSplitLayout.Panel1.Controls.Add(Diagram);

            // make diagram react to nodes being selected:
            Diagram.SelectionChanged += Diagram_SelectionChanged;

            // new model by default:
            Program.NewModel();
        }

 
        /// <summary>
        /// Sets up a menu for easily opening recent files.
        /// </summary>
        private void SetupRecentMenu()
        {
            // if we have recent menu items, we load them:
            if (Program.Recents.Count <= 0)
            {
                openMostRecentMenuItem.Enabled = false;
                recentMenuItem.Enabled = false;
            }
            else
            {
                openMostRecentMenuItem.Enabled = true;
                recentMenuItem.Enabled = true;

                // add sub-items to recent menu:
                recentMenuItem.DropDownItems.Clear();
                foreach (var filepath in Program.Recents)
                {
                    var item = new ToolStripMenuItem(filepath);
                    recentMenuItem.DropDownItems.Add(item);
                    item.Click += recentMenuItem_Click;
                    
                }
            }
                
        }


        /// <summary>
        /// Inserts all nodes in the nodetype library as entries in the insert menu.
        /// </summary>
        private void SetupInsertMenu()
        {
            foreach (var entry in TypeHandlerLibrary.TypeIdents)
            {
                var item = new ToolStripMenuItem(entry);
                insertMenu.DropDownItems.Add(item);
                item.Tag = entry;   // associate with node type

                item.Click += insertNode_Click;
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

        void recentMenuItem_Click(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;
            Program.LoadModel(item.Text);
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

        private void insertNode_Click(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;
            Diagram.NewNode((string)item.Tag);
        }

        void Diagram_SelectionChanged()
        {
            if (Diagram.SelectedNodes.Count == 1)
            {
                // only one node?  Fill panel with editor:
                var editor = new NodeEditor()
                {
                    Node = Diagram.SelectedNodes.First(),
                    Dock = DockStyle.Fill
                };

                mainSplitLayout.Panel2.Controls.Clear();
                mainSplitLayout.Panel2.Controls.Add(editor);
            }
            else if(Diagram.SelectedNodes.Count > 1)
            {
                // multiple nodes?  Use flow layout: 

                // clear current editors:
                editorFlowLayout.Controls.Clear();
                mainSplitLayout.Panel2.Controls.Clear();
                mainSplitLayout.Panel2.Controls.Add(editorFlowLayout);

                // create an editor for each selected node
                foreach (var node in Diagram.SelectedNodes)
                {
                    var editor = new NodeEditor() { Node = node };
                    editorFlowLayout.Controls.Add(editor);
                }

            } else
            {
                // no nodes? dont show anything:
                mainSplitLayout.Panel2.Controls.Clear();
            }

            
            
        }



    }
}
