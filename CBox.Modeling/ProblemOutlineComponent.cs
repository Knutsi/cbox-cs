using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

using cbox.generation;

namespace cbox.modelling
{
    public class ProblemOutlineComponent : IDiagramComponent
    {

        public static int PADDING = 15;

        public ProblemOutlineComponent(ProblemSet set, NodeCollectionDiagram parent)
        {
            ParentDiagram = parent;
            SourceObject = set; 
        }

        public ProblemSet ProblemSet { get { return (ProblemSet)SourceObject; } }

        public object SourceObject
        {
            get; 
            set; 
        }

        public DiagramComponentType Type
        {
            get { return DiagramComponentType.PROBLEM;  }
        }

        public NodeCollectionDiagram ParentDiagram
        {
            get;
            set;
        }

        public void Paint(Graphics g)
        {
            // background:
            var pen = new Pen(Color.Cyan, 3);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            g.FillRectangle(Brushes.DarkCyan, this.Rectangle);
            g.DrawRectangle(pen, this.Rectangle);
           
            // title:
            var font = new Font("Arial", 18.0F);
            g.DrawString(
                ProblemSet.Title,
                font,
                Brushes.LightGray,
                this.Rectangle.X,
                this.Rectangle.Y - font.GetHeight());

        }

        public Rectangle Rectangle
        {
            get 
            {
                // calculate boundaries of problem:
                var node_ys = (from n in ProblemSet.BountNodesPlusStartEnd
                                      orderby n.PosY ascending
                                      select n.PosY);
                
                var x = ProblemSet.StartNode.PosX + NodeComponent.WIDTH / 2;
                var y = node_ys.First() - PADDING;
                var width = ProblemSet.EndNode.PosX - x + (NodeComponent.WIDTH / 2);
                var height = (node_ys.Last() - y) + NodeComponent.HEIGHT + PADDING;

                return new Rectangle(x,y, width, height);
            }
        }

        public int HeightIndex
        {
            get { return 0; }
        }
    }
}
