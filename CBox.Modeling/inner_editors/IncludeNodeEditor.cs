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
    public partial class IncludeNodeEditor : UserControl, IInnerEditor
    {
        private Node _Node;
        public IncludeData Data { get; set; }


        public IncludeNodeEditor()
        {
            InitializeComponent();

            addButton.Enabled = false;

            // setup events:
            possibleIncludesList.SelectedIndexChanged += (object s, EventArgs e) =>
            {
                if (possibleIncludesList.SelectedItem != null)
                    addButton.Enabled = true;
                else
                    addButton.Enabled = false;
            };

            possibleIncludesList.DoubleClick += (object s, EventArgs e) => { addButton.PerformClick();  };
            selectedList.DoubleClick += (object s, EventArgs e) => { removeButton.PerformClick(); };

            addButton.Click += (object s, EventArgs e) =>
            {
                if (possibleIncludesList.SelectedItem == null)
                    return;

                var ident = ((dynamic)possibleIncludesList.SelectedItem).Ident;
                var local = ((dynamic)possibleIncludesList.SelectedItem).Local;

                Data.Includes.Add(new IncludeDataEntry { Ident = ident, Local = local });

                Load();
            };

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
            var local_includes = (from i in AvailableLocalComponents
                                 select new { Label = "* " + i.Ident, Ident = i.Ident, Local = true }).ToList();

            possibleIncludesList.DataSource = local_includes;
            possibleIncludesList.DisplayMember = "Label";

            // TODO: popualte remainder from system 
            // TODO: filter from search field

            // populate list of selected items:
            var local_selected = (from i in Data.Includes
                                  select new { Label = "* " + i.Ident, Ident = i.Ident, Local = true, SourceInclude = i }).ToList();

            selectedList.DataSource = local_selected;
            selectedList.DisplayMember = "Label";
        }


        public void OnOuterEditorClosing()
        {

        }
    }
}
