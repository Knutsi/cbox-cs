using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Drawing;

using cbox.generation;

namespace cbox.modelling
{
    internal class SocketComponent : IDiagramComponent
    {
        public static int HEIGHT = 12;
        public static int WIDTH = 12;

        public object SourceObject { get; set; }
        public OutputSocket Socket { get { return (OutputSocket)SourceObject; } }
        public Node Node { get { return Socket.ParentNode; } }
        public NodeCollectionDiagram ParentDiagram { get; set; }

        public SocketComponent(OutputSocket socket, NodeCollectionDiagram parent)
        {
            this.SourceObject = socket;
            this.ParentDiagram = parent;
        }

        public void Paint(System.Drawing.Graphics g)
        {
            var shadow_rect = this.Rectangle;
            shadow_rect.Offset(2, 2);

            g.FillEllipse(Brushes.Black, shadow_rect);
            g.FillEllipse(Brushes.White, this.Rectangle);
            g.DrawEllipse(Pens.Black, this.Rectangle);
        }

        public System.Drawing.Rectangle Rectangle
        {
            get 
            {
                var socket_pos = CalculateSocketPosition(
                    Node.PosX,
                    Node.PosY,
                    Node.OutputSockets.Count,
                    Node.OutputSockets.IndexOf(Socket));

                return new Rectangle(
                    socket_pos.X,
                    socket_pos.Y,
                    WIDTH,
                    HEIGHT);
            }
        }

        public static Point CalculateSocketPosition(int x, int y, int count, int index)
        {
            int offset = (NodeComponent.HEIGHT / (count + 1)) * (index + 1) - (HEIGHT/2);

            return new Point(
                x + NodeComponent.WIDTH - (WIDTH / 2),
                y + offset);
        }

        public static Point CalculateSocketPosition(OutputSocket socket)
        {
            var node = socket.ParentNode;

            return CalculateSocketPosition(
                node.PosX, 
                node.PosY, 
                node.OutputSockets.Count, 
                node.OutputSockets.IndexOf(socket));
        }

        public int Layer
        {
            get { return 30; }
        }

        public DiagramComponentType Type
        {
            get { return DiagramComponentType.SOCKET; }
        }
    }
}
