using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cbox.generation;
using cbox.model;

using ModelEditor.support;

namespace ModelEditor.forms
{
    public delegate void ExpantionsChangedHandler();

    public enum OutputViewMode
    {
        TEXT, TABLE, JSON, TREE
    }

    public enum OutputLimitMode
    {
        SET,
        SETREC,
        JOURNAL,
        CUSTOM
    }

    public partial class OutputView : UserControl
    {
        private Model _Model;
        private OutputViewMode _ViewMode;
        private OutputLimitMode _LimitMode;
        private Random Random = new Random();
        private Case BaseCase;

        private SavedLimitSetCollection SavedLimitSets; // sets of actions on problems selected

        private bool EventsEnabled = true;  // enables turning off while settings swicthes

        public event ExpantionsChangedHandler ExpantionsChanged;

        public OutputView()
        {
            InitializeComponent();

            // ensure we pick up new models that are loaded:
            Program.ModelLoaded += () =>
            {
                this.Model = Program.CurrentModel; 
            };

            // wire events:
            SetupUIEvents();
            SetupModelEvents();

            // create and empy expantions list:
            Expantions = new List<ActionProblemPair>();

            // restore limit sets:
            LoadLimitSetsMenu();

            // get props:
            var props = Properties.Settings.Default;

            // default mode is either null, or stored in app settings:
            if (props.default_output_view == null)
                ViewMode = OutputViewMode.TEXT;
            else
                ViewMode = (OutputViewMode)props.default_output_view;

            // use default limit mode if not set in preferences:
            if (props.default_output_limit == null)
                LimitMode = OutputLimitMode.SET;
            else
                LimitMode = (OutputLimitMode)props.default_output_limit;
        }


        public void SetupUIEvents()
        {
            // build button:
            buildButton.Click += (object sender, EventArgs e) =>
            {
                this.Build();
            };

            // wire the mode swithcing radio buttons:
            textViewCheck.CheckedChanged += (object s, EventArgs e) =>
            {
                if (textViewCheck.Checked)
                    ViewMode = OutputViewMode.TEXT;
            };

            tableViewCheck.CheckedChanged += (object s, EventArgs e) =>
            {
                if (tableViewCheck.Checked)
                    ViewMode = OutputViewMode.TABLE;
            };

            treeViewCheck.CheckedChanged += (object s, EventArgs e) =>
            {
                if (treeViewCheck.Checked)
                    ViewMode = OutputViewMode.TREE;
            };

            jsonViewCheck.CheckedChanged += (object s, EventArgs e) =>
            {
                if (jsonViewCheck.Checked)
                    ViewMode = OutputViewMode.JSON;
            };

            // wire limit radtio buttons:
            setModeSelect.CheckedChanged += (object s, EventArgs e) => { if(EventsEnabled) LimitMode = OutputLimitMode.SET; };
            setRecModeSelect.CheckedChanged += (object s, EventArgs e) => { if (EventsEnabled) LimitMode = OutputLimitMode.SETREC; };
            journalModeSelect.CheckedChanged += (object s, EventArgs e) => { if (EventsEnabled) LimitMode = OutputLimitMode.JOURNAL; };
            customLimitSelect.CheckedChanged += (object s, EventArgs e) => { if (EventsEnabled) LimitMode = OutputLimitMode.CUSTOM; };

            // action limit list:
            actionListView.ItemChecked += (object sender, ItemCheckedEventArgs e) => {
                if (EventsEnabled)
                    UpdateExpantionList();
            };

            // limit set buttons:
            saveLimitSetButton.Click += (object sender, EventArgs e) => { AddLimitSet(); };
            saveLimitSetButton.Enabled = false;
            deleteLimitSetButton.Click += (object sender, EventArgs e) => { DeleteLimitSet(); };
            customLimitSetSelections.TextChanged += (object sender, EventArgs e) => 
            {
                saveLimitSetButton.Enabled = customLimitSetSelections.Text.Trim() != string.Empty;
            };

            // limit set picker.
            customLimitSetSelections.SelectedIndexChanged += (object sender, EventArgs e) => { LoadLimitSet(customLimitSetSelections.Text); };

            // internal events:
            ExpantionsChanged += () =>
            {
                if(EventsEnabled)
                    Console.WriteLine("Expantions changed");
            };
        }



