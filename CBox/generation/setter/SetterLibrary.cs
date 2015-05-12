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
            // range setter:
            var range_setter = new RangeSetter();
            this[RangeSetter.Ident] = range_setter;

            // multirange-setter:
            var mrange_setter = new RangeSetter();
            this["MRANGE"] = mrange_setter;

            // string setter:
            var string_setter = new StringSetter();
            this[StringSetter.Ident] = string_setter;

            // choice setter:
            var choice_setter = new ChoiceSetter();
            this[ChoiceSetter.Ident] = choice_setter;
        }

        public IValueSetter SetterByIdent(string ident)
        {
            if (this.Keys.Contains(ident))
                return this[ident];
            else
                return null;
        }

        /// <summary>
        /// Returns a list of setters that can provde the given datatype.
        /// </summary>
        /// <param name="datatype"></param>
        /// <returns></returns>
        public List<IValueSetter> SettersByDatatype(string datatype)
        {
            var setters = new List<IValueSetter>();

            foreach (var kvp in this)
            {
                if (kvp.Value.OutputDatatype == datatype)
                    setters.Add(kvp.Value);
            }

            return setters;
        }
    }
}
