using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.setter
{
    public class MultiRangeSetterData : XMLSerializable<MultiRangeSetterData>
    {
        public List<MultiRangeSetterDataEntry> Ranges = new List<MultiRangeSetterDataEntry>();
    }
}
