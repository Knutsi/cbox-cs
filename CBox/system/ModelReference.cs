using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.generation;

namespace cbox.system
{
    public class ModelReference
    {
        public string Path;
        public string Title;

        public string Ident
        {
            get { return Title; }
        }
    }
}
