using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.model
{
    public class Diagnosis
    {
        public string Name { get; set; }
        public string ICD10 { get; set; }
        public string ICPC { get; set; }

        public Diagnosis()
        {

        }

        public Diagnosis(string name)
        {
            this.Name = name;
        }
    }
}