        /// <summary>
        /// Ensure actions get loaded when the ontology is set.
        /// </summary>
        private void SetupModelEvents()
        {
            // wire worker:
            //Worker.DoWork += Worker_DoWork;
            //Worker.RunWorkerCompleted += PopulateOutputViews;

            Program.OntologyLoaded += (bool reload) =>
            {
                if(LimitMode == OutputLimitMode.CUSTOM)
                    LoadActions(); 
            };
        }

 

        /// <summary>
        /// The model currently being used.
        /// </summary>
        public Model Model 
        {
            get { return _Model; }
            set { _Model = value;  }
        }


        public OutputViewMode ViewMode
        {
            get
            {
                return _ViewMode;
            }

            set
            {
                _ViewMode = value;

                // remmeber for next time:
                Properties.Settings.Default.default_output_view = (int)value;
                Properties.Settings.Default.Save();

                // load the ui needed:
                LoadViewMode();
            }
        }

        private void LoadViewMode()
        {
            outputViewPanel.Controls.Clear();

            switch (ViewMode)
            {
                case OutputViewMode.TEXT:
                    textViewCheck.Checked = true;
                    outputViewPanel.Controls.Add(textView);
                    textView.Dock = DockStyle.Fill;
                    break;

                case OutputViewMode.TABLE:
                    tableViewCheck.Checked = true;
                    outputViewPanel.Controls.Add(dataView);
                    dataView.Dock = DockStyle.Fill;
                    break;

                case OutputViewMode.JSON:
                    jsonViewCheck.Checked = true;
                    outputViewPanel.Controls.Add(jsonView);
                    jsonView.Dock = DockStyle.Fill;
                    break;

                case OutputViewMode.TREE:
                    treeViewCheck.Checked = true;
                    outputViewPanel.Controls.Add(treeView);
                    treeView.Dock = DockStyle.Fill;
                    break;

                default:
                    break;
            }
        }


        public OutputLimitMode LimitMode 
        { 
            get
            {
                return _LimitMode;
            }

            set
            {
                _LimitMode = value;
                Properties.Settings.Default.default_output_limit = (int)value;
                Properties.Settings.Default.Save();
                LoadLimitMode();
            }
        }

        /// <summary>
        /// Updates the controls based on the curren LimitMode so that the GUI responds correctly
        /// when this value is set.
        /// </summary>
        private void LoadLimitMode()
        {
            // since we are editing radio buttons with events:            
            EventsEnabled = false;

            // default disables stuff:
            actionListView.Items.Clear();
            actionListView.Enabled = false;

            switch (LimitMode)
            {
                case OutputLimitMode.SET:
                    setModeSelect.Checked = true;
                    LoadLimitMode_Set();
                    break;

                case OutputLimitMode.SETREC:
                    setRecModeSelect.Checked = true;
                    LoadLimitMode_SetRec();
                    break;

                case OutputLimitMode.JOURNAL:
                    journalModeSelect.Checked = true;
                    LoadLimitMode_Journal();
                    break;

                case OutputLimitMode.CUSTOM:
                    customLimitSelect.Checked = true;
                    LoadLimitMode_Custom();
                    break;

                default:
                    break;
            }

            // we need to repopulate the outputs now that the extended case might have changed:
            if(BaseCase != null)
                PopulateOutputViews();
    
            EventsEnabled = true;
        }
        
        /// <summary>
        /// The most basic mode.  Has only the values set, and no extentions.
        /// </summary>
        private void LoadLimitMode_Set() 
        {
            setModeSelect.Checked = true;
            //ExtendedCase = BaseCase;
        }


        /// <summary>
        /// Extended case is base case  + all reccomended tests looked up in ontology.
        /// </summary>
        private void LoadLimitMode_SetRec()
        {
            setRecModeSelect.Checked = true;
        }

        /// <summary>
        /// Extended case is the standard journal set.
        /// </summary>
        private void LoadLimitMode_Journal()
        {
            journalModeSelect.Checked = true;
        }

