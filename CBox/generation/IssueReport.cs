using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation
{
    public class IssueReport : List<IssueReportEntry>
    {
        public bool HasUnconnectedNodes = false;
        public bool NodeMissingOutputSocket = false;
        public bool IsCyclic = false;
        public bool MissingStartNode = true;
        public bool MissingEndNode = true;

        /// <summary>
        /// True is report contains no issues that makes it invalid.
        /// </summary>
        public bool Valid
        {
            get
            {
                return !IsCyclic
                    && !MissingStartNode
                    && !MissingEndNode
                    && !HasUnconnectedNodes
                    && !NodeMissingOutputSocket;
            }
        }
    }
}
