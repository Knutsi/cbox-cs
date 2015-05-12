using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OntologyEditor
{
    public class RShorthandParams
    {
        public string ParamsText;
        public double ValueStart;
        public double ValueEnd;

        public bool Valid = false;

        public RShorthandParams(string parameters)
        {
            this.ParamsText = parameters;

            try
            {
                var regex = new Regex("(.*)-(.*)");
                var match = regex.Match(this.ParamsText);

                ValueStart = double.Parse(match.Groups[1].Value.Trim());
                ValueEnd = double.Parse(match.Groups[2].Value.Trim());

                Valid = true;
            }
            catch (Exception)
            {
                Valid = false;
            }
        }
    }
}
