using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.model;

namespace cbox.scoretree
{
    public class DiagnosisNode : LogicNode
    {
        public string Code = "XXX";
        public string Name = "<Dx here>";

        public DiagnosisNode()
        {
            Type = "DiagnosisNode";   // for javascript to find on the other side
        }

        override public string displayName
        {
            get { return string.Format("{1} ({0})", Code, Name); }
        }

        public override bool Eval()
        {
            var tests = from t in Objects
                        where t.GetType() == typeof(DiagnosisCatalogEntry) && (t as DiagnosisCatalogEntry).Code == Code
                        select t;

            return tests.Count() > 0;
        }
    }
}
