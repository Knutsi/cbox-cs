using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologyEditor
{
    public class ShorthandCommand
    {
        public string Command;
        public string Params;

        public ShorthandCommand(string cmd)
        {
            var parts = cmd.Split(':');
            this.Command = parts[0];
            this.Params = parts[1];
        }

        public List<string> CommaSplitParams 
        { 
            get
            {
                return this.Params.Split(',').ToList();
            }
            
        }
    }
}
