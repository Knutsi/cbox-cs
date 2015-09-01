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

namespace ModelEditor.forms
{
    public partial class PathsView : UserControl
    {
        private Model _Model;

        public PathsView()
        {
            InitializeComponent();
            Program.ModelLoaded += Program_ModelLoaded;
            pathList.SelectedIndexChanged += HandlePathSelection;
            pathList.MouseClick += HandlePathSelection;
        }


        public void WireEvents()
        {
            if(Model != null)
                Model.RootComponent.Invalidated += RootComponent_Invalidated;
        }


        public Model Model
        {
            get { return _Model;  }
            set
            {
                _Model = value;
                WireEvents();
                Clear();
            }
        }

        public void Clear()
        {
            pathList.DataSource = null;
            messageLabel.Text = "";
        }

        public void Update()
        {
            Clear();

            // make a list of the paths:
            var comp = this.Model.RootComponent;

            if (comp != null && comp.BuildPaths != null && comp.BuildPaths.Count > 0)
            {
                var paths = (from p in comp.BuildPaths
                            select p).ToList();

                pathList.DataSource = paths;
                pathList.DisplayMember = "Title";

                messageLabel.Text = string.Format("{0} paths", paths.Count());
            }
            else
            {
                messageLabel.Text = string.Format("{0} issues prevents build", comp.Issues.Count);
            }
        }


        void RootComponent_Invalidated()
        {
            Update();
        }


        void Program_ModelLoaded()
        {
            this.Model = Program.CurrentModel;
        }


        private void HandlePathSelection(object sender, EventArgs e)
        {
            // ensure we have an item:
            var path = pathList.SelectedItem as BuildPath;
            if (path == null)
                return;

            tagsBox.Text = String.Join(" ; ", path.Tags);
        }

    }
}
