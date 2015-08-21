using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.setter
{
    public class TextDerivatSetter : IValueSetter
    {
        public static string Ident = "TDERIVAT";

        

        public string Describe(string xml_data, ExecutionContext ctx)
        {
            throw new NotImplementedException();
        }

        public string Eval(string xml_data, ExecutionContext ctx)
        {
            return "(not immplemented)";
        }

        public string Ident_ { get { return TextDerivatSetter.Ident; }}
        public string OutputDatatype { get { return "TEXT"; } }
    }
}
