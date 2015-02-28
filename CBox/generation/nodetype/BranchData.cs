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
        private BranchMode _Mode;
        public ushort N = 1;

        public OutputSocket GuaranteedSocket = new OutputSocket() { Type = OutputSocketType.GUARANTEED };
        public List<BranchDataSocketEntry> PossibleSockets = new List<BranchDataSocketEntry>();

        public BranchData()
        {
            // default setup is "all" mode and two default sockets:
            GuaranteedSocket.Label = "A";
            PossibleSockets.Add(new BranchDataSocketEntry("B"));

            Mode = BranchMode.ALL;
        }


        public void AddPossibleSocket(BranchDataSocketEntry entry)
        {
            PossibleSockets.Add(entry);

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
    }
}
