using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox
{
    abstract public class IdentProvider
    {
        public int _NextIdent { get; set; }

        public int NextIdent
        {
            get
            {
                _NextIdent += 1;
                return _NextIdent;
            }
        }
    }
}
