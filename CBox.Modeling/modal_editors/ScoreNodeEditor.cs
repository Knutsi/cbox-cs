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
using model = cbox.model;

using cbox.generation.nodetype;
using cbox.scoretree;

namespace cbox.modelling.editors
{
    public partial class ScoreNodeEditor : Form, IWindowedNodeEditor
    {
        private Node Node_;
        private LogicNode SelectedLogicNode;
        private TreeNode SelectedTreeNode;
        private ILogicNodeEditor CurrentEditor;
        private List<ListViewItem> TesterChoices = null;

        public ScoreNodeEditor()
        {
            InitializeComponent();

            // events:
            treeView.BeforeSelect += TreeView_BeforeSelect;
            treeView.AfterSelect += TreeView_AfterSelect;
           
            // disable buttons:
            UpdateAddButtons();
        }


        public Node Node
        {
            get { return Node_; } set { Node_ = value; LoadData(); }
        }

        public ScoreData Data
        {
            get
            {
                if (Node == null)
                    return null;

                return Node.HandlerData as ScoreData;
            }
        }

        public model.Ontology Ontology
        {
            get; set;
        }


        public void LoadData()
        {
            RepopulateTree();
        }


        public void SaveData()
        {

        }

        public void LoadNodeEditor(LogicNode node)
        {
            

            // grab the editor:
            UserControl editor = null;
            switch (node.Type)
            {
                case "PointsNode":
                    editor = new PointsNodeEditor();
                    break;

                case "LogicNode":
                    editor = new LogicNodeEditor();
                    break;

                case "TreatmentNode":
                    editor = new TreatmentNodeEditor();
                    break;

                case "DiagnosisNode":
                    editor = new DxNodeEditor();
                    break;

                case "ConsequenceNode":
                    editor = new ConsequenceNodeEditor();
                    break;

                case "TestNode":
                    editor = new TestNodeEditor();
                    break;

                default:
                    throw new Exception("Unknown logic node type!");
            }

            // install event handler:
            (editor as ILogicNodeEditor).NodeChanged += NodeEditor_NodeChanged;

            // set ontology:
            (editor as ILogicNodeEditor).Ontology = this.Ontology;

            // set to current node:
            (editor as ILogicNodeEditor).Node = node;

            // insert editor:
            splitContainer.Panel2.Controls.Add(editor);
            editor.Dock = DockStyle.Fill;
            editor.Show();
            CurrentEditor = editor as ILogicNodeEditor;
        }


        public void RepopulateTree()
        {
            SelectedLogicNode = null;
            treeView.BeginUpdate();
            treeView.Nodes.Clear();

            // one root for each consequence:
            foreach (var consq in Data.LogicTree)
            {
                var consq_node = new TreeNode()
                {
                    Text = consq.displayName,
                    Tag = consq,
                    NodeFont = new Font(SystemFonts.DefaultFont, FontStyle.Bold)
                    
                };
                treeView.Nodes.Add(consq_node);

                foreach (var child in consq.Children)
                    MakeTreeNodeRecursive(child, consq_node);
            }

            treeView.ExpandAll();
            treeView.EndUpdate();       
        }

        public void RepopulatePartialTree(TreeNode treenode, LogicNode logicnode)
        {
            treeView.BeginUpdate();
            treenode.Nodes.Clear();
            
            foreach(var child in logicnode.Children)
            {
                MakeTreeNodeRecursive(child, treenode);
            }

            treeView.ExpandAll();
            treeView.EndUpdate();
        }


        private void MakeTreeNodeRecursive(LogicNode child, TreeNode parent_node)
        {
            var child_node = new TreeNode()
            {
                Text = child.displayName,
                Tag = child
            };
            parent_node.Nodes.Add(child_node);

            foreach (var grandchild in child.Children)
                MakeTreeNodeRecursive(grandchild, child_node);
        }

