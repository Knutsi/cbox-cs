using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Xml.Serialization;

using cbox.generation;
using cbox.generation.nodetype;
using cbox.modelling;
using cbox.modelling.editors;

namespace ModelEditor
{
    public partial class EditorsTest : Form
    {

        public EditorsTest()
        {
            InitializeComponent();
            SetupEditors();
        }

        /// <summary>
        /// Creates a node and an editor for each node type that we have, then adds these to
        /// the flow layout.
        /// </summary>
        public void SetupEditors()
        {
            var model = new Model(true);
            var comp = model.RootComponent;

            // add editors:
            foreach (var type in TypeHandlerLibrary.TypeIdents)
            {
                var node = new Node(type, type);
                comp.Add(node);

                var editor = new NodeEditor() { Node = node };
                flowLayout.Controls.Add(editor);

                editor.NodeSaved += editor_NodeSaved;
                node.Changed += editor_NodeSaved;
            }
        }

        void editor_NodeSaved(Node node)
        {
            var ser = new XmlSerializer(typeof(Node));
            var writer = new StringWriter();
            ser.Serialize(writer, node);

            xmlSaveOutput.Text = writer.ToString();
            handlerDataXml.Text = node.XmlData;
        }
    }
}
