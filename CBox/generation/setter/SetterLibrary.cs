using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.setter
{
    public class SetterLibrary : Dictionary<string, IValueSetter>
    {
        public static SetterLibrary Default = new SetterLibrary();

        public SetterLibrary()
        {
            // range stter:
            var range_setter = new RangeSetter();
            this[RangeSetter.Ident] = range_setter;

            var string_setter = new StringSetter();
            this[StringSetter.Ident] = string_setter;
        }
    }
}
