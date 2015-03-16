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
            mainSplitLayout.Panel1.Controls.Add(Diagram);

            var model = new Model(true);
            var comp = model.RootComponent;

            var A = new Node("Starter", BaseType.TYPE_IDENT) { PosX = 100, PosY = 150 };
            var B = new Node("Problem #1", ProblemStart.TYPE_IDENT) { PosX = 250, PosY = 150 };
            var C = new Node("C", BaseType.TYPE_IDENT) { PosX = 400, PosY = 150 };
            var D = new Node("D", ProblemEnd.TYPE_IDENT) { PosX = 550, PosY = 150 };
            var E = new Node("Ender", BaseType.TYPE_IDENT) { PosX = 700, PosY = 150 };

            comp.Add(true, A, B, C, D, E);

            A.FirstOutputSocket.Connect(B);
            B.FirstOutputSocket.Connect(C);
            C.FirstOutputSocket.Connect(D);
            D.FirstOutputSocket.Connect(E);

			A.FirstOutputSocket.Label = "Demo label";

            comp.StartNode = A;
            comp.EndNode = E;

            comp.Invalidate();

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
