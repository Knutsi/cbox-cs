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
    public partial class ConsequenceNodeEditor : UserControl, ILogicNodeEditor
    {
        private LogicNode Node_;

        public ConsequenceNodeEditor()
        {
            InitializeComponent();

            // events:
            groupInput.TextChanged += HandleControlValueChanged;
            highestOfSelect.CheckedChanged += HandleControlValueChanged;
            commentSelect.CheckedChanged += HandleControlValueChanged;
            failSelect.CheckedChanged += HandleControlValueChanged;
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

        public Ontology Ontology
        {
            get; set;
        }

        public event EventHandler NodeChanged;

        public void LoadData()
        {
            var node = Node as ConsequenceNode;

            groupInput.Text = node.Group;

            matchedCommentInput.Text = node.MatchedComment;
            unmatchedCommentInput.Text = node.UnmatchedComment;

            switch (node.Consequence)
            {
                case ConsequenceNode.TYPE_HIGEST_OF:
                    highestOfSelect.Checked = true;
                    break;

                case ConsequenceNode.TYPE_SUM_OF:
                    sumOfSelect.Checked = true;
                    break;


                case ConsequenceNode.TYPE_FAIL_FOR:
                    failSelect.Checked = true;
                    break;

                case ConsequenceNode.TYPE_COMMENT_FOR:
                    commentSelect.Checked = true;
                    break;

                default:
                    break;
            }
        }


        public void SaveData()
        {
            var node = Node as ConsequenceNode;

            // node type:
            if (highestOfSelect.Checked)
                node.Consequence = ConsequenceNode.TYPE_HIGEST_OF;
            else if (sumOfSelect.Checked)
                node.Consequence = ConsequenceNode.TYPE_SUM_OF;
            else if (failSelect.Checked)
                node.Consequence = ConsequenceNode.TYPE_FAIL_FOR;
            else if(commentSelect.Checked)
                node.Consequence = ConsequenceNode.TYPE_COMMENT_FOR;

            // group:
            node.Group = groupInput.Text;

            // comments:
            node.MatchedComment = matchedCommentInput.Text;
            node.UnmatchedComment = unmatchedCommentInput.Text;

            // send event:
            if (NodeChanged != null)
                NodeChanged(this, new EventArgs());
        }

        public void SaveBeforeClose()
        {
            SaveData();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void HandleControlValueChanged(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}
