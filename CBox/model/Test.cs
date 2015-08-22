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
        public string Prefix { get; set; }
        public string Unit { get; set; }
        public int Decimals { get; set; }       // decimals when rounding
        public bool Accumulative { get; set; }  // can hold a list of values
        public string Datatype { get; set; }
        //public string Parent { get; set; }
        public string SetterIdent { get; set; }
        public string SetterXMLData { get; set; }
        public List<string> Dependencies { get; set; }

        public Test()
        {
            Accumulative = true;
            Dependencies = new List<string>();
        }
    }
}
