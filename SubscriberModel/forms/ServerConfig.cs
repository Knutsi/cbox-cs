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
    public partial class ServerConfig : Form
    {
        public ServerConfig()
        {
            InitializeComponent();

            // if we have an autoload path, we use that now:
            if(Program.ServerRootAutoload != null && Program.ServerRootAutoload != String.Empty)
            {
                autoLoadCheckbox.Checked = true;
                serverRootInput.Text = Program.ServerRootAutoload;
            }
        }



        private void applyButton_Click(object sender, EventArgs e)
        {
            var root_path = serverRootInput.Text;
            Program.TestServerInstance.RootDirectory = root_path;

            // if we shoudl always load this value, we add it now
            // if not, we dont have a default, and erase the old one:
            if(autoLoadCheckbox.Checked)
            {
                Program.ServerRootAutoload = root_path;
            }
            else
            {
                Program.ServerRootAutoload = null;  // no automatic load..
                Program.TestServerInstance.RootDirectory = root_path;   // ..but use it now 
            }
                
        }

        private void serverInfoText_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void pickServerRoot(object sender, EventArgs e)
        {

            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                serverRootInput.Text = dialog.SelectedPath;
            }
        }
    }
}
