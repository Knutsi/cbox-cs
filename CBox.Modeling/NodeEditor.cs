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
using cbox.generation;
using cbox.generation.nodetype;
using cbox.system;

namespace cbox.modelling.editors
{
    public delegate void NodeSavedEvent(Node node);

    public partial class NodeEditor : UserControl
    {
        public event NodeSavedEvent NodeSaved;
        public Ontology Ontology { get; set; }
        public CBoxSystem CBoxSystem { get; set; }
        private IInnerEditor InnerEditor;

        private int? SplitPanelOriginalHeight = null;

        private bool EventsDisabled = false;

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
            if(!EventsDisabled)
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

                case SetValue.TYPE_IDENT:
                    inner_editor = new SetValuesNodeEditor();
                    break;

                case ProblemStart.TYPE_IDENT:
                    inner_editor = new ProblemStartNodeEditor();
                    break;

                case Include.TYPE_IDENT:
                    inner_editor = new IncludeNodeEditor();
                    break;

                default:
                    InnerEditor = null;
                    return;
            }

            inner_editor.Dock = DockStyle.Fill;
            innerEditorPanel.Controls.Add(inner_editor);
            
            // load the node:
            ((IInnerEditor)inner_editor).ParentEditor = this;
            ((IInnerEditor)inner_editor).Ontology = this.Ontology;
            ((IInnerEditor)inner_editor).Node = Node;

            // save for later:
            InnerEditor = inner_editor as IInnerEditor;
        }


        public void SaveNode()
        {
            if (this.Node == null)
                return;

            Node.Title = titleInput.Text;
            Node.Tags = (from t in tagInput.Text.Split(';')
                         where t.Trim() != String.Empty
                         select t.Trim()).ToList();

            // split and read tags:
            if (NodeSaved != null) 
                NodeSaved(this.Node);

            // notify inner editor we are closing:
            if(InnerEditor != null)
                InnerEditor.OnOuterEditorClosing();

            // fire event on node:
            this.Node.FireChangedEvent();
        }


        public void LoadNode()
        {
            EventsDisabled = true;

            // load fields:
            titleInput.Text = Node.Title;
            commentInput.Text = Node.Comment;
            typeLabel.Text = Node.Type;
            tagInput.Text = String.Join("; ", Node.Tags);
            
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
            /*tagInput.Text = string.Empty;
            foreach (var tag in Node.Tags)
                tagInput.Text += tag + ", ";

            if (tagInput.Text.Length > 2 || tagInput.Text == ", ")
                tagInput.Text = tagInput.Text.Substring(0, tagInput.Text.Length - 2);*/

            EventsDisabled = false;

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (!SplitPanelOriginalHeight.HasValue)
            {
                SplitPanelOriginalHeight = splitContainer.SplitterDistance;
                splitContainer.SplitterDistance = panel1.Height;
            }
            else
            {
                splitContainer.SplitterDistance = SplitPanelOriginalHeight.Value;
                SplitPanelOriginalHeight = null;
            }

            
        }
    }
}
