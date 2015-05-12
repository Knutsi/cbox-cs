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


        public ASShorthandParams AS_Params
        {
            get { return new ASShorthandParams(this.Params); }
        }


        public ARShorthandParams AR_Params
        {
            get { return new ARShorthandParams(this.Params); }
        }

        public RShorthandParams R_Params
        {
            get { return new RShorthandParams(this.Params); }
        }
    }
}
