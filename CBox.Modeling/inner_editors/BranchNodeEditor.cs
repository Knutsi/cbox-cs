using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cbox.generation;
using cbox.generation.nodetype;

namespace cbox.modelling.editors
{
    public partial class BranchNodeEditor : UserControl, IInnerEditor
    {
        private Node _Node;
        public NodeEditor ParentEditor { get; set; }

        public BranchNodeEditor()
        {
            InitializeComponent();
        }

        public Node Node
        {
            get {  return _Node; }

            set 
            {
                DisableEvents();

                SaveNode();
                _Node = value;
                LoadNode();

                EnableEvents();
            }
        }

        public BranchData Data
        {
            get
            {
                return (BranchData)Node.HandlerData;
            }
        }


        public void DisableEvents()
        {
            allRadioButton.CheckedChanged -= ModeChange;
            maybeRadioButton.CheckedChanged -= ModeChange;
            noffRadioButton.CheckedChanged -= ModeChange;
            branchesInput.TextChanged -= SaveNode;
            nSelect.ValueChanged -= SaveNode;
        }

        public void EnableEvents()
        {
            allRadioButton.CheckedChanged += ModeChange;
            maybeRadioButton.CheckedChanged += ModeChange;
            noffRadioButton.CheckedChanged += ModeChange;
            branchesInput.TextChanged += SaveNode;
            nSelect.ValueChanged += SaveNode;
        }



        private void LoadNode()
        {
            // set radio toggle:
            maybeRadioButton.Checked = Data.Mode == BranchMode.MAYBE;
            noffRadioButton.Checked = Data.Mode == BranchMode.NOFF;
            allRadioButton.Checked = Data.Mode == BranchMode.ALL;

            // eable or disable n-input:
            nSelect.Enabled = Data.Mode == BranchMode.NOFF;

            // n-select:
            if (Data.N != null)
                nSelect.Value = Data.N;
            else
                nSelect.Value = 1;

            // load branches:
            var texbox_lines = "";
            if (Data.Mode != BranchMode.MAYBE)
                texbox_lines += Data.GuaranteedSocket.Label + Environment.NewLine;

            var possibles = from p in Data.PossibleSockets
                            select p.Socket.Label.Trim();

            texbox_lines += string.Join(Environment.NewLine, possibles);

            branchesInput.Text = texbox_lines;
        }



        private void SaveNode(object sender=null, EventArgs ev=null)
        {
            if (Node == null)
                return;

            // set node:
            if (noffRadioButton.Checked)
                Data.Mode = BranchMode.NOFF;
            else if (maybeRadioButton.Checked)
                Data.Mode = BranchMode.MAYBE;
            else if (allRadioButton.Checked)
                Data.Mode = BranchMode.ALL;

            // update sockets based on the editor:
            RebuildSockets();

            // n-number:
            Data.N = Convert.ToInt16(nSelect.Value);
            UpdateTitle();

            // call on handler to save the data:
            Node.Handler.SaveData();

            // notify the node that is has changed (they are pretty stupid like that):
            this.Node.FireChangedEvent();
        }

        private void RebuildSockets()
        {
            var lines = branchesInput.Text.Split(
                new string[] { Environment.NewLine }, 
                StringSplitOptions.None);

            var entries = new List<BranchDataSocketEntry>();

            for (int i = 0; i < lines.Length; i++)
            {
                // first line foes to guaranteed - if we are not in maybe mode (where it
                // is hidden)
                if(Data.Mode != BranchMode.MAYBE && i == 0)
                {
                    Data.GuaranteedSocket.Label = lines[i];
                    continue;
                }

                // lines area added as possible sockets:
                var entry = new BranchDataSocketEntry(lines[i]);
                entries.Add(entry);
            }

            // set and update:
            Data.PossibleSockets = entries;
            Node.UpdateInternals();
            UpdateTitle();

            // enforce limit on n-selector:
            nSelect.Maximum = entries.Count + 1;
            if (nSelect.Value > nSelect.Maximum)
                nSelect.Value = 1;
        }





        private void ModeChange(object sender = null, EventArgs ev = null)
        {
            SaveNode();
            Data.GuaranteedSocket = new OutputSocket() { Label = "(G)" };
            Data.PossibleSockets = new List<BranchDataSocketEntry>();
            
            Node.UpdateInternals();

            LoadNode(); 
            UpdateTitle();
            ParentEditor.LoadNode();
            
        }


        public void UpdateTitle()
        {
            switch (Data.Mode)
            {
                case BranchMode.MAYBE:
                    Node.Title = "Maybe";
                    break;
                case BranchMode.NOFF:
                    Node.Title = Data.N + "of" + (Data.PossibleSockets.Count + 1);   // + guaranteed
                    break;
                case BranchMode.ALL:
                    Node.Title = "All";
                    break;
                default:
                    break;
            }

            ParentEditor.LoadNode();
        }


        public void OnOuterEditorClosing()
        {
            SaveNode();
        }





        public model.Ontology Ontology
        {
            get;
            set;
        }
    }
}
