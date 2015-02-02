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
    public partial class TextInputPrompt : Form
    {
        public TextInputPrompt()
        {
            InitializeComponent();
        }

        public string Question { 
            get { return questionLabel.Text; }
            set { questionLabel.Text = value; }
        }

        public string Value { 
            get { return valueInput.Text; } 
            set { valueInput.Text = value; }
        }


        public DialogResult Result { get; set; }

        private void okButton_Click(object sender, EventArgs e)
        {
            Result = System.Windows.Forms.DialogResult.OK;

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Result = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


    }
}
