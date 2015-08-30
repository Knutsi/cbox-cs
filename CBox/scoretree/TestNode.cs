using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.model;

namespace cbox.scoretree
{
    public class TestNode : LogicNode
    {
        public string Key { get; set; }
        public string Title { get; set; }

        public TestNode()
        {
            Type = "TestNode";
            Key = "key.empty";
            Title = "<Title>";
        }

        public override string displayName
        {
            get
            {
                return Key + " [" + Title + "]";
            }
        }

        public override bool Eval()
        {
            var tests = from t in Objects
                        where t.GetType() == typeof(Test) && (t as Test).Key == Key
                        select t;

            return tests.Count() > 0;
        }

    }
}
