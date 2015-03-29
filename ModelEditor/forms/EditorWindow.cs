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
        public NodeCollectionDiagram RootDiagram { get; set; }
        private NodeCollection CurrentCollection;
        private NodeCollectionDiagram CurrentDiagram;
        private SubModelTabEntry CurrentSubmodelEntry;

        // holds a list of submodels vurrently open, and what tabs/diagrams they use:
        internal List<SubModelTabEntry> SubModelTabs = new List<SubModelTabEntry>();

        public EditorWindow()
        {
            InitializeComponent();

            // react to model changed:
            Program.ModelLoaded += ReloadModel;
        }


        private void EditorWindow_Load(object sender, EventArgs e)
        {
            // setup menus, and call again when recent files change:
            SetupRecentMenu();
            SetupInsertMenu();
            Program.RecentFilesChanged += this.SetupRecentMenu;

            RootDiagram = new NodeCollectionDiagram() { Dock = DockStyle.Fill };
            rootDiagramPanel.Controls.Add(RootDiagram);

            // make diagram react to nodes being selected:
            RootDiagram.SelectionChanged += Diagram_SelectionChanged;

            // make the window work with the diagram on the current tab page:
            tabControl.Selected += tabControl_Selected;

            // new model by default:
            Program.NewModel();
        }

        /// <summary>
        /// Called whent he program loads a model.
        /// </summary>
        void ReloadModel()
        {
            this.Model = Program.CurrentModel;

            // rewire events:
            this.Model.ComponentAdded += Model_ComponentAdded;
            this.Model.ComponentRemoved += Model_ComponentRemoved;
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
                nodeMenu.DropDownItems.Add(item);
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
                // save model to internal reference, and open root component:
                _Model = value;
                this.RootDiagram.NodeCollection = _Model.RootComponent;
                CurrentDiagram = RootDiagram;
                CurrentCollection = RootDiagram.NodeCollection;

                // clear the old submodel tabs:
                var to_remove = (from e in SubModelTabs select e).ToList();
                foreach (var entry in to_remove)
                    RemoveSubmodelTab(entry.Component);
                
                // add new submodel tabs:
                foreach (var sub in Model.Submodels)
                    AddSubmodelTab(sub);
            } 
        }
        private Model _Model = null;


        /// <summary>
        /// Adds the collection as a submodel tab.
        /// </summary>
        /// <param name="collection"></param>
        public void AddSubmodelTab(NodeCollection collection)
        {
            // build the new entry, and wire everything up:
            var entry = new SubModelTabEntry(collection);
            tabControl.Controls.Add(entry.Tab);
            SubModelTabs.Add(entry);

            entry.Diagram.SelectionChanged += Diagram_SelectionChanged;
        }

        /// <summary>
        /// Remove the colleciton from submodel tabs.
        /// </summary>
        /// <param name="collection"></param>
        public void RemoveSubmodelTab(NodeCollection collection)
        {
            var entry = (from e in SubModelTabs
                         where e.Component == collection
                         select e).First();

            // remove tab:
            tabControl.Controls.Remove(entry.Tab);
            SubModelTabs.Remove(entry);

            entry.Diagram.SelectionChanged -= Diagram_SelectionChanged;
        }

        void Model_ComponentAdded(NodeCollection collection) { AddSubmodelTab(collection); }
        void Model_ComponentRemoved(NodeCollection collection) { RemoveSubmodelTab(collection); }

        /// <summary>
        /// Called when a tab page is clciked:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            // find tab page:
            var tab = e.TabPage;
            
            // find the tab in the entries:
            SubModelTabEntry tab_entry = null;
            foreach (var entry in SubModelTabs)
                if (entry.Tab == tab)
                    tab_entry = entry;
            
            // if not found, it's the root:
            if (tab_entry == null)
            {
                CurrentDiagram = RootDiagram;
                CurrentCollection = Model.RootComponent;
                CurrentSubmodelEntry = null;

                removeSubmodelItem.Enabled = false;
            }
            else
            {
                CurrentDiagram = tab_entry.Diagram;
                CurrentCollection = tab_entry.Component;
                CurrentSubmodelEntry = tab_entry;

                removeSubmodelItem.Enabled = true;
            }

            // load properties panel base on the newly selected diagram by simulating the event:
            Diagram_SelectionChanged();

            Console.Out.WriteLine("Changed to " + CurrentCollection.ToString());

        }



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
            CurrentDiagram.SelectAll();
        }

        private void insertNode_Click(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;
            CurrentDiagram.NewNode((string)item.Tag);
        }

        void Diagram_SelectionChanged()
        {
            if (CurrentDiagram.SelectedNodes.Count == 1)
            {
                // only one node?  Fill panel with editor:
                var editor = new NodeEditor()
                {
                    Node = CurrentDiagram.SelectedNodes.First(),
                    Dock = DockStyle.Fill
                };

                propertiesPanel.Controls.Clear();
                propertiesPanel.Controls.Add(editor);
            }
            else if (CurrentDiagram.SelectedNodes.Count > 1)
            {
                // multiple nodes?  Use flow layout: 

                // clear current editors:
                editorFlowLayout.Controls.Clear();
                propertiesPanel.Controls.Clear();
                propertiesPanel.Controls.Add(editorFlowLayout);

                // create an editor for each selected node
                foreach (var node in CurrentDiagram.SelectedNodes)
                {
                    var editor = new NodeEditor() { Node = node };
                    editorFlowLayout.Controls.Add(editor);
                }

            } else
            {
                // no nodes? -> show collection properties editor:
                propertiesPanel.Controls.Clear();
                
                var editor = new CollectionPropertiesEditor() 
                { 
                    NodeCollection = CurrentCollection,
                    Dock = DockStyle.Fill
                };

                propertiesPanel.Controls.Add(editor);
            }

            
            
        }

        private void newSubmodelItem_Click(object sender, EventArgs e)
        {
            var comp = new NodeCollection();
            Model.AddComponent(comp);
        }

        private void removeSubmodelItem_Click(object sender, EventArgs e)
        {
            Model.RemoveComponent(CurrentCollection);
        }



    }
}
