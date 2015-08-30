using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cbox.model;

namespace cbox.modelling
{
    public partial class DiagnosisPicker : UserControl
    {
        public Ontology Ontology { get; set; }
        public event EventHandler DiagnosisPicked;
        public DiagnosisCatalogEntry SelectedDx { get; set; }

        public DiagnosisPicker()
        {
            InitializeComponent();

            dxSearchInput.TextChanged += HandleSearchTextUpdate;
            dxSearchResults.SelectedIndexChanged += HandleSelection;
        }

        
        /// <summary>
        /// Searches the ontology's diagnosis catalog.
        /// </summary>
        public void SearchDx()
        {
            if (this.Ontology == null)
                return;

            var query = dxSearchInput.Text;
            if (query.Length < 3)
                return;

            dxSearchResults.Items.Clear();

            var items = from d in this.Ontology.Diagnosis.Search(query)
                        select new ListViewItem(d.Code + " " + d.Name) { Tag = d };

            dxSearchResults.Items.AddRange(items.ToArray());
        }

        /// <summary>
        /// Event handler for search input change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleSearchTextUpdate(object sender, EventArgs e) { SearchDx(); }


        /// <summary>
        /// Event handler for selection made in picker list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleSelection(object sender, EventArgs e)
        {
            if (dxSearchResults.SelectedItems.Count > 0)
            {
                SelectedDx = dxSearchResults.SelectedItems[0].Tag as DiagnosisCatalogEntry;

                if (DiagnosisPicked != null)
                    DiagnosisPicked(this, new EventArgs());
            }
        }


    }
}
