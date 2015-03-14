using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace cbox.modelling
{
    public enum DiagramComponentType
    {
        NODE, SOCKET, CONNETION, DRAGLINE, PROBLEM
    }

    public interface IDiagramComponent
    {
        object SourceObject { get; set; }

        DiagramComponentType Type { get; }
        NodeCollectionDiagram ParentDiagram { get; set; }

        void Paint(Graphics g);
        Rectangle Rectangle { get; }
        int HeightIndex { get; }
    }
}
