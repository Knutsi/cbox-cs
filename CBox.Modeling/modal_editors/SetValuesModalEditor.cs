using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cbox.generation;
using cbox.generation.nodetype;
using cbox.modelling.setter_editors;
using model = cbox.model;



namespace cbox.modelling.editors
{
    /// <summary>
    /// New and improved editor for dealing with SetValue nodes.  Enables better workflow for adding,
    /// deleting and editing nodes.
    /// </summary>
    public partial class SetValuesModalEditor : Form, IWindowedNodeEditor
    {
        bool EventsDisabled = false;

        ListViewItem CurrentItem;
        SetValuesDataEntry CurrentEntry;
        ISetterEditor CurrentSetterEditor;


        Node Node_;
        model.Ontology Ontology_;

        public SetValuesModalEditor()
        {
            InitializeComponent();

            entryList.ItemSelectionChanged += HandleItemsSelected;
            testPicker.TestPicked += HandleTestPicked;
            addYieldButton.Click += HandleAddYield;
            Shown += HandleFirstDisplay;
        }

        private void HandleFirstDisplay(object sender, EventArgs e)
        {
            if(entryList.Items.Count > 0)
                entryList.Items[0].Selected = true;

            entryList.Focus();
        }

        public Node Node
        {
            get { return Node_; }

            set
            {
                Node_ = value;
                LoadNode();
            }
        }


        public SetValuesData Data
        {
            get { return Node.HandlerData as SetValuesData; }
        }


        public model.Ontology Ontology
        {
            get {
                return 
                    Ontology_; }
            set {
                Ontology_ = value;
                testPicker.Ontology = value;
            }
        }


        public void UpdateEntryListView(bool pick_first = false)
        {
            var entries_in_list = new List<SetValuesDataEntry>();
            foreach (ListViewItem item in entryList.Items)
                entries_in_list.Add(item.Tag as SetValuesDataEntry);

            // add items that are not in the list:
            foreach (var entry in Data.Entries)
            {
                if (!entries_in_list.Contains(entry))
                    entryList.Items.Add( CreateEntryListItem(entry) );
            }

            // remove items that are not in entries, but are in the list view:
            var to_remove = new List<ListViewItem>();
            foreach (ListViewItem item in entryList.Items)
                if (!Data.Entries.Contains(item.Tag))
                    to_remove.Add(item);

            foreach (var item in to_remove)
                entryList.Items.Remove(item);
        }

        public ListViewItem CreateEntryListItem(SetValuesDataEntry entry)
        {
            // create item:
            var item = new ListViewItem(entry.Key) { Tag = entry };

            // look up additional data in ontology:
            var test = Ontology.TestByKey(entry.Key);
            
            // does test exist in in ontology?  If yes, augment with title, if not, mark it:
            if (test == null)
            {
                // does not exist in ontology:
                item.Font = new Font(DefaultFont, FontStyle.Strikeout);
                item.ForeColor = Color.Red;
            }
            else
            {
                item.SubItems.Add(test.Title);
            }

            // is the test actually available on the class of our node?  If not, mark it:
            var classes = new List<string>();
            classes.Add("General");
            if (Node.BoundProblemSet != null)
                classes = Node.BoundProblemSet.Classes;

            if (test != null && !Ontology.TestsByClasses(classes).Contains(test.Key))
                item.ForeColor = Color.Orange;


            return item;
        }

        private void PopulateActionPicker()
        {
            var actions = new List<model.Action>();
            if (Node.BoundProblemSet != null)
                foreach (var class_ in Node.BoundProblemSet.Classes)
                    actions.AddRange(Ontology.ActionsByClass(class_));
            else
                actions.AddRange(Ontology.ActionsByClass("General"));

            actionCombobox.DataSource = actions;
            actionCombobox.DisplayMember = "TitleWithClassnames";
        }

        /// <summary>
        /// Called when the node is set to load the data.
        /// </summary>
        private void LoadNode()
        {
            EventsDisabled = true;

            // notify test picker about what classes we are operating on:
            if (Node.BoundProblemSet != null)
            {
                testPicker.LimitToClasses = Node.BoundProblemSet.Classes;
                classLabel.Text = "Classes:" + string.Join(", ", Node.BoundProblemSet.Classes);
            }
            

            // fill the list of entries:
            UpdateEntryListView();
            PopulateActionPicker();

            EventsDisabled = false;
        }

 
        private void SaveNode()
        {
            // for future use only

        }


        private void HandleItemsSelected(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            CloseEntryEditor();
            removeButton.Enabled = true;

            // no selected?
            if (entryList.SelectedItems.Count <= 0)
            {
                removeButton.Enabled = false;
                return;
            }

            // for multiple selections, we just close the editor:
            if (entryList.SelectedItems.Count > 1)
            {
                CloseEntryEditor();
                return;
            }

            // for single selections, we load the entry:
            var entry = entryList.SelectedItems[0].Tag as SetValuesDataEntry;
            LoadEntry(entry);
        }


