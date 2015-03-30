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
using cbox.generation;
using cbox.model;

namespace cbox.modelling
{
    public delegate void DeleteEntryEvent();

    public partial class SetValuesNodeEntryEditor : UserControl
    {
        public event DeleteEntryEvent Delete;

        private SetValuesDataEntry _Data;
        public Node Node { get; set; }
        public Ontology Ontology { get; set; }

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
            PopulateKeys();

            // we have two modes - with or without node
            if(!HasData) 
            {
                keySelect.Text = "New..";
                deleteButton.Visible = false;
            } 
            else {
                keySelect.Text = Entry.Key;
                deleteButton.Visible = true;
            }
        }

        /// <summary>
        /// What keys we can add depends on wether the node we are editing is bound or not.  
        /// We will load the keys from the onology based on what classes are available.
        /// </summary>
        private void PopulateKeys()
        {
            if(Node != null && Node.BoundProblemSet != null)
            {
                // node is bound, we need to limit:


            }
            else
            {
                // node is unbound, get keys from "General" class:
                var tests = this.Ontology.TestsByClass("General");
                keySelect.DataSource = tests;
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
