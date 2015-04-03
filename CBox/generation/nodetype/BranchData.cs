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

    public class BranchData : XMLSerializable<BranchData>, INodeTypeData
    {
        [XmlIgnore]
        internal Node _ParentNode;

        private BranchMode _Mode;
        public short N = 1;

        public OutputSocket GuaranteedSocket;
        public List<BranchDataSocketEntry> PossibleSockets = new List<BranchDataSocketEntry>();

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
        /// Returns the possible socket that matches the label provided.
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public BranchDataSocketEntry PossibleSocketByLabel(string label)
        {
            foreach (var possible_socket in PossibleSockets)
                if (possible_socket.Socket.Label == label)
                    return possible_socket;

            return null;
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
                
                if(GuaranteedSocket != null)
                    GuaranteedSocket.ParentNode = ParentNode;

                foreach (var entry in PossibleSockets)
                {
                    entry.Socket.ParentNode = ParentNode;
                }
            }
        }
    }
}
