using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

using cbox.generation;

namespace cbox.modelling
{
    internal class NodeComponent : IDiagramComponent
    {
        internal static int HEIGHT = 80;
        internal static int WIDTH = 80;

        public object SourceObject { get; set; }
        public NodeCollectionDiagram ParentDiagram { get; set; }

        public NodeComponent(Node node, NodeCollectionDiagram parent)
        {
            SourceObject = node;
            ParentDiagram = parent;
        }

        public Node Node { 
            get {
                return (Node)SourceObject;
            } 
        }

        public void Paint(System.Drawing.Graphics g, DiagramComponentState state)
        {
            // background:
            g.FillRectangle(
                Brushes.Black,
                new Rectangle(Node.PosX + 3, Node.PosY + 3, WIDTH, HEIGHT)
                );

            // background:
            g.FillRectangle(
                Brushes.White,
                new Rectangle(Node.PosX, Node.PosY, WIDTH, HEIGHT)
                );

            // outline:
            g.DrawRectangle(
                Pens.Black,
                new Rectangle(Node.PosX, Node.PosY, WIDTH, HEIGHT)
                );

            // title:
            g.DrawString(
                Node.Title,
                SystemFonts.DefaultFont,
                Brushes.Black,
                Node.PosX + 5,
                Node.PosY + 5
                );

            // input socket:
            var socket_rect = new RectangleF(
                Node.PosX - SocketComponent.WIDTH/2,
                Node.PosY + (HEIGHT / 2) - (SocketComponent.HEIGHT/2),
                SocketComponent.WIDTH,
                SocketComponent.HEIGHT);

            g.FillEllipse(Brushes.White, socket_rect);
            g.DrawEllipse(Pens.Black, socket_rect);
        }

        public static Point CalculateInputSocketPosition(int x, int y)
        {
            return new Point(
                x - SocketComponent.WIDTH / 2,
                y + (HEIGHT / 2) - (SocketComponent.HEIGHT / 2));
        }

        public System.Drawing.Rectangle Rectangle
        {
            get { return new Rectangle(Node.PosX, Node.PosY, WIDTH, HEIGHT); }
        }

        public int HeightIndex
        {
            get { return 1;  }
        }


        public DiagramComponentType Type
        {
            get { return DiagramComponentType.NODE; }
        }
    }
}
