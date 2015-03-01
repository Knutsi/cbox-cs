using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.setter
{
    public class RangeSetterData : XMLSerializable<RangeSetterData>
    {
        public double Min { get; set; }
        public double Max { get; set; }
    }
}
