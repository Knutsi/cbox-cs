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
        private List<SetValuesNodeEntryEditor> EntryEditors = new List<SetValuesNodeEntryEditor>();

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
            /*editorsFlow.Controls.Clear();

            // add a small editor for each entry in the data:
            foreach (var entry in Data.Entries)
                AddEntryEditor(entry);*/

            foreach (var entry in (Node.HandlerData as SetValuesData).Entries)
            {
                var test = Ontology.TestByKey(entry.Key);
                var item = new ListViewItem(entry.Key);
                entryList.Items.Add(item);

                if (test != null)
                {
                    item.SubItems.Add(test.Title);
                    item.SubItems.Add("---");
                }
                else
                {
                    item.ForeColor = Color.Red;
                    item.Font = new Font(DefaultFont, FontStyle.Strikeout);
                }
                
            }
        }


        private void SaveNode() 
        {
            /*foreach (var editor in EntryEditors)
                editor.SaveEntry();*/
        }


        /*public void AddEntryEditor(SetValuesDataEntry entry)
        {
            var editor = new SetValuesNodeEntryEditor()
            {
                Ontology = this.Ontology,
                Node = this.Node,
                Entry = entry
            };
            editorsFlow.Controls.Add(editor);
            EntryEditors.Add(editor);

            // subscribe to delete event, and delete editor/entry when it happens:
            editor.Deleted += () =>
            {
                Data.Entries.Remove(entry);
                editorsFlow.Controls.Remove(editor);
                EntryEditors.Remove(editor);
            };
        }*/

        public void OnOuterEditorClosing()
        {
            SaveNode();
        }


        public model.Ontology Ontology
        {
            get;
            set;
        }

        private void SetValuesNodeEditor_Load(object sender, EventArgs e)
        {
            //LoadNode();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var entry = new SetValuesDataEntry();
            Data.Entries.Add(entry);
            //AddEntryEditor(entry);
        }
    }
}
