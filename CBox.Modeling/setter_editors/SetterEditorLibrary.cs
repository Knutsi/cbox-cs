using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.generation.setter;

namespace cbox.modelling.setter_editors
{
    public static class SetterEditorLibrary
    {
        public static ISetterEditor GetEditor(string ident) 
        {

            switch (ident)
            {
                case RangeSetter.Ident:
                    return new RangeEditor();

                case StringSetter.Ident:
                    return new StringEditor();

                default:
                    return null;
            }
        }
    }
}
