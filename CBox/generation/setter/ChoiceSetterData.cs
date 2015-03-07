using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.setter
{

    public class ChoiceSetterData : XMLSerializable<ChoiceSetterData>
    {
        public string SourceListIdent { get; set; }
        public List<string> Choices { get; set; }

        public ChoiceSetterData()
        {
            this.Choices = new List<string>();
        }
    }
}
