using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.model
{
    public class DiagnosisCatalogEntry 
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public static DiagnosisCatalogEntry FromLineICD10(string line)
        {
            var elements = line.Split('\t');

            return new DiagnosisCatalogEntry()
            {
                Code = elements[0].Trim(),
                Name = elements[1].Trim()
            };
        }
    }
}
