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
        private BindingSource testsBindingSource;

        public TestsWindow()
        {
            InitializeComponent();
        }

        private void TestsWindow_Load(object sender, EventArgs e)
        {
            // ensure we refresh when ontology changes:
            Program.OntologyInstance.OnChange += handleOntologyChange;

            // by binding with a binding source, it becomes possible to easily 
            // filter the list:
            this.testsDataGrid.AutoGenerateColumns = true;
            this.testsBindingSource = new BindingSource();
            this.testsBindingSource.DataSource = Program.OntologyInstance.Tests;
            this.testsDataGrid.DataSource = testsBindingSource;

        }


        private void TestsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.OntologyInstance.OnChange -= handleOntologyChange;
        }


        void handleOntologyChange(object sender)
        {
            /*this.testsDataGrid.DataSource = null;
            this.testsDataGrid.DataSource = Program.OntologyInstance.Tests;*/
        }

        public void handleNewTest(object sender, EventArgs e)
        {
            var test = new cbox.model.Test();
            Program.OntologyInstance.AddTest(test);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            // remove selected rows, one by one:
            foreach (DataGridViewRow row in this.testsDataGrid.SelectedRows)
            {
                var test = (cbox.model.Test)row.DataBoundItem;
                Program.OntologyInstance.RemoveTest(test);
            }
        }


        private void TestsWindow_Shown(object sender, EventArgs e)
        {
            this.handleOntologyChange(null);
        }


        private void testsDataGrid_Click(object sender, EventArgs e)
        {
            
        }

        private void testsDataGrid_DoubleClick(object sender, EventArgs e)
        {
            // get test from the column:
            var test = (cbox.model.Test)testsDataGrid.SelectedRows[0].DataBoundItem;

            var editor = new TestEditor(test);
            if(Program.UseMDI)
                editor.MdiParent = Program.MainWindowInstance;
            editor.Show();
        }



    }
}
