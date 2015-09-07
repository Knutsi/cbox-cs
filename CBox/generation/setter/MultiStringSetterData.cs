using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.setter
{
    public class MultiStringSetterData : XMLSerializable<MultiStringSetterData>
    {
        public List<MultiStringSetterDataEntry> Ranges = new List<MultiStringSetterDataEntry>();
    }
}
