using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OntologyEditor
{
    public partial class ActionEditor : Form
    {

        private cbox.model.Action _SelectedAction;

        public ActionEditor()
        {
            InitializeComponent();

            UpdateActionList();
            UpdateClassSelection();
            UpdateFormHeadlineSelection();
            UpdateYieldSearchBox();
        }

        public void UpdateActionList()
        {
            actionList.DataSource = null;
            actionList.DisplayMember = "Title";
            actionList.DataSource = Program.OntologyInstance.Actions;
        }

        public void UpdateClassSelection()
        {
            classSelect.Items.Clear();

            foreach (cbox.model.ProblemClass class_ in Program.OntologyInstance.Classes)
            {
                var checked_ = SelectedAction.TargetClasses.Contains(class_.Title);
                classSelect.Items.Add(class_.Title, checked_);
            }
        }

        public void UpdateFormHeadlineSelection()
        {
            formPlacementSelect.Items.Clear();

            // generate all form-headline texts:
            foreach (var form_headline in Program.OntologyInstance.AllHeadlines)
            {
                var agregate = String.Format(
                    "{0} - {1}", 
                    form_headline.Item1.Title, 
                    form_headline.Item2.Title);

                formPlacementSelect.Items.Add(agregate);
            }

            // select the headline this action is under, if any (it should be).
            // we'll get the headline we're in, then find the index of that one
            // in the AllHeadlines tuple list:
            if (SelectedAction != null)
            {
                var our_headline = Program.OntologyInstance.GetHeadlineByformIdent(SelectedAction.Ident);
                if (our_headline != null)
                {
                    // get index, and set out headline picker to that index:
                    var all_headlines = Program.OntologyInstance.AllHeadlines;
                    var headline_index = -1;
                    for (var i = 0; i < all_headlines.Count; i++)
                        if (all_headlines[i].Item2 == our_headline)
                            headline_index = i;

                    formPlacementSelect.SelectedIndex = headline_index;
                }
                else
                {
                    formPlacementSelect.SelectedIndex = -1;
                }
            }
            else
                formPlacementSelect.SelectedIndex = -1;

        }

        public void UpdateYieldSearchBox()
        {
            yieldsSearch.Items.Clear();

            // add all items that is not currently in the yield list:
            yieldsSearch.Items.AddRange(
                (from test in Program.OntologyInstance.Tests
                 where SelectedAction.Yield.Contains(test.Key) != true
                 select test.Key).ToArray()
                );
            
        }

        public void SelectActionFromList()
        {
            if(actionList.SelectedItems.Count == 1)
                SelectedAction = (cbox.model.Action)actionList.SelectedItem;
        }

        public cbox.model.Action SelectedAction {
            get 
            {
                return _SelectedAction;
            }

            set 
            {
                _SelectedAction = value;

                // clear bindings:
                titleInput.DataBindings.Clear();
                riskInput.DataBindings.Clear();
                costInput.DataBindings.Clear();
                painInput.DataBindings.Clear();
                occtimeInput.DataBindings.Clear();
                waittimeInput.DataBindings.Clear();

                yieldsSelect.DataSource = null;

                // rebind to new item:
                titleInput.DataBindings.Add("Text", _SelectedAction, "Title");

                riskInput.DataBindings.Add("Value", _SelectedAction, "Risk");
                costInput.DataBindings.Add("Value", _SelectedAction, "Cost");
                painInput.DataBindings.Add("Value", _SelectedAction, "Pain");

                occtimeInput.DataBindings.Add("Value", _SelectedAction, "TimeUsedOccupied");
                waittimeInput.DataBindings.Add("Value", _SelectedAction, "TimeUsedProcess");

                yieldsSelect.DataSource = SelectedAction.Yield;

                // update complex selection controls:
                UpdateYieldSearchBox();
                UpdateClassSelection();
                UpdateFormHeadlineSelection();
            }
        }

        private void addActionButton_Click(object sender, EventArgs e)
        {
            var prompt = new TextInputPrompt() { Question = "Action name:" };
            
            if(prompt.ShowDialog() == System.Windows.Forms.DialogResult.OK && prompt.Value != String.Empty)
            {
                Program.OntologyInstance.AddAction(prompt.Value);
            }
        }

        private void removeActionButton_Click(object sender, EventArgs e)
        {
            if (SelectedAction != null)
                Program.OntologyInstance.RemoveAction(SelectedAction);
        }

        private void actionList_SelectedValueChanged(object sender, EventArgs e)
        {
            SelectActionFromList();
        }

        private void addYieldButton_Click(object sender, EventArgs e)
        {
            if(yieldsSearch.SelectedItem != null && yieldsSearch.Text != String.Empty)
            {
                // TODO: validate that key exists!

                SelectedAction.Yield.Add(yieldsSearch.Text);
                UpdateYieldSearchBox(); // remove the selected item
                SelectedAction = SelectedAction;    // reloads the yield list

                yieldsSearch.Text = String.Empty;
            }
        }

        private void removeYieldButton_Click(object sender, EventArgs e)
        {
            if(yieldsSelect.SelectedItem != null)
            {
                SelectedAction.Yield.Remove((string)yieldsSelect.SelectedItem);
                UpdateYieldSearchBox(); // remove the selected item
                SelectedAction = SelectedAction;    // reloads the yield list
            }
        }

        private void classSelect_Click(object sender, EventArgs e)
        {
            if(SelectedAction != null)
            {
                SelectedAction.TargetClasses.Clear();
                foreach (var item in classSelect.CheckedItems)
                {
                    SelectedAction.TargetClasses.Add((string)item);
                }
            }
        }

        private void formPlacementSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get selected form-headline combo based in selected index:
            var form_headline = Program.OntologyInstance.AllHeadlines[formPlacementSelect.SelectedIndex];
            
            // assign current action to form:
            var headline = form_headline.Item2;
            Program.OntologyInstance.AssignActionToHeadline(SelectedAction, headline);

        }




        
    }
}
