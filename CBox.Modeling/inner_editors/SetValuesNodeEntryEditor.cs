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
using cbox.generation.setter;
using cbox.modelling.setter_editors;
using cbox.generation;
using cbox.model;

namespace cbox.modelling
{
    public delegate void DeleteEntryEvent();

    public partial class SetValuesNodeEntryEditor : UserControl
    {
        public event DeleteEntryEvent Deleted;

        private bool EventsEnabled = true;

        private SetValuesDataEntry _Entry;
        private ISetterEditor SetterEditor = null;
        public Ontology Ontology { get; set; }


        public SetValuesNodeEntryEditor()
        {
            InitializeComponent();

            deleteButton.Click += HandleDeleteButtonClick;
            keySelect.TextChanged += (object s, EventArgs a) => 
            { 
                if(EventsEnabled) 
                    ChangeKey(); 
            };    

            setterSelect.TextChanged += (object s, EventArgs e) => 
            { 
                if (EventsEnabled) 
                    ChangeSetter(); 
            };
        }


        public SetValuesDataEntry Entry
        {
            get { return _Entry; }
            set { _Entry = value; LoadEntry(); }
        }


        public Node Node
        {
            get;
            set;
        }

        /// <summary>
        /// What keys we can add depends on wether the node we are editing is bound or not.  
        /// We will load the keys from the onology based on what classes are available.
        /// </summary>
        private void PopulateKeys()
        {
            //EventsEnabled = false;

            if (Ontology == null)
                return;

            if(Node != null && Node.BoundProblemSet != null)
            {
                // node is bound, we need to limit:
                var tests = this.Ontology.TestsByClasses(Node.BoundProblemSet.Classes);
                keySelect.DataSource = tests;
            }
            else
            {
                // node is unbound, get keys from "General" class:
                var tests = this.Ontology.TestsByClass("General");
                keySelect.DataSource = tests;
            }

            //EventsEnabled = true;
        }


        /// <summary>
        /// Takes current key's datatype, gets setters for that datatype and populates
        /// the setters combobox.
        /// </summary>
        private void PopulateSetters()
        {
            if (Entry.Key == null)
                throw new Exception("PopualteSetters() called w/o Entry key set");

            var test = Ontology.TestByKey(Entry.Key);
            if (test == null)
                throw new Exception("PopulateSetters() called on key that does not exist in ontology.  Call validate first.");

            // fill in the setters for this datatype:
            var setters = SetterLibrary.Default.SetterByDatatype(test.Datatype);
            var setter_titles = (from s in setters select s.Ident_).ToList();
            setterSelect.DataSource = setter_titles;
        }


        public bool HasData { get { return Entry != null; } }

        /// <summary>
        /// Checks if the key of the entry exists in ontology, and, if it does, if the setters
        /// selected is valid for that key's datatype.
        /// </summary>
        /// <returns></returns>
        public bool ValidateEntryToOntology()
        {
            if (Entry == null)
                throw new Exception("ValidateEntry() called on null entry");

            // basic backwards fix for some older models:
            if (Entry.Key == string.Empty)
                Entry.Key = null;
            if (Entry.SetterIdent == string.Empty)
                Entry.SetterIdent = null;

            // check that key and setter are still valid:
            if (Entry.Key != null && Ontology.TestByKey(Entry.Key) == null)
                return false;

            // check that setter for key's datatype still exists:
            if(Entry.SetterIdent != null)
            {
                var test = this.Ontology.TestByKey(Entry.Key);
                var setters_for_test = (from s in SetterLibrary.Default.SetterByDatatype(test.Datatype)
                                        select s.Ident_).ToList();
                
                if (!setters_for_test.Contains(Entry.SetterIdent))
                    return false;
            }

            // if we get here, test exists, setter for test's datatype exists
            return true;
        }

