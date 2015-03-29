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

namespace cbox.modelling
{
    public partial class CollectionPropertiesEditor : UserControl
    {
        public CollectionPropertiesEditor()
        {
            InitializeComponent();

            identInput.TextChanged += identInput_TextChanged;
        }


        public NodeCollection NodeCollection
        {
            get
            {
                return _NodeCollection;

            }

            set
            {
                _NodeCollection = value;
                Load();
            }
        }

        private void Load()
        {
            identInput.Text = NodeCollection.Ident;
            identInput.Enabled = !NodeCollection.IsRoot; // disable if root;
        }

        private void Save()
        {
            NodeCollection.Ident = identInput.Text;
        }


        void identInput_TextChanged(object sender, EventArgs e)
        {
            Save();
        }

        private NodeCollection _NodeCollection;
    }
}
