using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cbox.generation.setter;
using cbox.modelling.setter_editors;

namespace OntologyEditor
{
    public partial class TestEditor : Form
    {

        public cbox.model.Test CurrentTest { get; set; }
        public ISetterEditor CurrentSetterEditor;

        public TestEditor(cbox.model.Test test)
        {
            InitializeComponent();

            // set current test to the one we were initialized by:
            CurrentTest = test;
            this.Text = test.Key;

            // use data binding for most values:
            keyInput.DataBindings.Add("Text", test, "Key");
            titleInput.DataBindings.Add("Text", test, "Title");
            suffixInput.DataBindings.Add("Text", test, "Suffix");
            unitInput.DataBindings.Add("Text", test, "Unit");
            derivedFromSelect.DataBindings.Add("Text", test, "Parent");
            acumulativeCheckbox.DataBindings.Add("Checked", test, "Accumulative");

            // load the datatype (w/o binding):
            datatypeSelect.Text = CurrentTest.Datatype;
            SetDataype();

            // load setter:
            if (PossibleSetters.Contains(CurrentTest.SetterIdent))
            {
                setterSelect.Text = CurrentTest.SetterIdent;
                LoadSetterEditor();
            }
            

            // bind to data:
            var bs = new BindingSource();
            bs.DataSource = this.CurrentTest;

            // update derive checkbox:
            deriveCheckbox.Checked = (test.Parent != string.Empty && test.Parent != null);

            // ensure we have the correct selects available now, and in the future:
            this.UpdateDeriveSelects();
            deriveCheckbox_CheckedChanged(null, null);  // simulate event
            Program.OntologyInstance.OnChange += OntologyInstance_OnChange;

            SetupUIEvents();
        }


        private void SetupUIEvents()
        {
            // when setter
            datatypeSelect.SelectedValueChanged += (object s, EventArgs e) =>
            {
                SetDataype();
            };

            // save selection:
            setterSelect.TextChanged += (object s, EventArgs e) =>
            {
                CurrentTest.SetterIdent = setterSelect.Text;
                LoadSetterEditor();
            };
        }


        void OntologyInstance_OnChange(object sender) {  this.UpdateDeriveSelects(); }


        public void UpdateDeriveSelects()
        {
            this.derivedFromSelect.Items.Clear();

            foreach (cbox.model.Test test in Program.OntologyInstance.Tests)
            {
                if(test.Key != null)
                    this.derivedFromSelect.Items.Add(test.Key);
            }
        }

        /// <summary>
        /// Called in response to selecting a new datatype.  Will update the availabel setters.
        /// </summary>
        public void SetDataype()
        {
            var old_datatype = CurrentTest.Datatype;
            this.CurrentTest.Datatype = datatypeSelect.Text;

            // has the type not changed changed? - no action needed
            if (old_datatype == CurrentTest.Datatype)
                return;

            // otherwise.. we need to update the setter pickers and clear old data:
            PopulateSetters();
            CurrentTest.SetterXMLData = null;   
        }

        /// <summary>
        /// List of possible setters, based on curren datatype.
        /// </summary>
        private List<string> PossibleSetters
        {
            get 
            {
                return (from s in SetterLibrary.Default.SettersByDatatype(CurrentTest.Datatype)
                        select s.Ident_).ToList(); 
            }
        }

        /// <summary>
        /// Fills the settes select with list based on current datatype.
        /// </summary>
        public void PopulateSetters() 
        {
            if(CurrentTest.Datatype == null)
            {
                setterSelect.Enabled = false;
                setterSelect.DataSource = null;
            }
            else
            {
                setterSelect.Enabled = true;
                setterSelect.DataSource = this.PossibleSetters;
            }
        }


        /// <summary>
        /// Loads the relevant setter editor.
        /// </summary>
        private void LoadSetterEditor()
        {
            setterPanel.Controls.Clear();

            if (CurrentTest.SetterIdent == null)
                return;

            var editor = SetterEditorLibrary.GetEditor(CurrentTest.SetterIdent) as Control;
            if(editor != null)
            {
                setterPanel.Controls.Add(editor);
                editor.Dock = DockStyle.Fill;
                CurrentSetterEditor = editor as ISetterEditor;

                // load existing data, if any:
                if (CurrentTest.SetterXMLData != null)
                    CurrentSetterEditor.SetterXmlData = CurrentTest.SetterXMLData;
                else
                    CurrentSetterEditor.SetterXmlData = null;
            }
        }

        /// <summary>
        /// Called to save the setter data.
        /// </summary>
        private void SaveSetterEditorData()
        {
            if(CurrentSetterEditor == null)
                return;

            CurrentTest.SetterXMLData = CurrentSetterEditor.SetterXmlData;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveSetterEditorData();

            base.OnFormClosing(e);
        }
        


        private void deriveCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            derivedFromSelect.Enabled = (deriveCheckbox.Checked == true);

            if (!deriveCheckbox.Checked)
                derivedFromSelect.Text = string.Empty;

        }
    }
}
