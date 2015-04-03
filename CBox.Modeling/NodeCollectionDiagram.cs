using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

using cbox.generation;

namespace cbox.modelling
{
    public delegate void SelectionChangedEvent();

    public enum DragOperation
    {
        MOVE, CONNECT, PAN, SELECT
    }

    /// <summary>
    /// Custom control that draws a node collection and allows the user to select and 
    /// rearrange nodes + connect sockets.  It listens for events on the selected
    /// node collection, and rerenders as nessecary. 
    /// </summary>
    public class NodeCollectionDiagram : Control
    {
        private const int INSERT_OFFSET = 30;

        public event SelectionChangedEvent SelectionChanged;

        private cbox.generation.NodeCollection _NodeCollection;
        public List<IDiagramComponent> DiagramComponents;

        public HScrollBar HScrollBar = new HScrollBar() { Dock = DockStyle.Bottom };
        public VScrollBar VScrollBar = new VScrollBar() { Dock = DockStyle.Right };

        // fields to assist various operations:
        public Point AdjustedMousePosition { get; set; }
        private Point PreviousMousePosition;
        public IDiagramComponent ComponentUnderMouse { get; set; }
        
        // drag and drop state fields:
        public DragOperation? CurrentDragOperation { get; set; }
        public object DragObject { get; set; }
        public Point DragStartPoint;

        // default position for inserting new nodes:
        public Point InsertPosition { get; set; }

        // size of diagram and what portion we see:
        public Size DiagramSize { get; set; }
        public Rectangle Viewport { get; set; }
        private float Zoom_ = 1.0F;

        // selection state:
        internal IDiagramComponent SelectedComponent { get; set; }
        //public Node SelectedNode { get; set; }
        public OutputSocket SelectedSocket { get; set; }
        public List<Node> SelectedNodes = new List<Node>();
        private System.Drawing.Size DragDelta;
        
        

        public NodeCollectionDiagram()
        {
            this.DiagramComponents = new List<IDiagramComponent>();

            Controls.Add(this.VScrollBar);
            Controls.Add(this.HScrollBar);

            InsertPosition = new Point(200, 200);

            // setup events:
            this.HScrollBar.ValueChanged += HandleScrolling;
            this.VScrollBar.ValueChanged += HandleScrolling;

            // basic settings:
            this.DoubleBuffered = true;
        }

        void HandleScrolling(object sender, EventArgs e)
        {
            UpdateViewport();
        }

        /// <summary>
        /// The model currently being edited.
        /// </summary>
        public NodeCollection NodeCollection {

            get { return this._NodeCollection; }
            
            set
            {
                this._NodeCollection = value;

                // connect events:

                // reload all items:
                if(value != null)
                    Reload();

                this.Invalidate();

                // invalidate on future changes:
                this.NodeCollection.Changed += Reload;
            }
        }

        /// <summary>
        /// Rebuilds all diagram components from model.
        /// </summary>
        public void Reload()
        {
            this.DiagramComponents = new List<IDiagramComponent>();

            // one node component for each node:
            foreach (var node in this.NodeCollection.Nodes)
                DiagramComponents.Add(new NodeComponent(node, this));

            // one node for each socket:
            foreach (var socket in NodeCollection.AllOutputSockets)
                DiagramComponents.Add(new SocketComponent(socket, this));

            // one for each connection:
            foreach (var con in NodeCollection.Connections)
                DiagramComponents.Add(new ConnectionComponent(con, this));

            // each problem:
            foreach (var probset in NodeCollection.ProblemSets)
                DiagramComponents.Add(new ProblemOutlineComponent(probset, this));

            // special components:
            DiagramComponents.Add(new DragLineComponent(this));
            DiagramComponents.Add(new SelectBoxComponent(this));

            // update size of diagram:
            UpdateSize();

            // reload triggers invalidation:
            Invalidate();
        }



        // 
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            StartDrag(AdjustedMousePosition.X, AdjustedMousePosition.Y);

            // are we selecting?
            if (ComponentUnderMouse != null)
            {
                SelectedComponent = ComponentUnderMouse;

                if (ComponentUnderMouse.Type == DiagramComponentType.NODE)
                {
                    // are we in multiselect? (shif held down):
                    var node = (Node)ComponentUnderMouse.SourceObject;
                    if (Control.ModifierKeys == Keys.Shift)
                    {
                        // add or remove from selection:
                        if (SelectedNodes.Contains(node))
                            SelectedNodes.Remove(node);
                        else
                            SelectedNodes.Add(node);
                    }
                    else
                    {
                        // single select: just this node:
                        if(!SelectedNodes.Contains(node))
                            SelectedNodes = new List<Node> { node };
                    }

                    FireSelectionChangedEvent();
                }
            }

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (CurrentDragOperation.HasValue)
                EndDrag();
 
        }


        /// <summary>
        /// We need to track what object is undeaneath the mouse pointer when the user moves it:
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            // update cursor:
            if (Control.ModifierKeys == Keys.Shift)
                Cursor.Current = Cursors.NoMove2D;
            else
                Cursor.Current = Cursors.Default;

