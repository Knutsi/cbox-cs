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
using cbox.generation.nodetype;

namespace cbox.modelling.editors
{
    /// <summary>
    /// Editor to allow submodels to be included. 
    /// </summary>
    public partial class IncludeNodeEditor : UserControl, IInnerEditor
    {
        private Node _Node;
        public IncludeData Data { get; set; }


        public IncludeNodeEditor()
        {
            InitializeComponent();

            addButton.Enabled = false;

            SetupEvents();
        }

        public void SetupEvents()
        {
            // enable and disable add button depending on item being slected enough:
            possibleIncludesList.SelectedIndexChanged += (object s, EventArgs e) =>
            {
                if (possibleIncludesList.SelectedItem != null)
                    addButton.Enabled = true;
                else
                    addButton.Enabled = false;
            };

            // add/remove selected include when double clicked (by simulating click):
            possibleIncludesList.DoubleClick += (object s, EventArgs e) => { addButton.PerformClick(); };
            selectedList.DoubleClick += (object s, EventArgs e) => { removeButton.PerformClick(); };

            // add button: add selected include:
            addButton.Click += (object s, EventArgs e) =>
            {
                if (possibleIncludesList.SelectedItem == null)
                    return;

                var ident = ((dynamic)possibleIncludesList.SelectedItem).Ident;
                var local = ((dynamic)possibleIncludesList.SelectedItem).Local;

                Data.Includes.Add(new IncludeDataEntry { Ident = ident, Local = local });

                Load();
                Console.WriteLine("-");
            };

            // remove button: remove selected include:
            removeButton.Click += (object s, EventArgs e) =>
            {
                if (selectedList.SelectedItem == null)
                    return;

                var selected = (dynamic)selectedList.SelectedItem;
                Data.Includes.Remove(selected.SourceInclude);

                Load();
            };
        }


        public generation.Node Node
        {
            get { return _Node; }
            set 
            {
                _Node = value;
                Data = Node.HandlerData as IncludeData;
                Load();
            }
        }


        public model.Ontology Ontology
        {
            get;
            set;
        }


        public NodeEditor ParentEditor
        {
            get;
            set;
        }

        public List<NodeCollection> AvailableLocalComponents
        {
            get
            {
                // available components are all components that are not root, and that is not the one we are in:
                var list = (from nc in Node.ParentComponent.ParentModel.Components
                            where 
                                !nc.IsRoot 
                                && nc != Node.ParentComponent 
                                && Data.EntryByIdentAndLocalStatus(nc.Ident, true) == null
                            select nc).ToList();

                return list;
            }
        }

        public void Load() 
        {
            // load list of possible includes, filtered by search box:
            var includes = (from i in AvailableLocalComponents
                                 select new { Label = "* " + i.Ident, Ident = i.Ident, Local = true }).ToList();


            // load the remainder of possible includes from the cbox-system:
            var system_includes = (from c in ParentEditor.CBoxSystem.Components
                                   where Data.EntryByIdentAndLocalStatus(c.Ident, false) == null
                                  select new { Label = c.Title, Ident = c.Title, Local = false }).ToList();

            includes.AddRange(system_includes);

            // add system and local includes as dawta source:
            possibleIncludesList.DataSource = includes;
            possibleIncludesList.DisplayMember = "Label";

            // populate list of selected items:
            var selected = (from i in Data.Includes
                            where i.Local == true
                            select new { Label = "* " + i.Ident, Ident = i.Ident, Local = true, SourceInclude = i }).ToList();

            var remote_selected = (from i in Data.Includes
                                  where i.Local == false
                                  select new { Label = i.Ident, Ident = i.Ident, Local = true, SourceInclude = i }).ToList();

            selected.AddRange(remote_selected);

            selectedList.DataSource = selected;
            selectedList.DisplayMember = "Label";

            // add exclude tags:
            excludeTagInput.Text = string.Join("; ", Data.ExcludeTags);
        }


        public void Save()
        {
            // save tags:
            Data.ExcludeTags = (from t in excludeTagInput.Text.Split(';')
                                where t.Trim() != string.Empty
                                select t.Trim()).ToList();

        }


        public void OnOuterEditorClosing()
        {
            Save();
        }
    }
}
