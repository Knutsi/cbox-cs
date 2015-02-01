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
    public partial class TestsWindow : Form
    {
        public TestsWindow()
        {
            InitializeComponent();
        }

        private void TestsWindow_Load(object sender, EventArgs e)
        {
            // ensure we refresh when ontology changes:
            Program.OntologyInstance.OnChange += handleOntologyChange;
        }


        private void TestsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.OntologyInstance.OnChange -= handleOntologyChange;
        }


        void handleOntologyChange(object sender)
        {
            this.testsDataGrid.DataSource = null;
            this.testsDataGrid.DataSource = Program.OntologyInstance.Tests;
        }

        public void handleNewTest(object sender, EventArgs e)
        {
            var test = new cbox.model.Test();
            Program.OntologyInstance.AddTest(test);
        }

        private void TestsWindow_Shown(object sender, EventArgs e)
        {
            this.handleOntologyChange(null);
        }

    }
}