        /// <summary>
        /// Extended set is selected by user in the actions list in the control.
        /// </summary>
        private void LoadLimitMode_Custom()
        {
            customLimitSelect.Checked = true;
            actionListView.Enabled = true;
            LoadActions();
        }


        /// <summary>
        /// Loads actions relevant for current case.
        /// </summary>
        private void LoadActions()
        {
            // to run, we need an ontology and a case to base ourselves on:
            if (Program.CurrentOntology == null || BaseCase == null)
                return;

            // clear old items:
            actionListView.Items.Clear();

            // For each problem, add an item to the actionpicker for each action that
            // can be used in the problem's classes:
            foreach (var problem in BaseCase.Problems)
            {
                // keep track of what actions we have added:
                var actions_added = new List<cbox.model.Action>();

                foreach (var class_ in problem.Classes)
                {
                    // get a list of actions that apply to current problem's class,
                    // and that have not alrady been added for this problem:
                    var avail_actions = (from a in Program.CurrentOntology.ActionsByClass(class_)
                                  where !actions_added.Contains(a)
                                  select a).ToList();

                    // add a new item in the list for each of these
                    foreach (var action in avail_actions)
                    {
                        // remember action to avoid duplicates:
                        actions_added.Add(action);

                        // check if this item was selected previously:
                        var checked_ = false;
                        foreach (var existing_exp in Expantions)
                            if (existing_exp.ProblemIdent == problem.Ident && existing_exp.ActionIdent == action.Ident)
                                checked_ = true;
                        
                        // add the item itself:
                        var item = new ListViewItem();
                        item.Checked = checked_;
                        item.Text = action.Title;
                        actionListView.Items.Add(item);

                        // label item by current problem:
                        var problem_item = new ListViewItem.ListViewSubItem();
                        problem_item.Text = problem.Ident;
                        item.SubItems.Add(problem_item);

                        // tag item with the action/problem combo for retrival from list later:
                        item.Tag = new ActionProblemPair()
                        {
                            ProblemIdent = problem.Ident,
                            ActionIdent = action.Ident
                        };
                    }
                }
            }
            // reload expantions list - effectivly clearing it of old actions that might no
            // longer be available:
            UpdateExpantionList();

        }

        /// <summary>
        /// List of the actions the base case will be expanded by to provide the ExpandedCase
        /// property. 
        private List<ActionProblemPair> Expantions
        {
            get;
            set;
        }


        /// <summary>
        /// Reads through selected items in the action list view, and sets a new list of 
        /// expantions based on the checked items.
        /// </summary>
        private void UpdateExpantionList()
        {
            this.Expantions = new List<ActionProblemPair>();

            var checked_items = new List<ListViewItem>();
            foreach (ListViewItem item in actionListView.Items)
                if (item.Checked)
                    checked_items.Add(item);

            // if custom mode, we derive list from selection in actions list:
            foreach (var item in checked_items)
                this.Expantions.Add((ActionProblemPair)item.Tag);

            // fire event:
            if(ExpantionsChanged != null)
                ExpantionsChanged();
        }


        /// <summary>
        /// Loads the limit sets from the app settings, or creates a new empty one.
        /// </summary>
        private void LoadLimitSetsMenu()
        {
            // load set from settings:
            var settings = Properties.Settings.Default;
            if (settings.saved_limit_sets == null || settings.saved_limit_sets == string.Empty)
                SavedLimitSets = new SavedLimitSetCollection();
            else
                SavedLimitSets = SavedLimitSetCollection.FromXML(settings.saved_limit_sets);

            // populate sets menu:
            customLimitSetSelections.Items.Clear();
            foreach (var set in SavedLimitSets.Sets)
                customLimitSetSelections.Items.Add(set.Title);
        }


        private void LoadLimitSet(string title)
        {
            if (title.Trim() == string.Empty)
                return;

            // find set correspnding to title given:
            List<ActionProblemPair> selection = null;
            foreach (var set in SavedLimitSets.Sets)
                if (set.Title == title)
                    selection = set.Selected;

            if (selection == null)
                return;

            // load set:
            this.Expantions = selection;

            EventsEnabled = false;
            LoadActions();
            EventsEnabled = true;

            // fire event:
            if (ExpantionsChanged != null)
                ExpantionsChanged();
        }


