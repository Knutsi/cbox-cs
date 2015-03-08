using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cbox.model
{
    public class Problem
    {
        public Case ParentCase;

        public string Ident { get; set; }
        public string Title { get; set; }
        public List<TestResult> TestResults{ get; set; }
        public string[] Classes { get; set; }

        public Problem()
        {
            TestResults = new List<TestResult>();
        }

        public void Add(TestResult tr) {
            TestResults.Add(tr);
        }

        public void Add(string key, string value)
        {
            var result = new TestResult()
            {
                Key = key,
                Value = value
            };

            Add(result);
        }

        public void Add(TestResult[] results)
        {
            foreach (TestResult r in results)
                Add(r);
        }

        public TestResult resultWithKey(string key)
        {
            foreach (var result in this.TestResults)
                if (result.Key == key)
                    return result;
            
            return null;
        }

        /// <summary>
        /// Gets test result by ident.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TestResult this[string key]
        {
            get { return resultWithKey(key); }
        }


        public bool IsRoot
        {
            get
            {
                return this == this.ParentCase.RootProblem;
            }
        }
    }
}
