using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologyEditor
{
    public class ASShorthandParams
   {
        public string ParamsText;
        public string StringText;

        public bool Valid = false;

        public ASShorthandParams(string parameters)
        {
            this.ParamsText = parameters;
            this.StringText = this.ParamsText;
        }
    }
}
