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
    public enum ImportMode
    {
        UNKNOWN, UNSET, TESTS, ACTIONS
    }

    public partial class TestSpreadsheetImportTool : Form
    {
        DoubleBufferedDataGridView DataGrid;
        DataTable CurrentTable;

        public TestSpreadsheetImportTool()
        {
            InitializeComponent();
            DataGrid = new DoubleBufferedDataGridView();
            DataGrid.Dock = DockStyle.Fill;
            gridPanel.Controls.Add(DataGrid);

        }

        private void LoadClipboardData()
        {
            Clear();
           
            // copy clipboard-data into a new 
            char[] rowsplitter = { '\n', '\r' }; 
            char[] colsplitter = { '\t' }; 

            var data = Clipboard.GetDataObject();
            var data_str = data.GetData(DataFormats.Text).ToString();

            var rows = (from r in data_str.Split(rowsplitter, StringSplitOptions.RemoveEmptyEntries)
                       where r.Trim(new char[] { ' ', '\t' }) != string.Empty
                       select r).ToList();

            var table = new DataTable("Import data");

            // add columns from first row:
            var columns = rows[0].Split(colsplitter);
            foreach (var col in columns)  
                table.Columns.Add(col, typeof(string));
          
            // add rows:
            for (int i = 1; i < rows.Count; i++)
            {
                var values = rows[i].Split(colsplitter);
                table.Rows.Add(values);
            }

            DataGrid.DataSource = table;
            this.CurrentTable = table;

            // enable import button:
            if (ImportMode == OntologyEditor.ImportMode.TESTS || ImportMode == OntologyEditor.ImportMode.ACTIONS)
                writeButton.Enabled = true;
            else
                writeButton.Enabled = false;
        }

        /// <summary>
        /// Clears data from the datagrid.
        /// </summary>
        private void Clear()
        {
            DataGrid.DataSource = null;
        }



        private void Import()
        {
            switch (this.ImportMode)
            {
                case ImportMode.TESTS:
                    var importer = new TabularDataTestImporter(Program.OntologyInstance);
                    importer.Import(CurrentTable);
                    importLog.Text = string.Join("\r\n", importer.ImportLog);
                    break;
                case ImportMode.ACTIONS:
                    break;
                default:
                    break;
            }
        }

        public ImportMode ImportMode 
        { 
            get
            {
                // no table?  No import..
                if (CurrentTable == null)
                    return OntologyEditor.ImportMode.UNSET;
             
                // get all headers:
                var headers = new List<string>();
                foreach (DataColumn col in CurrentTable.Columns)
                    headers.Add(col.ColumnName);

                if (headers.Contains("Key"))
                    return OntologyEditor.ImportMode.TESTS;
                else
                    return OntologyEditor.ImportMode.UNKNOWN;

            }
        }


        private void pasteButton_Click(object sender, EventArgs e)
        {
            LoadClipboardData();
        }

        private void writeButton_Click(object sender, EventArgs e)
        {
            Import();
        }
    }
}
