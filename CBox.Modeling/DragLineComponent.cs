using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

using cbox.generation;

namespace cbox.modelling
{
    /// <summary>
    /// Draws a line from output socket to cursor when user is dragging.
    /// </summary>
    public class DragLineComponent : IDiagramComponent
    {
        public DragLineComponent(NodeCollectionDiagram parent)
        {
            ParentDiagram = parent;
        }

        public object SourceObject
        {
            get;
            set;
        }

        public DiagramComponentType Type
        {
            get { return DiagramComponentType.DRAGLINE; }
        }

        public NodeCollectionDiagram ParentDiagram
        {
            get;
            set;
        }

        public void Paint(System.Drawing.Graphics g, DiagramComponentState state)
        {
            if (ParentDiagram.CurrentDragOperation == null || ParentDiagram.CurrentDragOperation != DragOperation.CONNECT)
                return;

            var socket = (OutputSocket)ParentDiagram.DragObject;

            var from = SocketComponent.CalculateSocketPosition(socket);
            var to = ParentDiagram.AdjustedMousePosition;

            from.Offset(SocketComponent.WIDTH / 2, SocketComponent.WIDTH / 2);

            ConnectionComponent.DrawLine(g, from, to);
        }

        public System.Drawing.Rectangle Rectangle
        {
            get { return new Rectangle(); }
        }

        public int HeightIndex
        {
            get { return 10; }
        }
    }
}
