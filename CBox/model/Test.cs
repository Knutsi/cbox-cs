using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace cbox.model
{
    public class Test
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string Suffix { get; set; }
        public string Unit { get; set; }
        public bool Accumulative { get; set; }
        public string Datatype { get; set; }
        public string Parent { get; set; }
        public string SetterIdent { get; set; }
        public string SetterXMLData { get; set; }

        public Test()
        {
            Accumulative = true;
        }
    }
}
