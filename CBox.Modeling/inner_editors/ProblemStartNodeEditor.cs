using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cbox.model;
using cbox.generation;
using cbox.generation.nodetype;

namespace cbox.modelling.editors
{
    public partial class ProblemStartNodeEditor : UserControl, IInnerEditor
    {
        private bool EventsDisabled = false;
        private List<CheckBox> Checkboxes = new List<CheckBox>();


        public ProblemStartNodeEditor()
        {
            InitializeComponent();
        }

        public Node Node
        {
            get { return _Node; }
            set { _Node = value; LoadNode(); }
        }
        private Node _Node;

        public NodeEditor ParentEditor
        {
            get;
            set;
        }

        public void OnOuterEditorClosing()
        {
            SaveNode();
        }


        public ProblemStartData Data
        {
            get
            {
                return (ProblemStartData)Node.HandlerData;
            }
        }

        public model.Ontology Ontology
        {
            get { return _Ontology; }
            set 
            { 
                _Ontology = value;

                // load all checkboxes:
                if (Ontology != null)
                {
                    foreach (var class_ in Ontology.Classes)
                    {
                        // create checboxes, add to our own list and the flow control:
                        var cb = new CheckBox() { Text = class_.Title, Tag = class_.Ident };
                        checkboxFlowLayout.Controls.Add(cb);
                        Checkboxes.Add(cb);

                        if (class_.Ident == "general")
                            cb.Enabled = false;
                        
                        // when changed, they should save the node:
                        cb.CheckedChanged += (object sender, EventArgs e) => 
                        { 
                            if(!EventsDisabled)
                                SaveNode(); 
                        };
                    }
                }
            }
        }
        private Ontology _Ontology;


        public void LoadNode()
        {
            // dont save on each check while loading:
            EventsDisabled = true;

            // clear all checkboxes:
            foreach (var checkbox in Checkboxes)
                checkbox.Checked = false;

            // eanble those mathcing classes:
            foreach (var checkbox in Checkboxes)
                foreach (var class_ in Data.Classes)
                    if (class_ == checkbox.Text)
                        checkbox.Checked = true;

            // bind trigger conditions:
            triggerConditionList.DataSource = Data.Triggers;
            triggerConditionList.DisplayMember = "DisplayName";

            EventsDisabled = false;
        }


        public void SaveNode()
        {
            // simply grab title of all checked checkboxes:
            var classes = (from c in Checkboxes
                          where c.Checked
                          select c.Text).ToList();

            // save that as chose classes:
            Data.Classes = classes;
            Node.Handler.SaveData();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var editor = new ProblemRevealConditionEditor(this.Ontology);
            editor.Trigger = new ProblemRevealCondition() { Key = "demo.key" };
            editor.ShowDialog();

            Data.Triggers.Add(editor.Trigger);
        }


        private void editButton_Click(object sender, EventArgs e)
        {
            var selected = triggerConditionList.SelectedItem as ProblemRevealCondition;
            if(selected != null)
            {
                var editor = new ProblemRevealConditionEditor(this.Ontology);
                editor.Trigger = selected;
                editor.ShowDialog();
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var remove = new List<ProblemRevealCondition>();

            foreach (var selected in triggerConditionList.SelectedItems)
                remove.Add(selected as ProblemRevealCondition);

            foreach (var trigger in remove)
                Data.Triggers.Remove(trigger);

        }

    }
}
