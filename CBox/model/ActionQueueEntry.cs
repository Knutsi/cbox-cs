using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.model
{
    /// <summary>
    /// Actions can be instructions to get key, or to wait for queue to finish.
    /// Order tests specify what test and on what problem. 
    /// </summary>
    public class ActionRequest
    {
        const string ORDER_TEST = "ORDER_ACTION";
        const string WAIT_FOR_QUEUE = "WAIT_FOR_QUEUE";

        public string Type { get; set; }
        public string ActionIdent { get; set; }
        public string ProblemIdent { get; set; }

        public ActionRequest()
        {
            Type = ORDER_TEST;
        }
    }
}
