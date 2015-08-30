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
    public partial class TestPicker : UserControl
    {
        public Ontology Ontology { get; set; }
        public event EventHandler TestPicked;
        public Test SelectedTest { get; set; }

        public TestPicker()
        {
            InitializeComponent();

            searchInput.TextChanged += HandleSearchTextUpdate;
            searchResults.SelectedIndexChanged += HandleSelection;
        }


        /// <summary>
        /// Searches the ontology's diagnosis catalog.
        /// </summary>
        public void SearchTests()
        {
            if (this.Ontology == null)
                return;

            var query = searchInput.Text;
            if (query.Length < 3)
                return;

            searchResults.Items.Clear();

            var items = from t in this.Ontology.SearchTests(query)
                        select new ListViewItem(t.Title + " [" + t.Key + "]") { Tag = t };

            searchResults.Items.AddRange(items.ToArray());
        }

        /// <summary>
        /// Event handler for search input change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleSearchTextUpdate(object sender, EventArgs e) { SearchTests(); }


        /// <summary>
        /// Event handler for selection made in picker list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleSelection(object sender, EventArgs e)
        {
            if (searchResults.SelectedItems.Count > 0)
            {
                SelectedTest = searchResults.SelectedItems[0].Tag as Test;

                if (TestPicked != null)
                    TestPicked(this, new EventArgs());
            }
        }
    }
}
