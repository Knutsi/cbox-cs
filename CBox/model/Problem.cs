using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cbox.model
{
    public class Problem
    {
        public string Ident { get; set; }
        public string Title { get; set; }
        public List<TestResult> TestResults{ get; set; }
        public string[] Classes { get; set; }

        public Problem()
        {
            TestResults = new List<TestResult>();
        }

        public void add(TestResult tr) {
            TestResults.Add(tr);
        }

        public void add(TestResult[] results)
        {
            foreach (TestResult r in results)
                add(r);
        }

    }
}
