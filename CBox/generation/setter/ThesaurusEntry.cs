using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.setter
{
    public class ThesaurusEntry
    {
        public string Word { get; set; }
        public List<string> Synonyms { get; set; }
    }
}
