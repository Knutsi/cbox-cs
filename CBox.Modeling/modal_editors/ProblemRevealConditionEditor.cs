
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

namespace cbox.modelling.editors
{
    public partial class ProblemRevealConditionEditor : Form
    {
        model.ProblemRevealCondition Trigger_;

        public ProblemRevealConditionEditor(model.Ontology ontology)
        {
            InitializeComponent();

            // bind to ontology:
            actionKeysSelect.DataSource = ontology.Actions;
            actionKeysSelect.DisplayMember = "Title";

            individualKeySelect.DataSource = ontology.Tests;
            individualKeySelect.DisplayMember = "Key";

            keyCombobox.DataSource = ontology.Tests;
            keyCombobox.DisplayMember = "Key";
        }


        public model.ProblemRevealCondition Trigger {

            get
            {
                return Trigger_;
            }

            set
            {
                Trigger_ = value;
                LoadData();
            }

        }


        private void LoadData()
        {

            // load trigger key:
            keyCombobox.Text = Trigger.Key;

            // load autotriggers:
            triggersList.Text = "";
            foreach (var autotrigger_key in Trigger.Autotriggers)
            {
                triggersList.Text += autotrigger_key + Environment.NewLine;
            }

        }


        private void SaveData()
        {
            Trigger.Key = keyCombobox.Text;
            var autotriggers = from t in triggersList.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)
                               where t.Trim() != String.Empty
                               select t.Trim();

            Trigger.Autotriggers = new BindingList<string>(autotriggers.ToList());
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SaveData();
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var action = actionKeysSelect.SelectedItem as model.Action;
            if(action != null)
            {
                foreach (var key in action.Yield)
                {
                    triggersList.Text += key + Environment.NewLine;
                }
            }
        }

        private void addTriggerKeyButton_Click(object sender, EventArgs e)
        {
            if (individualKeySelect.Text.Trim() != String.Empty)
                triggersList.Text += individualKeySelect.Text + Environment.NewLine;
        }
    }
}
