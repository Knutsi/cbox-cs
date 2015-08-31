using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using model = cbox.model;
using cbox.scoretree;

namespace cbox.modelling
{
    public partial class ScoreTreeTester : Form
    {
        public ScoreTree ScoreTree { get; set; }
        public List<ListViewItem> Choises = new List<ListViewItem>();

        public ScoreTreeTester(List<ListViewItem> items=null)
        {
            InitializeComponent();

            diagnosisPicker.DiagnosisPicked += HandleDiagnosisPicked;
            treatmentPicker.TreatmentPicked += HandleTreatmentPicked;
            testPicker.TestPicked += HandleTestPicked;

            // restore old items, if given:
            if(items != null)
            {
                foreach (var item in items)
                    choiceList.Items.Add(item);

                SaveChoices();
            }

            this.Shown += ScoreTreeTester_Activated;
        }

        private void ScoreTreeTester_Activated(object sender, EventArgs e)
        {
            RunTree();
        }

        public model.Ontology Ontology
        {
            set
            {
                diagnosisPicker.Ontology = value;
                treatmentPicker.Ontology = value;
                testPicker.Ontology = value;
            }
        }

        private void RunTree()
        {
            outputView.Text = string.Empty;
            outputView.Text += "Run tree " + DateTime.Now.ToString() + Environment.NewLine;

            // get objects:
            SaveChoices();
            var objects = from i in Choises select i.Tag;
            ScoreTree.Objects = objects.ToList();
            var result = ScoreTree.Result;

            var nl = Environment.NewLine;

            outputView.Text += result.Score + "pt." + nl;
            outputView.Text += result.MaxScore + "max" + nl;
            outputView.Text += result.Percentage + "%" + nl;
            outputView.Text += result.Failed + " failed status" + nl;
            outputView.Text += "Comments: " + nl;
                
            outputView.Text += string.Join(Environment.NewLine, result.Comments);
        }

        private void SaveChoices()
        {
            this.Choises.Clear();

            foreach (var item in choiceList.Items)
                Choises.Add(item as ListViewItem);
            
        }


        private void HandleDiagnosisPicked(object sender, EventArgs e)
        {
            var dx = diagnosisPicker.SelectedDx;
            choiceList.Items.Add(new ListViewItem(dx.Name) { Tag = dx });

            RunTree();
            SaveChoices();
        }


        private void HandleTreatmentPicked(object sender, EventArgs e)
        {
            var rx = treatmentPicker.SelectedRx;
            choiceList.Items.Add(new ListViewItem(rx.Title) { Tag = rx });

            RunTree();
            SaveChoices();
        }


        private void HandleTestPicked(object sender, EventArgs e)
        {
            var test = testPicker.SelectedTest;
            choiceList.Items.Add(new ListViewItem(test.Key) { Tag = test });

            RunTree();
            SaveChoices();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (choiceList.Items.Count <= 0 && choiceList.SelectedItems.Count > 0)
                return;

            var item = choiceList.SelectedItems[0];
            choiceList.Items.Remove(item);

            RunTree();
            SaveChoices();
        }


        private void clearButton_Click(object sender, EventArgs e)
        {
            choiceList.Items.Clear();
            SaveChoices();
        }
    }
}
