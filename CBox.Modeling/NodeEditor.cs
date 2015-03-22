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
    public delegate void NodeSavedEvent(Node node);

    public partial class NodeEditor : UserControl
    {
        public event NodeSavedEvent NodeSaved;
        

        public NodeEditor()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI() 
        {
            titleInput.TextChanged += HandleInputChanged;
            tagInput.TextChanged += HandleInputChanged;
            commentInput.TextChanged += HandleInputChanged;
        }


        void HandleInputChanged(object sender, EventArgs e)
        {
            SaveNode();
        }

        private Node _Node;
        public Node Node 
        {
            get { return _Node; }
            set 
            { 
                SaveNode(); 
                _Node = value; 
                LoadNode();
                LoadInnerEditor();
            }
        }

        private void LoadInnerEditor()
        {
            // remove existing controls:
            innerEditorPanel.Controls.Clear();

            // add an editor:
            Control inner_editor = null;
            switch (Node.Type)
            {
                case Branch.TYPE_IDENT:
                    inner_editor = new BranchNodeEditor();
                    break;

                default:
                    return;
            }

            inner_editor.Dock = DockStyle.Fill;
            innerEditorPanel.Controls.Add(inner_editor);
            
            // load the node:
            ((IInnerEditor)inner_editor).ParentEditor = this;
            ((IInnerEditor)inner_editor).Node = Node;
        }

        public void SaveNode()
        {
            if (this.Node == null)
                return;

            Node.Title = titleInput.Text;

            // split and read tags:
            if (NodeSaved != null) 
                NodeSaved(this.Node);

            // fire event on node:
            this.Node.FireChangedEvent();
        }

        public void LoadNode()
        {
            // load fields:
            titleInput.Text = Node.Title;
            commentInput.Text = Node.Comment;
            typeLabel.Text = Node.Type;
            
            // notify if bound:
            if (Node.BoundProblemSet != null)
            {
                boundLink.Text = Node.BoundProblemSet.Title;
                boundLink.Enabled = true;
            }
            else
            {
                boundLink.Text = "Unbound";
                boundLink.Enabled = false;
            }

            // load tags:
            tagInput.Text = string.Empty;
            foreach (var tag in Node.Tags)
                tagInput.Text += tag + ", ";

            if (tagInput.Text.Length > 2 || tagInput.Text == ", ")
                tagInput.Text = tagInput.Text.Substring(0, tagInput.Text.Length - 2);

        }
    }
}
