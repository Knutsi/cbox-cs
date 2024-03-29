﻿using System;
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
        public BindingList<string> RevealsClasses = new BindingList<string>();

        public int Time { get; set; }
        public double Risk { get; set; }
        public double Pain { get; set; }
        public int Money { get; set; }

        public bool VisibleHeadlineHint{ get; set; }

        public string TitleWithClassnames
        {
            get
            {
                return Title + " <" + string.Join(", ", TargetClasses) + ">";
            }
        }
    }
}
