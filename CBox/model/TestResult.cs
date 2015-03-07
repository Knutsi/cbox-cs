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
    }
}
