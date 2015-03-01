using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cbox.generation
{
    public class ExecutingInvalidNodeCollectionException : Exception
    {
        public IssueReport Issues { get; set; }

        public ExecutingInvalidNodeCollectionException(IssueReport issues)
        {
            this.Issues = issues;
        }
    }
}
