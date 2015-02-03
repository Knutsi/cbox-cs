using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace cbox.model
{
    public class Action
    {
        public int Ident;
        public BindingList<string> Yield = new BindingList<string>();
        public string Title { get; set; }
        public BindingList<string> TargetClasses = new BindingList<string>();

        public double Risk { get; set; }
        public double Pain { get; set; }
        public double Cost { get; set; }

        public double TimeUsedOccupied { get; set; }
        public double TimeUsedProcess { get; set; }


    }
}
