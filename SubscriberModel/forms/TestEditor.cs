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
    public partial class TestEditor : Form
    {

        public cbox.model.Test CurrentTest { get; set; }

        public TestEditor(cbox.model.Test test)
        {
            InitializeComponent();

            CurrentTest = test;
            this.Text = test.Key;

            keyInput.DataBindings.Add("Text", test, "Key");
            titleInput.DataBindings.Add("Text", test, "Title");
            suffixInput.DataBindings.Add("Text", test, "Suffix");
            unitInput.DataBindings.Add("Text", test, "Unit");
            typeSelect.DataBindings.Add("Text", test, "Datatype");
            derivedFromSelect.DataBindings.Add("Text", test, "Parent");
            generatorSelect.DataBindings.Add("Text", test, "GeneratorName");
            acumulativeCheckbox.DataBindings.Add("Checked", test, "Accumulative");

            // bind to data:
            var bs = new BindingSource();
            bs.DataSource = this.CurrentTest;

            // update derive checkbox:
            deriveCheckbox.Checked = (test.Parent != string.Empty && test.Parent != null);

            // ensure we have the correct selects available now, and in the future:
            this.UpdateDeriveSelects();
            deriveCheckbox_CheckedChanged(null, null);  // simulate event
            Program.OntologyInstance.OnChange += OntologyInstance_OnChange;
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

        private void deriveCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            derivedFromSelect.Enabled = (deriveCheckbox.Checked == true);

            if (!deriveCheckbox.Checked)
                derivedFromSelect.Text = string.Empty;

        }
    }
}
