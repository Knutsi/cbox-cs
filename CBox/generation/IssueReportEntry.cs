using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation
{
    public enum IssueType
    {
        PROBLEM_CIRCULAR,
        PROBLEM_NO_END,

        NODE_MISSING_OUTPUT_SOCKET,
        
        SOCKET_DISCONNECTED,

        CYCLIC_CONNECTION
    }

    public enum ObjectType {
        NODE
    }

    public enum IssueLevel
    {
        WARNING,
        ERROR
    }

    public class IssueReportEntry
    {
        public IssueType IssueType;
        public ObjectType ObjectType;
        public int ObjectIdent;

        public string CustomMessage = null;

        public NodeCollection SourceCollection;

        public IssueReportEntry(NodeCollection collection, string custom_message=null)
        {
            this.SourceCollection = collection;

            if (custom_message != null)
                CustomMessage = custom_message;
        }

        public string Message
        {
            get
            {
                if (CustomMessage != null)
                    return CustomMessage;

                switch (IssueType)
                {
                    case IssueType.PROBLEM_CIRCULAR:
                        return "Circular problem detected";
                    case IssueType.PROBLEM_NO_END:
                        return "Problem started, but has not end";
                    default:
                        return "Unknown problem";
                }
            }
        }



    }
}