        public void LoadEntry()
        {
            EventsEnabled = false;

            // default u.i. state:
            setterSelect.Enabled = false;
            setterEditorPanel.Controls.Clear();

            // validate entry - clear if not valid:
            var valid = ValidateEntryToOntology();
            if (!valid)
                ClearEntry();

            // the entry can exist is three states, defined by what values are set.
            // depending on these, we need to load different UI elements:
            if (Entry.Key == null)
            {
                // the node is new or cleared - load keys only
                PopulateKeys();

                datatypeLabel.Text = string.Empty;

                keySelect.Text = "(select)";
                setterSelect.Text = string.Empty;
            } 
            else if(Entry.Key != null && Entry.SetterIdent == null)
            {
                // key set, but setter not picked - load keys + setters for key:
                PopulateKeys();
                PopulateSetters();

                var test = this.Ontology.TestByKey(Entry.Key);
                datatypeLabel.Text = test.Datatype;

                keySelect.Text = Entry.Key;
                setterSelect.Text = string.Empty;
                setterSelect.Enabled = true;

            } 
            else if(Entry.Key != null && Entry.SetterIdent != null)
            {
                // key set, setter picked - load keys, setters, editor for setter:
                PopulateKeys();
                PopulateSetters();

                var test = this.Ontology.TestByKey(Entry.Key);
                datatypeLabel.Text = test.Datatype;

                keySelect.Text = Entry.Key;
                setterSelect.Text = Entry.SetterIdent;
                setterSelect.Enabled = true;

                // LOAD EDITOR!
                this.SetterEditor = SetterEditorLibrary.GetEditor(Entry.SetterIdent);
                if (SetterEditor != null)
                {
                    SetterEditor.SetterXmlData = Entry.SetterXmlData;
                    //((Control)SetterEditor).Dock = DockStyle.Fill;
                    setterEditorPanel.Controls.Add((Control)SetterEditor);
                }

            } 

            EventsEnabled = true;
        }



        /// <summary>
        /// Saves the entry.
        /// </summary>
        public void SaveEntry()
        {
            // save editor:
            if (SetterEditor != null)
            {
                SetterEditor.SaveData();
                Entry.SetterXmlData = SetterEditor.SetterXmlData;
            }

            // null empty values instead of passing empty strings:
            if (Entry.Key == string.Empty)
                Entry.Key = null;

            if (Entry.SetterIdent == string.Empty)
                Entry.SetterIdent = null;

            if (setterSelect.Text == string.Empty)
                Entry.SetterIdent = null;
        }


        public void ClearEntry()
        {
            if (Entry == null)
                throw new Exception("ClearEntry() called on null entry");

            Entry.Key = null;
            Entry.SetterIdent = null;
            Entry.SetterXmlData = null;
        }

        /// <summary>
        /// Called whent he user selects a new key from the key select combobox.  Forces reload.
        /// </summary>
        /// <param name="new_key"></param>
        public void ChangeKey()
        {
            // get the new test value:
            var key = keySelect.Text;

            if (key == string.Empty)
                return;

            // is this a valid key?
            var test = Ontology.TestByKey(key);
            if(test != null)
            {
                // yes. so clear, set key, pick first available setter, and reload entry:
                ClearEntry();
                Entry.Key = key;

                var setters = SetterLibrary.Default.SetterByDatatype(test.Datatype);
                Entry.SetterIdent = setters.First().Ident_;

                LoadEntry();
            } 

            // invalid keys are ignored
        }

        /// <summary>
        /// Called when the user changes the setter in the combobox.
        /// </summary>
        private void ChangeSetter()
        {
            var setter_ident = setterSelect.Text;

            // if no change, we skip:
            if (setter_ident == Entry.SetterIdent)
                return;

            // set new value, and clear setter data:
            Entry.SetterIdent = setter_ident;
            Entry.SetterXmlData = string.Empty;

            // save and reload - this will also change the editor:
            LoadEntry();
        }

        
        void HandleDeleteButtonClick(object sender, EventArgs e)
        {
 	        if(Deleted != null)
                Deleted();
        }

    }
}
