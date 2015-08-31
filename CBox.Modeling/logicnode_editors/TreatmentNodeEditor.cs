using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cbox.scoretree;

using cbox.model;

namespace cbox.modelling.editors
{
    public partial class TreatmentNodeEditor : UserControl, ILogicNodeEditor
    {
        private LogicNode Node_;
        private Ontology Ontology_;
        public event EventHandler NodeChanged;

        public TreatmentNodeEditor()
        {
            InitializeComponent();

            // events:
            treatmentPicker.TreatmentPicked += HandleTreatmentPicked;
        }

        public LogicNode Node
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

        public Ontology Ontology
        {
            get
            {
                return Ontology_;
            }

            set
            {
                Ontology_ = value;
                treatmentPicker.Ontology = value;
            }
        }


        public TreatmentNode Data
        {
            get { return Node as TreatmentNode;  }
        }


        public void SaveBeforeClose()
        {
            SaveData();
        }

        public void LoadData()
        {
            if (Data == null)
                return;

            nameLabel.Text = Data.Name;
            positiveOnAnyCheckbox.Checked = Data.PositiveOnAny;
        }


        public void SaveData()
        {
            if (Data == null)
                return;

            Data.Name = nameLabel.Text;
            Data.PositiveOnAny = positiveOnAnyCheckbox.Checked;

            if (NodeChanged != null)
                NodeChanged(this, new EventArgs());
        }


        private void HandleTreatmentPicked(object sender, EventArgs e)
        {
            Data.Ident = treatmentPicker.SelectedRx.Ident;
            nameLabel.Text = treatmentPicker.SelectedRx.Title;
            modifierSelect.DataSource = treatmentPicker.SelectedRx.Modifiers;

            SaveData();
        }

        private void positiveOnAnyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (positiveOnAnyCheckbox.Checked)
            {
                modifierSelect.Enabled = false;
                treatmentPicker.Enabled = false;
            }
            else
            {
                modifierSelect.Enabled = true;
                treatmentPicker.Enabled = true;
            }

            SaveData();       
        }
    }
}
