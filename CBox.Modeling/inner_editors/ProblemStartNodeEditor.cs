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
            throw new NotImplementedException();
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

    }
}
