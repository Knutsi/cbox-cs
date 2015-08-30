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
    public partial class LogicNodeEditor : UserControl, ILogicNodeEditor
    {
        private LogicNode Node_;

        public LogicNodeEditor()
        {
            InitializeComponent();

            // events:
            allSelect.CheckedChanged += HandleLogicChanged;
            eitherSelect.CheckedChanged += HandleLogicChanged;
            neitherSelect.CheckedChanged += HandleLogicChanged;
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
            get; set;
        }

        public event EventHandler NodeChanged;

        public void SaveBeforeClose()
        {
            SaveData();
        }


        public void SaveData()
        {
            
            if (allSelect.Checked)
                Node.Logic = LogicNode.LOGIC_ALL_OF;
            else if (eitherSelect.Checked)
                Node.Logic = LogicNode.LOGIC_EITHER_OF;
            else if (neitherSelect.Checked)
                Node.Logic = LogicNode.LOGIC_NONE_OF;

            // event:
            if (NodeChanged != null)
                NodeChanged(this, new EventArgs());



        }

        public void LoadData()
        {
            switch (Node.Logic)
            {
                case LogicNode.LOGIC_ALL_OF:
                    allSelect.Checked = true;
                    break;

                case LogicNode.LOGIC_EITHER_OF:
                    eitherSelect.Checked = true;
                    break;

                case LogicNode.LOGIC_NONE_OF:
                    neitherSelect.Checked = true;
                    break;

                default:
                    throw new Exception("LogicNode with unknown logic type " + Node.Logic);

            }

        }


        private void HandleLogicChanged(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}
