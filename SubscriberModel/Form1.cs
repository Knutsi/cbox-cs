using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Web.Script.Serialization;

using cbox.model;


namespace SubscriberModel
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        CBoxSystem CurrentSystem;

        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sys = new CBoxSystem();
            this.CurrentSystem = sys;
            sys.OnSystemChanged += handle_SystemChanged;

            var ser = new JavaScriptSerializer();
            Console.WriteLine(ser.Serialize(sys));

            sys.TestFire();

            // bind the list:
            this.diagnosisList.DataSource = sys.Diagnosis;


        }

        private void handle_SystemChanged(object sender)
        {
            Console.WriteLine("Event fired!");
            diagnosisList.Refresh();
            
        }

        private void diagnosisList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void diagnosisList_DoubleClick(object sender, EventArgs e)
        {
            var view = (DataGridView)sender;
            var index = view.CurrentCell.RowIndex;
            var editor = new EditDiagnosis(CurrentSystem, CurrentSystem.Diagnosis[index]);
            editor.Show();
        }
    }
}
