using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.model;

namespace cbox.server
{
    public class GameSession
    {
        public int SessionID { get; set; }
        public Case Case { get; set; }
        public List<ActionProblemPair> ActionsTaken { get; set; }
    }
}
