﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;


using cbox.generation;

namespace cbox.modelling
{
    public class ConnectionComponent : IDiagramComponent
    {
        public OutputSocket SourceSocket { get; set; }
        public Node TargetNode { get; set; }
        public NodeCollectionDiagram ParentDiagram { get; set; }

        public ConnectionComponent(Connection con, NodeCollectionDiagram parent)
        {
            SourceSocket = con.FromSocket;
            TargetNode = con.ToNode;
            ParentDiagram = parent;
        }

        public object SourceObject
        {
            get;
            set;
        }

        public DiagramComponentType Type
        {
            get { return DiagramComponentType.CONNETION; }
        }

        public void Paint(System.Drawing.Graphics g)
        {
            var from = SocketComponent.CalculateSocketPosition(
                SourceSocket.ParentNode.PosX,
                SourceSocket.ParentNode.PosY,
                SourceSocket.ParentNode.OutputSockets.Count,
                SourceSocket.ParentNode.OutputSockets.IndexOf(SourceSocket));

            var to = NodeComponent.CalculateInputSocketPosition(
                TargetNode.PosX, 
                TargetNode.PosY);

            from.Offset(SocketComponent.WIDTH / 2, SocketComponent.HEIGHT / 2);
            to.Offset(SocketComponent.WIDTH / 2, SocketComponent.HEIGHT / 2);

            DrawLine(g, from, to, Color.Gray, SourceSocket.Label);
        }

		public static void DrawLine(Graphics g, Point from, Point to, Color color, string label=null) 
        {
			// darw line:
            var pen = new Pen(color, 3);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            g.DrawLine(pen, from, to);

			// add label at halway point:
			if (label != null) {
				var font = SystemFonts.DefaultFont;
				var size = g.MeasureString(label, font);
				var width = Convert.ToInt32(size.Width);
				var height = Convert.ToInt32(size.Height);

				var p = new Point (
					to.X - (to.X - from.X)/2 - width/2,  
					to.Y - (to.Y - from.Y)/2 - height/2)
					;
				g.DrawString (label, font, Brushes.White, p);
			}
        }

        public System.Drawing.Rectangle Rectangle
        {
            get { return new Rectangle(); }
        }

        public int Layer
        {
            get { return 10; }
        }
    }
}
