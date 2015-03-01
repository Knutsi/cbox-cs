using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.setter
{
    public class StringSetterData : XMLSerializable<StringSetterData>
    {
        public List<string> Strings { get; set; }
        public List<ThesaurusEntry> Thesaurus { get; set; }

        public StringSetterData()
        {
            Strings = new List<string>();
            Thesaurus = new List<ThesaurusEntry>();
        }
    }
}
