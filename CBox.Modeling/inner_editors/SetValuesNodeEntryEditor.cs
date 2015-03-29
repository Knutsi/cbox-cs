using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cbox.generation.nodetype;


namespace cbox.modelling
{
    public delegate void DeleteEntryEvent();

    public partial class SetValuesNodeEntryEditor : UserControl
    {
        public event DeleteEntryEvent Delete;

        private SetValuesDataEntry _Data;

        public SetValuesNodeEntryEditor()
        {
            InitializeComponent();

            deleteButton.Click += HandleDeleteButtonClick;

            LoadData();
        }

        public SetValuesDataEntry Entry 
        {
            get 
            { 
                return _Data; 
            }
            
            set 
            {
                _Data = value; 
                LoadData(); 
            }
        }

        public bool HasData { get { return Entry != null; } }

        public void LoadData()
        {
            // we have two modes - with or without node
            if(!HasData) {
                keySelect.Text = "New..";
                quickEditorPanel.Controls.Clear();
                deleteButton.Visible = false;
            } 
            else {
                keySelect.Text = Entry.Key;
                deleteButton.Visible = true;
            }
        }

        public void SaveData()
        {
            
        }

        
        void HandleDeleteButtonClick(object sender, EventArgs e)
        {
 	        if(Delete != null)
                Delete();
        }

    }
}
