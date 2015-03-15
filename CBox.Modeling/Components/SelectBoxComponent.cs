using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace cbox.modelling
{
    public class SelectBoxComponent : IDiagramComponent
    {
        public SelectBoxComponent(NodeCollectionDiagram parent)
        {
            this.ParentDiagram = parent;
        }

        public object SourceObject
        {
            get;
            set;
        }

        public DiagramComponentType Type
        {
            get { return DiagramComponentType.AUXILLARY; }
        }

        public NodeCollectionDiagram ParentDiagram
        {
            get;
            set;
        }

        public void Paint(System.Drawing.Graphics g)
        {
            if(ParentDiagram.CurrentDragOperation != null 
                && ParentDiagram.CurrentDragOperation == DragOperation.SELECT)
            {
                var pen = new Pen(Color.White);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                g.DrawRectangle(pen, this.Rectangle);

            }
        }

        public System.Drawing.Rectangle Rectangle
        {
            get 
            {
                return ParentDiagram.DragRect;
            }
        }

        public int Layer
        {
            get { return 10; }
        }
    }
}
