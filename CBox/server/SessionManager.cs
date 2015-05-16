using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.server
{
    public class SessionManager
    {
        private long NextSessionIdent_ = 1;
        public long NestSessionIdent 
        { 
            get; 
            set; 
        }
    }
}
