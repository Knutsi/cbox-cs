using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.model;

namespace cbox.scoretree
{
    public class TreatmentNode : LogicNode
    {
        public string Ident;
        public string Name = "<Rx here>";

        public TreatmentNode()
        {
            Type = "TreatmentNode"; // for javascript to find on the other side
        }

        override public string displayName
        {
            get { return Name; }
        }

        public override bool Eval()
        {
            var tests = from t in Objects
                        where t.GetType() == typeof(TreatmentCatalogEntry) && (t as TreatmentCatalogEntry).Ident == Ident
                        select t;

            return tests.Count() > 0;
        }
    }
}
