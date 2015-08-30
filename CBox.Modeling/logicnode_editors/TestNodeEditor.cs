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
using cbox.scoretree;

namespace cbox.modelling.editors
{
    public partial class TestNodeEditor : UserControl, ILogicNodeEditor
    {
        private LogicNode Node_;
        private Ontology Ontology_;
        

        public TestNodeEditor()
        {
            InitializeComponent();

            testPicker.TestPicked += HandleTestPicked;
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
                testPicker.Ontology = value;
            }
        }

        public TestNode Data
        {
            get { return Node as TestNode; }
        }

        public event EventHandler NodeChanged;

        public void SaveBeforeClose()
        {
            SaveData();
        }

        public void LoadData()
        {
            if (Data == null)
                return;

            keyLabel.Text = Data.Key;
            titleLabel.Text = Data.Title;
        }


        public void SaveData()
        {
            if (Data == null)
                return;

            Data.Key = keyLabel.Text;
            Data.Title = titleLabel.Text;

            if (NodeChanged != null)
                NodeChanged(this, new EventArgs());

        }


        private void HandleTestPicked(object sender, EventArgs e)
        {
            keyLabel.Text = testPicker.SelectedTest.Key;
            titleLabel.Text = testPicker.SelectedTest.Title;

            SaveData();
        }

    }
}
