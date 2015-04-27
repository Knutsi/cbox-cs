using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.model;

namespace cbox.model
{
    public class ActionProblemPair
    {
        //public Problem Problem;
        //public cbox.model.Action Action;

        /*public List<string> Keys
        {
            get { return Action.Yield.ToList(); }
        }*/

        public string ProblemIdent
        {
            get;
            set;
        }

        public int ActionIdent
        {
            get;
            set;
        }
    }
}
