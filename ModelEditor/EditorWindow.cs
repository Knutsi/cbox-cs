using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cbox.generation;
using cbox.generation.nodetype;
using cbox.modelling;

namespace ModelEditor
{
    public partial class EditorWindow : Form
    {
        public NodeCollectionDiagram Diagram { get; set; }

        public EditorWindow()
        {
            InitializeComponent();
        }

        private void EditorWindow_Load(object sender, EventArgs e)
        {
            Diagram = new NodeCollectionDiagram() { Dock = DockStyle.Fill };
            Controls.Add(Diagram);

            var model = new Model(true);
            var comp = model.RootComponent;

            var A = new Node("A", BaseType.TYPE_IDENT) { PosX = 100, PosY = 100 };
            var B = new Node("B", SetValue.TYPE_IDENT) { PosX = 250, PosY = 100 };
            var C = new Node("C", BaseType.TYPE_IDENT) { PosX = 1050, PosY = 100 };

            comp.Add(true, A, B, C);

            A.FirstOutputSocket.Connect(B);
            B.FirstOutputSocket.Connect(C);

            comp.StartNode = A;
            comp.EndNode = B;

            Diagram.NodeCollection = model.RootComponent;
        }

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            Diagram.Zoom *= 1.5F;
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            Diagram.Zoom *= 0.5F;
        }
    }
}
