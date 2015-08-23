using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace BatchExporter
{
    public partial class MainWindow : Form
    {
 
        public MainWindow()
        {
            InitializeComponent();

            // restore values:
            systemRootInput.Text = Properties.Settings.Default.systemPath;
            serviceRootInput.Text = Properties.Settings.Default.servicePath;
            caseCountPicker.Value = Properties.Settings.Default.caseCount;
            backupCheckbox.Checked = Properties.Settings.Default.backupOldCases;
            backupCheckbox.Checked = Properties.Settings.Default.rethrowExcepions;
        }

        private void pickSystemRootButton_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var path = dialog.SelectedPath;
                systemRootInput.Text = path;
                Properties.Settings.Default.systemPath = path;
                Properties.Settings.Default.Save();
            }
        }

        private void pickServiceRootButton_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var path = dialog.SelectedPath;
                serviceRootInput.Text = path;
                Properties.Settings.Default.servicePath = path;
                Properties.Settings.Default.Save();
            }
        }

        private void caseCountPicker_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.caseCount = Convert.ToInt32(caseCountPicker.Value);
            Properties.Settings.Default.Save();
        }

        private void backupCheckbox_CheckStateChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.backupOldCases = backupCheckbox.Checked;
            Properties.Settings.Default.Save();
        }


        private void rethrowExceptionCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.rethrowExcepions = rethrowExceptionCheckbox.Checked;
            Properties.Settings.Default.Save();
        }

        private void buildButton_Click(object sender, EventArgs e)
        {
            var exporter = new BatchExporter(
                systemRootInput.Text,
                serviceRootInput.Text,
                Convert.ToInt32(caseCountPicker.Value),
                rethrowExceptionCheckbox.Checked
                );

            exporter.RunExport();
            logOutput.Text = string.Format("Log output @ {0}{1}{2}", 
                DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString(),
                Environment.NewLine);
            foreach (var line in exporter.MessageLog)
            {
                logOutput.Text += line + Environment.NewLine;
            }
        }

    }
}
