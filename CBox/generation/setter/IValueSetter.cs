using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.generation;
using cbox.model;

namespace cbox.generation.setter
{
    public interface IValueSetter
    {
        string Ident_ { get; }

        string Eval(string xml_data, ExecutionContext ctx, Test test);
        string Describe(string xml_data, ExecutionContext ctx);

        string OutputDatatype { get; }
    }
}
