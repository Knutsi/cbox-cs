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
    public partial class DxNodeEditor : UserControl, ILogicNodeEditor
    {
        private LogicNode Node_;
        private Ontology Ontology_;

        public DxNodeEditor()
        {
            InitializeComponent();

            diagnosisPicker.DiagnosisPicked += HandleDiagnosisPicked;
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

        private DiagnosisNode Data
        {
            get
            {
                return Node as DiagnosisNode;
            }
        }

        public Ontology Ontology
        {
            get { return Ontology_; }
            set
            {
                Ontology_ = value;
                this.diagnosisPicker.Ontology = value;
            }
        }


        public event EventHandler NodeChanged;

        public void SaveBeforeClose()
        {
            SaveData();
        }

        public void LoadData()
        {
            if (Data != null)
            {
                codeLabel.Text = Data.Code;
                nameLabel.Text = Data.Name;
            }
        }


        public void SaveData()
        {
            if (Data != null)
            {
                Data.Code = codeLabel.Text;
                Data.Name = nameLabel.Text;

                // notify:
                if (NodeChanged != null)
                    NodeChanged(this, new EventArgs());
            }
        }


        private void HandleDiagnosisPicked(object sender, EventArgs e)
        {
            codeLabel.Text = diagnosisPicker.SelectedDx.Code;
            nameLabel.Text = diagnosisPicker.SelectedDx.Name;
            SaveData();
        }
    }
}
