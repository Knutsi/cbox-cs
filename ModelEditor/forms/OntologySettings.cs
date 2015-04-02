using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ModelEditor.forms
{
    public partial class OntologySettings : Form
    {
        public OntologySettings()
        {
            InitializeComponent();

            Update();
        }

        public void Update()
        {
            // is an ontology loaded?
            if (Program.CurrentOntology == null)
            {
                if (Properties.Settings.Default.fallback_ontology != null)
                    ontologyPathInput.Text = Properties.Settings.Default.fallback_ontology;
                else
                    ontologyPathInput.Text = string.Empty;

                loadInfo.Text = "(No ontology loaded)";
            }
            else
            {
                // write some info about the loaded ontology:
                ontologyPathInput.Text = Program.CurrentOntologyPath;
                var info = string.Format(
                    "Loaded ontology\r\nClasses:{3}\r\nTests: {0}\r\nActions:{1}\r\nForms:{2}\r\n\r\nTests:\r\n", 
                    Program.CurrentOntology.Tests.Count, 
                    Program.CurrentOntology.Actions.Count,
                    Program.CurrentOntology.Forms.Count,
                    Program.CurrentOntology.Classes.Count);

                // append all tests to info:
                foreach (var test in Program.CurrentOntology.Tests)
                {
                    info += test.Key + "\r\n";
                }

                loadInfo.Text = info;
            }
        }

        private void ontologyPathInput_TextChanged(object sender, EventArgs e)
        {
            if (ontologyPathInput.Text.Trim() == string.Empty)
            {
                loadButton.Enabled = false;
                useForNoneSystemCheckbox.Enabled = false;
            }
            else
            {
                loadButton.Enabled = true;
                useForNoneSystemCheckbox.Enabled = true;
            }
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ontologyPathInput.Text = dialog.FileName;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            var path = ontologyPathInput.Text;

            // check that file exists:
            if (!File.Exists(path))
            {
                MessageBox.Show(
                    "Provided path does not exist", 
                    "Invalid file path", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }

            // load the ontology:
            Program.LoadOntology(path);
            Update();
        }

        private void useForNoneSystemCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (useForNoneSystemCheckbox.Checked == true)
            {
                Properties.Settings.Default.fallback_ontology = ontologyPathInput.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.fallback_ontology = null;
                Properties.Settings.Default.Save();
            }
                
        }
    }
}