            // update mouse position and 
            PreviousMousePosition = AdjustedMousePosition;

            AdjustedMousePosition = new Point(
                Convert.ToInt32((e.X / Zoom) + (Viewport.X / Zoom)),
                Convert.ToInt32((e.Y / Zoom) + (Viewport.Y / Zoom))
                );

            // calculate delta moved since last update:
            if (PreviousMousePosition != null)
                DragDelta = new Size(
                    AdjustedMousePosition.X - PreviousMousePosition.X,
                    AdjustedMousePosition.Y - PreviousMousePosition.Y);
            else
                DragDelta = new Size(0, 0);


            // detect what object is underneath:
            var found = from comp in DiagramComponents
                        where comp.Rectangle.Contains(AdjustedMousePosition.X, AdjustedMousePosition.Y)
                        orderby comp.Layer descending
                        select comp;

            if (found.Count() > 0)
                this.ComponentUnderMouse = found.First();
            else
                this.ComponentUnderMouse = null;

            // are we dragging, and need to update?
            if(CurrentDragOperation == DragOperation.MOVE)
            {
                foreach (var node in SelectedNodes)
                {
                    node.PosX += DragDelta.Width;
                    node.PosY += DragDelta.Height;
                }
                

                // might need to expand the diagram if we approach edge:
                UpdateSize();
            }

            // are we selecting, and need to select in box?
            if (CurrentDragOperation == DragOperation.SELECT)
            {
                var nodes = from n in
                                (from c in this.DiagramComponents
                                 where c.Type == DiagramComponentType.NODE
                                 select c.SourceObject as Node)
							where DragRect.IntersectsWith(new Rectangle(n.PosX, n.PosY, NodeComponent.WIDTH, NodeComponent.HEIGHT))
                            select n;

                SelectedNodes = nodes.ToList();
            }

            // are we panning, and need to pan?
            if(CurrentDragOperation == DragOperation.PAN)
            {
                int hval = HScrollBar.Value - Convert.ToInt32(DragDelta.Width * Zoom);
                int vval = VScrollBar.Value - Convert.ToInt32(DragDelta.Height * Zoom);

                // this will trigger a scroll and viewport change, so we'll adjust previous mouse position:
                if (hval > HScrollBar.Minimum && hval < HScrollBar.Maximum)
                {
                    HScrollBar.Value = hval;
                    AdjustedMousePosition.Offset(-hval , 0);
                }

                if (vval > VScrollBar.Minimum && vval < VScrollBar.Maximum)
                {
                    VScrollBar.Value = vval;
                    AdjustedMousePosition.Offset(0, -vval);
                }

            }

