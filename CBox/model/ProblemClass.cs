﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.model
{
    public class ProblemClass
    {
        public string Ident { get; set; }
        public string Title { get; set; }

        public ProblemClass()
        {

        }

        public ProblemClass(string ident, string title)
        {
            Ident = ident;
            Title = title;
        }
    }
}
