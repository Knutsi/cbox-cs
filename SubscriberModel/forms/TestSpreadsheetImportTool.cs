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
    public partial class TestSpreadsheetImportTool : Form
    {
        public TestSpreadsheetImportTool()
        {
            InitializeComponent();
        }

        private void LoadClipboardData()
        {
            Clear();

            // copy clipboard-data into a new 
            char[] rowsplitter = { '\n', '\r' }; 
            char[] colsplitter = { '\t' }; 

            var data = Clipboard.GetDataObject();
            var data_str = data.GetData(DataFormats.Text).ToString();

            var rows = data_str.Split(rowsplitter, StringSplitOptions.RemoveEmptyEntries).ToList();

            // add rows:
            dataGrid.Rows.Add(rows.Count - 1);

            // add values:
            for (int r = 0; r < rows.Count; r++)
            {
                var values = rows[r].Split(colsplitter);
                for (int c = 0; c < values.Length; c++)
                {
                    dataGrid.Rows[r].Cells[c].Value = values[c];
                }
            }
        }


        private void Clear()
        {
            dataGrid.Rows.Clear();
        }

        private void TestSpreadsheetImportTool_Load(object sender, EventArgs e)
        {
            
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            LoadClipboardData();
        }
    }
}
