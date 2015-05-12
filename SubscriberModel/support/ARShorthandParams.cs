using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OntologyEditor
{
    public class ARShorthandParams
    {
        public string ParamsText;
        public string Gender;
        public double AgeStart;
        public double AgeEnd;
        public double ValueStart;
        public double ValueEnd;

        public bool Valid = false;


        public ARShorthandParams(string parameters)
        {
            this.ParamsText = parameters;

            // parse:
            var regex = new Regex("(.)(.*)-(.*):(.*)-(.*)");
            var match = regex.Match(this.ParamsText);


            try
            {
                Gender = match.Groups[1].Value.Trim();
                AgeStart = double.Parse(match.Groups[2].Value.Trim());
                AgeEnd = double.Parse(match.Groups[3].Value.Trim());
                ValueStart = double.Parse(match.Groups[4].Value.Trim());
                ValueEnd = double.Parse(match.Groups[5].Value.Trim());

                Valid = true;
            }
            catch
            {
                Valid = false;
            }
        }

        
    }
}
