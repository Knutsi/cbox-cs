using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.setter
{
    public class MultiRangeSetterDataEntry
    {
        public string Gender { get; set; }

        public double AgeStart { get; set; }
        public double AgeEnd { get; set; }

        public double Min { get; set; }
        public double Max { get; set; }
    }
}
