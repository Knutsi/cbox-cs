﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cbox.system;

namespace OntologyEditor
{
    public partial class EditDiagnosis : Form
    {
        CBoxSystem CurrentSystem;
        cbox.model.Diagnosis CurrentDiagnosis;

        public EditDiagnosis()
        {
            InitializeComponent();
        }

        public EditDiagnosis(CBoxSystem system, cbox.model.Diagnosis dx)
        {
            InitializeComponent();

            this.CurrentSystem = system;
            this.CurrentDiagnosis = dx;

            //this.titleTextBox.Text = dx.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.CurrentDiagnosis.Name = this.titleTextBox.Text;
        }
    }
}