        private void AddLimitSet(bool save=true)
        {
            var title = customLimitSetSelections.Text.Trim();

            // we need a name:
            if (title == string.Empty)
                return;

            // if we have a set already with this name, we update it (and ask permissing)
            SavedLimitSet existing_set = null;
            foreach (var set in SavedLimitSets.Sets)
                if (set.Title == title)
                    existing_set = set;
	        
            if(existing_set != null)
            {
                // give a chance to cancel:
                if (MessageBox.Show("Overwrite?", string.Format("Overwriset set '{0}'", title), MessageBoxButtons.OKCancel) == DialogResult.No)
                    return;

                // perform overwrite?
                existing_set.Selected = Expantions;
            }
            else
            {
                // create the set:
                var set = new SavedLimitSet() 
                { 
                    Selected = Expantions, 
                    Title = title
                };
                SavedLimitSets.Sets.Add(set);
            }

            if (save)
            {
                SaveLimitSets();
                LoadLimitSetsMenu();
            }
        }

        private void DeleteLimitSet(bool save=true)
        {
            var candidates = (from s in SavedLimitSets.Sets
                             where s.Title == customLimitSetSelections.Text 
                                && customLimitSetSelections.Text.Trim() != string.Empty
                             select s).ToList();

            foreach (var set in candidates)
                SavedLimitSets.Sets.Remove(set);

            if (save)
            {
                SaveLimitSets();
                LoadLimitSetsMenu();
            }

            // update combobox:
            EventsEnabled = false;
            customLimitSetSelections.Text = string.Empty;
            Expantions = new List<ActionProblemPair>();
            LoadActions();
            EventsEnabled = true;
        }

        private void SaveLimitSets()
        {
            var settings = Properties.Settings.Default;
            settings.saved_limit_sets = SavedLimitSets.ToXML();
            settings.Save();
        }


        /// <summary>
        /// A version of BaseCase expanded using ontology. The specific expantions are taken 
        /// from the Expantions property.
        /// </summary>
        private Case ExtendedCase
        {
            get
            {
                // make a deep copy of the case, and expand it using ontology:
                var case_ = BaseCase.Clone();
                case_.Expand(Expantions, Program.CurrentOntology);

                return case_;
            }
        }



        public void Build()
        {
            if (this.Model == null)
                return;

            // generate a random case:
            BaseCase = Model.RandomCase;
            PopulateOutputViews();

            if (LimitMode == OutputLimitMode.CUSTOM)
            {
                EventsEnabled = false;
                LoadActions();
                EventsEnabled = true;
            }
        }

        public void PopulateTree()
        {

        }

        public void PopulateTable()
        {
            var table = new DataTable();
            table.Columns.Add("Problem");
            table.Columns.Add("Key");
            table.Columns.Add("Value");

            foreach (var problem in ExtendedCase.Problems)
            {
                foreach (var result in problem.TestResults)
                {
                    var row = table.NewRow();
                    row["Problem"] = problem.Ident;
                    row["Key"] = result.Key;
                    row["Value"] = result.ToString(Program.CurrentOntology);

                    table.Rows.Add(row);
                }
            }

            dataView.DataSource = table;
        }

        public void PopulateTextOutput()
        {
            StringBuilder output = new StringBuilder();

            foreach (var problem in ExtendedCase.Problems)
            {
                var values = from t in problem.TestResults
                             select t.ToString(Program.CurrentOntology);

                output.AppendFormat("{0}: {1}\r\n\r\n", problem.Title, string.Join("", values));
            }

            textView.Text = output.ToString();
        }

        public void PopulateJSONOutput()
        {
            jsonView.Text = ExtendedCase.toJSON();
        }


        /// <summary>
        /// Fills all output views.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PopulateOutputViews(object sender=null, RunWorkerCompletedEventArgs e=null)
        {
            if (ExtendedCase != null)
            {
                PopulateJSONOutput();
                PopulateTextOutput();
                PopulateTable();
                PopulateTree();

            } 
            else
            {
                if (Model.RootComponent.Issues.Count > 0)
                    textView.Text = String.Format("{0} issues prevented build", Model.RootComponent.Issues.Count);
                else
                    textView.Text = "Could not build";
            }
        }
    }
}
