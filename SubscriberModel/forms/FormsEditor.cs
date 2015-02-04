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
    public partial class FormsEditor : Form
    {
        cbox.model.Form SelectedForm = null;
        cbox.model.Headline SelectedHeadline = null;

        public FormsEditor()
        {
            InitializeComponent();

            // bind to current ontology:
            formsList.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            formsList.DataSource = Program.OntologyInstance.Forms;

            
        }

        private void addFormButton_Click(object sender, EventArgs e)
        {
            var form = new cbox.model.Form();
            Program.OntologyInstance.AddForm(form);
        }

        private void formsList_SelectedValueChanged(object sender, EventArgs e)
        {
            SelectedForm = (cbox.model.Form)formsList.SelectedItem;

            titleInput.DataBindings.Clear();
            colorInput.DataBindings.Clear();
            headlinesList.DataBindings.Clear();
            headlinesList.DataSource = null;

            titleInput.DataBindings.Add("Text", SelectedForm, "Title");
            colorInput.DataBindings.Add("Text", SelectedForm, "HeadColor");
            headlinesList.DataSource = SelectedForm.Headlines;
            headlinesList.DisplayMember = "Title";

            SelectedHeadline = null;
        }

        private void removeFormButton_Click(object sender, EventArgs e) 
        { 
            Program.OntologyInstance.RemoveForm(SelectedForm); 
        }

        private void addHeadlineButton_Click(object sender, EventArgs e)
        {
            // get name of headline:
            var prompt = new TextInputPrompt()
            {
                Question = "Headline:"
            };

            prompt.ShowDialog();

            if (prompt.Result == System.Windows.Forms.DialogResult.OK && prompt.Value != string.Empty)
                SelectedForm.AddHeadline(prompt.Value);

            Console.WriteLine(prompt.Value);
            
        }

        private void removeHeadlineButton_Click(object sender, EventArgs e)
        {
            if(SelectedHeadline != null)
                SelectedForm.RemoveHeadline(SelectedHeadline);
        }

        private void headlinesList_SelectedValueChanged(object sender, EventArgs e)
        { 
            SelectedHeadline = (cbox.model.Headline)headlinesList.SelectedItem;

            if (SelectedHeadline != null)
            {
                headlineTitleInput.DataBindings.Clear();
                actionsList.DataSource = null;

                headlineTitleInput.DataBindings.Add("Text", SelectedHeadline, "Title");
                actionsList.DataSource = SelectedHeadline.ActionIdents;
                actionsList.DisplayMember = "Title";
            }

        }
    }
}
