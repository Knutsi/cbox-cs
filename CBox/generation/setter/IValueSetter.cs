using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.generation;

namespace cbox.generation.setter
{
    public interface IValueSetter
    {
        string Ident_ { get; }

        string Eval(string xml_data, ExecutionContext ctx);
        string Describe(string xml_data, ExecutionContext ctx);

        string OutputDatatype { get; }
    }
}
