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
    public partial class PointsNodeEditor : UserControl, ILogicNodeEditor
    {
        private LogicNode Node_;

        private bool EventsDisabled = false;

        public PointsNodeEditor()
        {
            InitializeComponent();

            // events:
            pointsInput.ValueChanged += HandleControlValueChanged;
            matchedCommentInput.TextChanged += HandleControlValueChanged;
            unmatchedCommentInput.TextChanged += HandleControlValueChanged;
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

        public PointsNode Data
        {
            get { return Node as PointsNode; }
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
            Data.Points = Convert.ToInt32(pointsInput.Value);
            Data.MatchedComment = matchedCommentInput.Text;
            Data.UnmatchedComment = unmatchedCommentInput.Text;
        }


        public void LoadData()
        {
            EventsDisabled = true;

            pointsInput.Value = Data.Points;
            matchedCommentInput.Text = Data.MatchedComment;
            unmatchedCommentInput.Text = Data.UnmatchedComment;

            EventsDisabled = false;
        }


        private void HandleControlValueChanged(object sender, EventArgs e)
        {
            if (EventsDisabled)
                return;

            SaveData();
            if (NodeChanged != null)
                NodeChanged(this, new EventArgs());
        }
    }
}
