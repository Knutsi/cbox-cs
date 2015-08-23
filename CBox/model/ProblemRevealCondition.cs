using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace cbox.model
{
    /// <summary>
    /// Describes the 
    /// </summary>
    public class ProblemRevealCondition
    {
        public string Key { get; set; }
        public BindingList<String> Autotriggers = new BindingList<string>();

        public string DisplayName { get { return this.ToString(); } }

        public override string ToString()
        {
            var str = Key;
            var autotriggers_str = string.Join("; ", Autotriggers);

            return string.Format("{0}: [auto: {1}]", str, autotriggers_str);
        }
    }


}
