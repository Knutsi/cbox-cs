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
    public partial class SetValuesNodeEditor : UserControl, IInnerEditor
    {
        private Node _Node;

        public SetValuesNodeEditor()
        {
            InitializeComponent();
        }

        public Node Node
        {
            get { return _Node; }
            set
            {
                _Node = value;
                LoadNode();
            }
        }

        public SetValuesData Data { get  { return (SetValuesData)Node.HandlerData; } }
        public NodeEditor ParentEditor { get; set; }

        private void LoadNode()
        {
            editorsFlow.Controls.Clear();

            // add a small editor for each entry in the data:
            foreach (var entry in Data.Entries)
            {
                var editor = new SetValuesNodeEntryEditor() { Entry = entry };
                editorsFlow.Controls.Add(editor);
            }

            // add one extra for new lines:
            var new_editor = new SetValuesNodeEntryEditor();
            editorsFlow.Controls.Add(new_editor);
        }

        private void SaveNode() 
        {

        }

        public void OnOuterEditorClosing()
        {
            throw new NotImplementedException();
        }


        public model.Ontology Ontology
        {
            get;
            set;
        }
    }
}
