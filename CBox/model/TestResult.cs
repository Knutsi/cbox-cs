using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.model
{
    /// <summary>
    /// Test result stores the value a key has been set to.  It can have more than 
    /// one value.  When the value is set multiple times, all values are stored.
    /// 
    /// In the event that multiple values are set, but only one should apply, the 
    /// last value added can be accessed through "Value" (singular).
    /// </summary>
    public class TestResult
    {
        public string Key { get; set; }
        public List<string> Values = new List<string>();
        public string Prefix { get; set; }
        public string Unit { get; set; }

        public string Value
        {
            get
            {
                return this.Values.Last();
            }
            set
            {
                this.Values.Add(value);
            } 
        }

        public string ToString(Ontology ontology)
        {
            // aquire info on this test:
            var test = ontology.TestByKey(Key);

            if (test == null)
                return string.Format("({0} not in ontology)", Key);

            var suffix = "";
            if (test.Prefix != null && test.Prefix != string.Empty)
                suffix = test.Prefix + ": ";

            var unit = "";
            if (test.Unit != null && test.Unit != string.Empty)
                unit = " " + test.Unit;

            var value = Value;
            if (test.Accumulative && Values.Count > 1)
                value = string.Join(". ", Values);

            var punctuation = "";
            if (value.Trim()[value.Trim().Length-1] != '.')
                punctuation = ".";
                
            return String.Format("{0}{1}{2}{3}",
                suffix,
                value,
                unit,
                punctuation).Trim();

        }
    }
}
