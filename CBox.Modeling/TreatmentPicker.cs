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
    public partial class TreatmentPicker : UserControl
    {
        public Ontology Ontology { get; set; }
        public event EventHandler TreatmentPicked;
        public TreatmentCatalogEntry SelectedRx { get; set; }

        public TreatmentPicker()
        {
            InitializeComponent();

            searchInput.TextChanged += HandleSearchTextUpdate;
            searchResults.SelectedIndexChanged += HandleSelection;
        }


        /// <summary>
        /// Searches the ontology's treatment catalog.
        /// </summary>
        public void SearchRx()
        {
            if (this.Ontology == null)
                return;

            var query = searchInput.Text;
            if (query.Length < 3)
                return;

            searchResults.Items.Clear();

            var items = from rx in this.Ontology.Treatments.Search(query)
                        select new ListViewItem(rx.Title + " (" + string.Join(",", rx.Modifiers) + ")") { Tag = rx };

            searchResults.Items.AddRange(items.ToArray());
        }

        /// <summary>
        /// Event handler for search input change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleSearchTextUpdate(object sender, EventArgs e) { SearchRx(); }


        /// <summary>
        /// Event handler for selection made in picker list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleSelection(object sender, EventArgs e)
        {
            if (searchResults.SelectedItems.Count > 0)
            {
                SelectedRx = searchResults.SelectedItems[0].Tag as TreatmentCatalogEntry;

                if (TreatmentPicked != null)
                    TreatmentPicked(this, new EventArgs());
            }
        }
    }
}
