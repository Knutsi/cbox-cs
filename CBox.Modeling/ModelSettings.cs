using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using model = cbox.model;
using cbox.generation;

namespace cbox.modelling
{
    public partial class ModelSettings : Form
    {
        private Model Model_;

        public ModelSettings()
        {
            InitializeComponent();
        }

        public Model Model {
            get { return Model_; }
            set { Model_ = value; LoadData(); }
        }


        public void LoadData()
        {
            resourceGroupCombobox.Text = Model.ResourceScoreGroup;
        }

        public void SaveData()
        {
            Model.ResourceScoreGroup = resourceGroupCombobox.Text;
        }
    }
}
