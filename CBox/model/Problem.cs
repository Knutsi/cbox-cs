using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace cbox.model
{
    [DataContract]
    [Serializable]
    public class Problem
    {
        [XmlIgnore]
        public Case ParentCase;

        [DataMember]
        public string Ident { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string PeerNumber { get; set; }

        [DataMember]
        public List<TestResult> TestResults{ get; set; }

        [DataMember]
        public List<string> Classes { get; set; }

        public Problem()
        {
            TestResults = new List<TestResult>();
        }

        public void Add(TestResult tr) {
            TestResults.Add(tr);
        }

        public void Add(string key, string value, string parent_key, bool abnormal=false)
        {
            var result = new TestResult()
            {
                Key = key,
                Value = value,
                Abnormal = abnormal,
                ParentKey = parent_key
            };

            Add(result);
        }

        public void Add(string key, string value, string prefix, string unit, string parent_key, bool abnormal = false)
        {
            var result = new TestResult()
            {
                Key = key,
                Value = value,
                Prefix = prefix,
                Unit = unit,
                Abnormal = abnormal,
                ParentKey = parent_key
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

        [DataMember]
        public bool IsRoot
        {
            get
            {
                return this == this.ParentCase.RootProblem;
            }

            set { }
        }
    }
}