        /// <summary>
        /// Clears the entry editor.
        /// </summary>
        private void CloseEntryEditor()
        {
            SaveEntry();
            CurrentSetterEditor = null;
            CurrentEntry = null;
            setterEditorPanel.Controls.Clear();
        }


        /// <summary>
        /// Loads the setter editor for the selected entry.
        /// </summary>
        /// <param name="entry"></param>
        private void LoadEntry(SetValuesDataEntry entry)
        {
            CurrentEntry = entry;

            var editor = SetterEditorLibrary.GetEditor(entry.SetterIdent);
            if (editor != null)
            {
                editor.SetterXmlData = entry.SetterXmlData;
                setterEditorPanel.Controls.Add(editor as Control);
                (editor as Control).Dock = DockStyle.Fill;
            }

            CurrentSetterEditor = editor;

            keyLabel.Text = entry.Key;
            switch (entry.ConflictPolicy)
            {
                case TestResultConflictPolicy.CLEAR_OLD:
                    policySelect.SelectedIndex = 1;
                    break;

                case TestResultConflictPolicy.DEFAULT:
                    policySelect.SelectedIndex = 0;
                    break;

                default:
                    policySelect.SelectedIndex = 0;
                    break;
            }
        }

        /// <summary>
        /// Saves data from current setter editor to current entry.
        /// </summary>
        private void SaveEntry()
        {
            // save editor:
            if (CurrentSetterEditor != null)
            {
                CurrentSetterEditor.SaveData();
                CurrentEntry.SetterXmlData = CurrentSetterEditor.SetterXmlData;

                // save policy:
                switch (policySelect.SelectedIndex)
                {
                    case 0:
                        CurrentEntry.ConflictPolicy = TestResultConflictPolicy.DEFAULT;
                        break;

                    case 1:
                        CurrentEntry.ConflictPolicy = TestResultConflictPolicy.CLEAR_OLD;
                        break;

                    default:
                        CurrentEntry.ConflictPolicy = TestResultConflictPolicy.DEFAULT;
                        break;
                }
            }

            
        }

        public void NewEntry(string key, bool load_editor=true)
        {
            // check that item does nto already exist as an entry:
            var found = from e in Data.Entries where e.Key == key select e;
            if (found.Count() > 0)
                return;

            // save and close current:
            SaveEntry();
            CloseEntryEditor();

            // create new entry:
            var test = Ontology.TestByKey(key);
            var entry = new SetValuesDataEntry()
            {
                Key = test.Key,
                SetterIdent = test.SetterIdent,
                SetterXmlData = string.Empty
            };

            // copy default setter data if requested:
            if (useDefaultDataCheckbox.Checked && entry.SetterIdent != "MRANGE" && entry.SetterIdent != "MSTRING")
                entry.SetterXmlData = test.SetterXMLData;

            Data.Entries.Add(entry);

            // change setter if MRANGE, which only works on import:
            if (entry.SetterIdent == "MRANGE")
                entry.SetterIdent = "RANGE";

            if (entry.SetterIdent == "MSTRING")
                entry.SetterIdent = "STRING";

            // save to node, update list and load into editor:
            SaveEntry();
            UpdateEntryListView();

            if(load_editor)
                LoadEntry(entry);
        }



        private void HandleTestPicked(object sender, EventArgs e)
        {
            NewEntry(testPicker.SelectedTest.Key);
        }

        private void SetValuesModalEditor_Load(object sender, EventArgs e)
        {

        }

        private void HandleAddYield(object sender, EventArgs e)
        {
            var action = actionCombobox.SelectedItem as model.Action;
            if (action == null)
                return;

            // add all keys from this action:
            foreach (var key in action.Yield)
                NewEntry(key, false);
        }

        /// <summary>
        /// Removes all marked items.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in entryList.Items)
            {
                if(item.Checked)
                {
                    if (item == CurrentItem)
                        CloseEntryEditor();

                    var entry = item.Tag as SetValuesDataEntry;
                    Data.Entries.Remove(entry);
                }
            }

            UpdateEntryListView();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            SaveEntry();
            SaveNode();
            Close();
        }


        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            /*if (entryList.SelectedItems.Count <= 0)
                return;
            
            var items = new List<SetValuesDataEntry>();
            foreach (ListViewItem item in entryList.SelectedItems)
            {
                var entry = (item.Tag as SetValuesDataEntry).Clone();
                items.Add(entry);
            }

            Clipboard.SetData(DataFor, false);
            Clipboard.sa*/
        }


        private void pasteMenuItem_Click(object sender, EventArgs ev)
        {
            /*IDataObject data = Clipboard.GetDataObject();

            object clipboard_data = data.GetData(DataFormats.Serializable, false);
            var pasted_entries = clipboard_data as List<SetValuesDataEntry>;
            var existing_keys = from e in Data.Entries select e.Key;
            var non_duplicate_entries = from e in pasted_entries where !existing_keys.Contains(e.Key) select e;

            foreach (var entry in non_duplicate_entries)
            {
                
                Data.Entries.Add(entry);
                UpdateEntryListView();
            }*/
        }
    }
}
