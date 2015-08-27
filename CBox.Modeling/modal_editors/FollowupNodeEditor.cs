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
using model = cbox.model;

namespace cbox.modelling.editors
{
    public partial class FollowupNodeEditor : Form, IWindowedNodeEditor
    {
        public Node Node_ { get; private set; }
        private model.FollowupQuestion CurrentQuestion;

        private bool EventsDisabled = false;

        public FollowupNodeEditor()
        {
            InitializeComponent();
            ClearForm();

            var table = new DataTable();
            table.Columns.Add("Correct", typeof(bool));
            table.Columns.Add("Answer", typeof(string));
            answerDataGrid.DataSource = table;

            questionList.SelectedValueChanged += QuestionList_SelectedValueChanged;
        }


        public Node Node
        {
            get{ return this.Node_; }

            set
            {
                this.Node_ = value;
                LoadData();
            }
        }


        public model.Ontology Ontology { get; set; }


        public FollowupData Data
        {
            get
            {
                if (Node == null)
                    return null;

                return Node.HandlerData as FollowupData;
            }
        }

        public void ClearForm()
        {

            CurrentQuestion = null;

            // disable inputs:
            questionInput.Enabled = false;
            questionInput.Text = string.Empty;
            answerDataGrid.Enabled = false;
            answerDataGrid.DataSource = new DataTable();

            multipleChoiceSelect.Enabled = false;
            singleChoiceSelect.Enabled = false;
        }


        public void LoadQuestion(model.FollowupQuestion question)
        {
            CurrentQuestion = question;

            // enable inputs:
            questionInput.Enabled = true;
            answerDataGrid.Enabled = true;
            singleChoiceSelect.Enabled = true;
            multipleChoiceSelect.Enabled = true;

            // set control values:
            questionInput.Text = question.Question;
            if (question.Type == model.FollowupQuestion.TYPE_SINGLE_CHOICE)
                singleChoiceSelect.Checked = true;
            else
                multipleChoiceSelect.Checked = true;

            // generate table:
            var table = answerDataGrid.DataSource as DataTable;
            table.Clear();
            foreach (var answer in question.Answers)
                table.Rows.Add(answer.Correct, answer.Text);
        }


        public void SaveQuestion()
        {
            if (CurrentQuestion == null)
                return;

            EventsDisabled = true;

            // save data:
            CurrentQuestion.Question = questionInput.Text;
            if (multipleChoiceSelect.Checked)
                CurrentQuestion.Type = model.FollowupQuestion.TYPE_MULTIPLE_CHOICE;
            else
                CurrentQuestion.Type = model.FollowupQuestion.TYPE_SINGLE_CHOICE;

            // transfer table data:
            CurrentQuestion.Answers = new BindingList<model.FollowupQuestionAnswer>();

            var table = answerDataGrid.DataSource as DataTable;
            foreach (DataRow row in table.Rows)
            {
                var answer = new model.FollowupQuestionAnswer()
                {
                    Correct = (row["Correct"] as bool?).GetValueOrDefault(false),
                    Text = row["Answer"] as string
                };

                CurrentQuestion.Answers.Add(answer);
            }


            EventsDisabled = false;
        }


        public void LoadData()
        {
            SaveQuestion();
            questionList.DataSource = Data.Questions;
            questionList.DisplayMember = "Question";
        }


        public void SaveData()
        {

        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void newButton_Click(object sender, EventArgs e)
        {
            EventsDisabled = true;

            SaveQuestion();
            var question = new model.FollowupQuestion();
            Data.Questions.Add(question);
            LoadQuestion(question);

            EventsDisabled = false;
        }


        private void removeButton_Click(object sender, EventArgs e)
        {
            var selected = questionList.SelectedItem as model.FollowupQuestion;
            if (selected != null)
                Data.Questions.Remove(selected);

            if (selected == CurrentQuestion)
                ClearForm();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            SaveQuestion();
            SaveData();
        }


        private void QuestionList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (EventsDisabled)
                return;

            var question = questionList.SelectedItem as model.FollowupQuestion;

            // save existing:
            SaveQuestion();

            if (questionList.SelectedItem != null)
                LoadQuestion(question);
        }
    }
}
