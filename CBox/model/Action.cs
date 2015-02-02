using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.model
{
    public class Action
    {
        public string ident;
        public List<string> keys = new List<string>();
        public string name;
        public List<string> target_classes = new List<string>();

        public double risk;
        public double pain;
        public double cost;

        public double time_occupied;
        public double time_parallel;
    }
}
