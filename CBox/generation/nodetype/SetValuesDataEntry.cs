using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.generation;

namespace cbox.generation.nodetype
{
    public class SetValuesDataEntry
    {
        public string Key { get; set; }
        public string SetterIdent { get; set; }
        public string SetterXmlData { get; set; }
        public TestResultConflictPolicy ConflictPolicy = TestResultConflictPolicy.DEFAULT;


        public SetValuesDataEntry Clone()
        {
            return new SetValuesDataEntry()
            {
                Key = Key,
                SetterIdent = SetterIdent,
                SetterXmlData = SetterXmlData,
                ConflictPolicy = ConflictPolicy
            };
        }
    }
}
