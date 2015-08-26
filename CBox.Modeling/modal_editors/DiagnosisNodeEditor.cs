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
using cbox.system;
using model = cbox.model;

namespace cbox.modelling.editors
{
    public partial class DiagnosisNodeEditor : Form, IWindowedNodeEditor
    { 
        Node Node_; // node we are wokring on (internal field for property)
        private model.Diagnosis CurrentDx;  // dx currently being edited
        private string CurrentGroup = null;

        private bool MuteEvents = false;

        public DiagnosisNodeEditor()
        {
            InitializeComponent();
            dxTree.AfterSelect += DxTree_AfterSelect;
            groupNameInput.TextChanged += GroupNameInput_TextChanged;

            dxSearchResults.DoubleClick += DxSearchResults_DoubleClick;
        }


        public Node Node
        {
            get
            {
                return Node_;
            }

            set
            {
                Node_ = value;
                LoadData();
            }
        }


        public model.Ontology Ontology { get; set; }

        public DiagnosisData Data
        {
            get
            {
                if (Node == null)
                    return null;

                return Node.HandlerData as DiagnosisData;
            }
        }


        private void LoadDiagnosis(model.Diagnosis dx)
        {
            dxSearchInput.Enabled = true;
            dxSearchResults.Enabled = true;
            majorCheckbox.Enabled = true;
            specificChecbox.Enabled = true;
            groupNameInput.Enabled = true;
            previousCheckbox.Enabled = true;
            missCommentInput.Enabled = true;

            CurrentDx = dx;

            MuteEvents = true;

            groupNameInput.Text = dx.Group;
            majorCheckbox.Checked = dx.Major;
            specificChecbox.Checked = dx.Specific;
            codeLabel.Text = dx.Code;
            dxNameInput.Text = dx.Title;
            missCommentInput.Enabled = true;

            if (groupNameInput.Text == model.Diagnosis.PREVIOUS_GROUP)
                groupNameInput.Enabled = false;
            

            MuteEvents = false;
        }

        private void SaveDiagnosis(bool populate=false)
        {
            var dx = CurrentDx;
            if (dx == null)
                return; 

            dx.Group = groupNameInput.Text;
            dx.Major = majorCheckbox.Checked;
            dx.Specific = specificChecbox.Checked;
            dx.Code = codeLabel.Text;
            dx.Title = dxNameInput.Text;
            dx.MissComment = missCommentInput.Text;

            if(populate)
                PopulateTree();
        }


        private void LoadData()
        {

            PopulateTree();
        }

        private void SaveData()
        {

            PopulateTree();
        }

        private void PopulateTree()
        {
            // remove old:
            dxTree.Nodes.Clear();

            // get all unique dx-groups, and add one for each:
            var groups = (from d in Data.Diagnosis
                         select d.Group).Distinct();

            // create nodes:
            var nodes = (from g in groups
                        select new TreeNode(g)).ToArray();

            dxTree.Nodes.AddRange(nodes);

            // for each node, get the diagnosis with that group and add as nodes:
            foreach (TreeNode node in dxTree.Nodes)
            {
                var dxes = from d in Data.Diagnosis
                           where d.Group == node.Text
                           select d;

                foreach (model.Diagnosis dx in dxes)
                {
                    var flags = "";
                    if (dx.Major) flags += "M";
                    if (dx.Specific) flags += "S";

                    var subnode = new TreeNode(dx.Code + " " + dx.Title + " " + flags){ Tag = dx };
                    node.Nodes.Add(subnode);
                }
            }

            // expand all:
            dxTree.ExpandAll();
        }


        public void SearchDx()
        {
            var query = dxSearchInput.Text;
            if (query.Length < 3)
                return;

            dxSearchResults.Items.Clear();

            var items = from d in this.Ontology.Diagnosis.Search(query)
                        select new ListViewItem(d.Code + " " + d.Name) { Tag = d };

            dxSearchResults.Items.AddRange(items.ToArray());
        }


        private void applyButton_Click(object sender, EventArgs e) { SaveData(); }
        private void cancelButton_Click(object sender, EventArgs e) { Close(); }

        private void newButton_Click(object sender, EventArgs e)
        {
            if (CurrentGroup == null)
                CurrentGroup = model.Diagnosis.DEFAULT_GROUP_NAME;

            this.Data.Diagnosis.Add(new model.Diagnosis() { Group = CurrentGroup });
            PopulateTree();
        }


        private void removeButton_Click(object sender, EventArgs e)
        {
            if (CurrentDx == null)
                return;

            Data.Diagnosis.Remove(CurrentDx);
            PopulateTree();
        }


        private void DxTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (MuteEvents)
                return;

            // is this a dx-node?
            if (e.Node.Tag != null)
            {
                // save current, load new:
                SaveDiagnosis();
                var dx = e.Node.Tag as model.Diagnosis;
                LoadDiagnosis(dx);

                // remember current group:
                CurrentGroup = dx.Group;
            }
        }

        private void GroupNameInput_TextChanged(object sender, EventArgs e)
        {
            if (MuteEvents)
                return;

            if (CurrentDx == null)
                return;

            SaveDiagnosis(true);
        }

        private void dxSearchInput_TextChanged(object sender, EventArgs e)
        {
            SearchDx();
        }


        private void DxSearchResults_DoubleClick(object sender, EventArgs e)
        {
            if (dxSearchResults.SelectedItems.Count <= 0 || CurrentDx == null)
                return;

            var dx = dxSearchResults.SelectedItems[0].Tag as model.DiagnosisCatalogEntry;
            codeLabel.Text = dx.Code;
            dxNameInput.Text = dx.Name;

            CurrentDx.Code = dx.Code;
            CurrentDx.Title = dx.Name;

            SaveDiagnosis(true);
        }


        private void previousCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            groupNameInput.Text = model.Diagnosis.PREVIOUS_GROUP;
            groupNameInput.Enabled = !previousCheckbox.Checked;
            if (!previousCheckbox.Checked)
                groupNameInput.Text = model.Diagnosis.DEFAULT_GROUP_NAME;

            SaveDiagnosis(true);
        }
    }
}
