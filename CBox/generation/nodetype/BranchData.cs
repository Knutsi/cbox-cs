using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace cbox.generation.nodetype
{
    public enum BranchMode 
    {
        MAYBE, 
        NOFF, 
        ALL
    }

    public class BranchData : XMLSerializable<BranchData>
    {
        [XmlIgnore]
        internal Node _ParentNode;

        private BranchMode _Mode;
        public ushort N = 1;

        public OutputSocket GuaranteedSocket = new OutputSocket() { Type = OutputSocketType.GUARANTEED };
        public List<BranchDataSocketEntry> PossibleSockets = new List<BranchDataSocketEntry>();

        public BranchData()
        {
            Mode = BranchMode.ALL;

            // default setup is "all" mode and two default sockets:
            GuaranteedSocket.Label = "A";
            //PossibleSockets.Add(new BranchDataSocketEntry("B"));
            AddPossibleSocket(new BranchDataSocketEntry("B"));
        }


        public void AddPossibleSocket(BranchDataSocketEntry entry)
        {
            PossibleSockets.Add(entry);
            entry.Socket.ParentNode = ParentNode;

            // ensure socket has the correct type for current mode:
            UpdateSocketTypes();  
        }


        public void RemovePossibleSocket(BranchDataSocketEntry entry)
        {
            PossibleSockets.Remove(entry);
        }


        public BranchMode Mode
        {
            get
            {
                return _Mode;
            }

            set
            {
                _Mode = value;
                
                /* We need to convert the socket types here due to the change in 
                 * type that might have occured. */
                UpdateSocketTypes();
                
            }
        }

        private void UpdateSocketTypes() {
            OutputSocketType socktype;
                switch (Mode)
                {
                    case BranchMode.MAYBE:
                        socktype = OutputSocketType.POSSIBLE;
                        break;
                    case BranchMode.NOFF:
                        socktype = OutputSocketType.POSSIBLE;
                        break;
                    case BranchMode.ALL:
                        socktype = OutputSocketType.GUARANTEED;
                        break;
                    default:
                        socktype = OutputSocketType.GUARANTEED;
                        break;
                }

                foreach (var entry in PossibleSockets)
                    entry.Socket.Type = socktype;
        }

        /// <summary>
        /// When the parent node changes, or is set initally, all sockets need to be updated:
        /// </summary>
        [XmlIgnore]
        internal Node ParentNode
        {
            get
            {
                return _ParentNode;
            }

            set 
            {
                _ParentNode = value;
                GuaranteedSocket.ParentNode = ParentNode;
                foreach (var entry in PossibleSockets)
                {
                    entry.Socket.ParentNode = ParentNode;
                }
            }
        }
    }
}
