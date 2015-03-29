using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cbox.generation;
using cbox.modelling;

namespace ModelEditor
{
    /// <summary>
    /// Stores a tabpage, node collection and diagram for a given sub-model.
    /// </summary>
    internal class SubModelTabEntry
    {
        internal TabPage Tab;
        internal NodeCollection Component;
        internal NodeCollectionDiagram Diagram;

        public SubModelTabEntry(NodeCollection collection)
        {
            Tab = new TabPage();
            Component = collection;

            Diagram = new NodeCollectionDiagram()
            {
                Dock = DockStyle.Fill,
                NodeCollection = Component
            };

            Tab.Controls.Add(Diagram);

            Tab.Text = Component.Ident;

            // update title when collection ident chagnes:
            Component.IdentChanged += Component_IdentChanged;
        }

        void Component_IdentChanged(string ident)
        {
            Tab.Text = ident;
        }
    }
}