        private void UpdateAddButtons()
        {
            // turn all buttons off:
            newPointsButton.Enabled = false;
            newLogicButton.Enabled = false;
            newDxButton.Enabled = false;
            newRxButton.Enabled = false;
            newTestButton.Enabled = false;
            removeButton.Enabled = false;

            // enable selectively:
            if (SelectedLogicNode == null)
                return;

            // remove button:
            removeButton.Enabled = true;

            // specific sets:
            switch (SelectedLogicNode.Type)
            {
                case "LogicNode":
                    newLogicButton.Enabled = true;
                    newDxButton.Enabled = true;
                    newRxButton.Enabled = true;
                    newTestButton.Enabled = true;
                    break;

                case "TreartmentNode":
                    break;

                case "DiagnosisNode":
                    break;

                case "TestNode":
                    break;

                case "ConsequenceNode":
                    var node = SelectedLogicNode as ConsequenceNode;
                    if(node.Consequence == ConsequenceNode.TYPE_HIGEST_OF || node.Consequence == ConsequenceNode.TYPE_SUM_OF)
                        newPointsButton.Enabled = true;
                    else
                        newLogicButton.Enabled = true;
                    break;

                case "PointsNode":
                    newLogicButton.Enabled = true;
                    break;

                default:
                    break;
            }

        }

        private void AddNodeAtSelected(LogicNode node)
        {
            if (SelectedLogicNode == null)
                return;

            // add new logic node under selected node:
            SelectedLogicNode.Children.Add(node);

            // save and update:
            SaveData();
            RepopulatePartialTree(SelectedTreeNode, SelectedLogicNode);

        }


        private void NodeEditor_NodeChanged(object sender, EventArgs e)
        {
            if (SelectedLogicNode != null)
            {
                SaveData();
                SelectedTreeNode.Text = SelectedLogicNode.displayName;
                UpdateAddButtons();
            }
        }


        private void TreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if(this.SelectedTreeNode != null && SelectedLogicNode != null)
                SelectedTreeNode.Text = SelectedLogicNode.displayName;

            // give current editor a change to save:
            if (CurrentEditor != null)
            {
                CurrentEditor.SaveBeforeClose();
                var ctrl = (CurrentEditor as UserControl);
                ctrl.Dock = DockStyle.None;
                splitContainer.Panel2.Controls.Remove(ctrl);
            }
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedLogicNode = e.Node.Tag as LogicNode;
            SelectedTreeNode = e.Node;
            UpdateAddButtons();

            // load the editor:
            if (SelectedLogicNode != null)
                LoadNodeEditor(SelectedLogicNode);
        }


        private void newConseqButton_Click(object sender, EventArgs e)
        {
            Data.LogicTree.Add(new ConsequenceNode());

            // save and update:
            SaveData();
            RepopulateTree();
        }

        private void newPointsButton_Click(object sender, EventArgs e) {  AddNodeAtSelected(new PointsNode()); }
        private void newLogicButton_Click(object sender, EventArgs e) {  AddNodeAtSelected(new LogicNode()); }
        private void newRxButton_Click(object sender, EventArgs e) { AddNodeAtSelected(new TreatmentNode()); }
        private void newDxButton_Click(object sender, EventArgs e) { AddNodeAtSelected(new DiagnosisNode()); }
        private void newTestButton_Click(object sender, EventArgs e) { AddNodeAtSelected(new TestNode()); }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (SelectedLogicNode == null || SelectedTreeNode == null)
                return;

            // get parent of current node:
            var parent_tn = SelectedTreeNode.Parent;

            // if we have a parent, we are note a consequence node:
            if (parent_tn != null)
            {
                var parent = parent_tn.Tag as LogicNode;
                parent.Children.Remove(SelectedLogicNode);
            }

            // if we do not have a parent, we are a consequence node:
            Data.LogicTree.Remove(SelectedLogicNode as ConsequenceNode);

            SaveData();
            RepopulateTree();
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            var testwin = new ScoreTreeTester(TesterChoices)
            {
                Ontology = this.Ontology,
                ScoreTree = Data.LogicTree
            };

            testwin.ShowDialog();
            TesterChoices = testwin.Choises;
            foreach (var item in TesterChoices)
            {
                item.ListView.Items.Remove(item);
            }
        }
    }
}
