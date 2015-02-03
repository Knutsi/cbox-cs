﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace cbox.model
{
    public class Headline
    {
        public string Title { get; set; }
        public BindingList<int> ActionIdents { get; set; }

        public Headline()
        {
            ActionIdents = new BindingList<int>();
            Title = "New headline";
        }
    }
}