            // update while dragging:
            if (CurrentDragOperation != null)
                this.Invalidate();
        }


        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            // reset some things to ensure a clean state:
            ComponentUnderMouse = null;
            EndDrag();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (Control.ModifierKeys == Keys.Control)
            {
                if (e.Delta >= 0)
                    Zoom += 0.05F;
                else
                    Zoom -= 0.05F;
            }
            else if (Control.ModifierKeys == Keys.Shift)
            {
                var value = HScrollBar.Value + e.Delta/4;
                if (value < HScrollBar.Minimum)
                    HScrollBar.Value = 0;
                else if (value > HScrollBar.Maximum)
                    HScrollBar.Value = HScrollBar.Maximum;
                else
                    HScrollBar.Value = value;
            }
            else
            {
                var value = VScrollBar.Value + e.Delta/4
                    ;
                if (value < VScrollBar.Minimum)
                    VScrollBar.Value = 0;
                else if (value > VScrollBar.Maximum)
                    VScrollBar.Value = VScrollBar.Maximum;
                else
                    VScrollBar.Value = value;
            }
                

        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            // select all:
            if(e.KeyCode == Keys.A && e.Control)
                SelectAll();

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                DeleteSelected();
        }


        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            UpdateViewport();
        }



        private void StartDrag(int x, int y)
        {

            // we need to remember how much the drag has been
            DragStartPoint = new Point(x, y);

            // take action depending on what is being dragged:
            if (ComponentUnderMouse != null)
                switch (ComponentUnderMouse.Type)
                {
                    case DiagramComponentType.NODE:
                        CurrentDragOperation = DragOperation.MOVE;
                        DragObject = ComponentUnderMouse.SourceObject;
                        var node = (Node)DragObject;

                        break;

                    case DiagramComponentType.SOCKET:
                        CurrentDragOperation = DragOperation.CONNECT;
                        DragObject = ComponentUnderMouse.SourceObject;
                        ((OutputSocket)DragObject).Disconnect();
                        NodeCollection.Invalidate();
                        break;

                    default:
                        if (Control.ModifierKeys == Keys.Shift)
                            CurrentDragOperation = DragOperation.PAN;
                        else
                        {
                            CurrentDragOperation = DragOperation.SELECT;
                            SelectedNodes = new List<Node>();
                        }
                            
                        break;
                }
            else
            {
                if (Control.ModifierKeys == Keys.Shift)
                    CurrentDragOperation = DragOperation.PAN;
                else
                {
                    CurrentDragOperation = DragOperation.SELECT;
                    SelectedNodes = new List<Node>();
                }
            }
        }


        private void EndDrag()
        {
            // are we connecting a socket?
            if (CurrentDragOperation == DragOperation.CONNECT
                && ComponentUnderMouse != null
                && ComponentUnderMouse.Type == DiagramComponentType.NODE)
            {
                ((OutputSocket)DragObject).Connect((Node)ComponentUnderMouse.SourceObject);
                NodeCollection.Invalidate();
            }

            if(CurrentDragOperation == DragOperation.SELECT)
                FireSelectionChangedEvent();
            
            Reload();
            Invalidate();

            CurrentDragOperation = null;
            DragObject = null;
        }

        public Rectangle DragRect
        {
            get
            {
                // check we have what we need:
                if (DragStartPoint == null || AdjustedMousePosition == null)
                    return new Rectangle();

                // we need to draw a different rect depending of wether we are dragging left/right or up/down:
                var px = DragStartPoint.X;
                var py = DragStartPoint.Y;
                var dx = AdjustedMousePosition.X - px;
                var dy = AdjustedMousePosition.Y - py;

                var x = px; var y = py; var w = dx; var h = dy;

                if (dx < 0)
                {
                    x = px + dx;
                    w = dx * -1;
                }

                if (dy < 0)
                {
                    y = py + dy;
                    h = dy * -1;
                }

                return new Rectangle(x, y, w, h);
            }
        }

        private void UpdateSize()
        {
            if (DiagramComponents.Count <= 0)
                return;

            var nodes = from c in DiagramComponents 
                        where c.Type == DiagramComponentType.NODE 
                        select c;
            if (nodes.Count() <= 0)
                return;

            // calculate new size:
            var leftmost = (from c in nodes
                            orderby ((Node)c.SourceObject).PosX descending
                            select c.SourceObject).First() as Node;

            var bottommost = (from c in nodes
                              orderby ((Node)c.SourceObject).PosY descending
                              select c.SourceObject).First() as Node;

            DiagramSize = new Size(
                leftmost.PosX + 500, 
                bottommost.PosY + 500);

            HScrollBar.Maximum = DiagramSize.Width;
            VScrollBar.Maximum = DiagramSize.Height;

            HScrollBar.Value = Viewport.X;
            VScrollBar.Value = Viewport.Y;

            //Console.WriteLine("{0} {1}", DiagramSize.Width, DiagramSize.Height);
        }

        private void UpdateViewport()
        {
            Viewport = new Rectangle(
                HScrollBar.Value,
                VScrollBar.Value,
                Width,
                Height);

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.Render(e.Graphics);
            base.OnPaint(e);
        }

        /// <summary>
        /// Renders the entire diagram.
        /// </summary>
        /// <param name="g"></param>
        private void Render(Graphics g)
        {
            // account for pan and zoom:
            Matrix matrix = new System.Drawing.Drawing2D.Matrix();
            matrix.Translate(-Viewport.X, -Viewport.Y);
            matrix.Scale(this.Zoom, this.Zoom);

            g.Transform = matrix;

            // settings:
            g.Clear(SystemColors.ControlDarkDark);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // render all components by order of layer:
            var components = from c in this.DiagramComponents
                        orderby c.Layer ascending
                        select c;

            foreach (var component in components)
                component.Paint(g);

            //g.DrawEllipse(Pens.Green, AdjustedMousePosition.X, AdjustedMousePosition.Y, 3, 3);
        }

        /// <summary>
        /// Sets the zoom level of the diagram.
        /// </summary>
        public float Zoom 
        {
            get { return Zoom_; }
            set
            {
                Zoom_ = value;
                this.Invalidate();
            }
        }

        internal void FireSelectionChangedEvent() 
        {
            if(SelectionChanged != null)
                SelectionChanged();
        }


        public void SelectAll()
        {
            SelectedNodes = new List<Node>();
            foreach (var node in NodeCollection.Nodes)
                SelectedNodes.Add(node);

            Invalidate();
            FireSelectionChangedEvent();
        }


        public void DeleteSelected()
        {
            foreach (var node in SelectedNodes)
                NodeCollection.Remove(node);

            SelectedNodes = new List<Node>();

            Reload();
            Invalidate();
            FireSelectionChangedEvent();
        }



        public void NewNode(string type)
        {
            // create a node in the defautl position:
            var node = new Node(type, type)
            {
                PosX = InsertPosition.X + Viewport.X,
                PosY = InsertPosition.Y + Viewport.Y
            };

            InsertPosition.Offset(INSERT_OFFSET, INSERT_OFFSET);

            NodeCollection.Add(node);
        }
    }
}
