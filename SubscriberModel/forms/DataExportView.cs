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

namespace OntologyEditor
{
    public partial class DataExportView : Form
    {
        private string _ExportData;
        public string Comment { get; set; }
        public string ExportData { get; set; }

        public DataExportView(string data, string comment)
        {
            InitializeComponent();
            Comment = comment;
            ExportData = data;

            commentLabel.DataBindings.Add("Text", this, "Comment");
            dataView.DataBindings.Add("Text", this, "ExportData");
        }

        private void pickFileButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                fileLocationInput.Text = dialog.FileName;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            File.WriteAllText(fileLocationInput.Text, ExportData);
            this.Close();
        }


    }
}
