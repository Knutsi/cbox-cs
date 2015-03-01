using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.setter
{
    public class RangeSetter : IValueSetter
    {
        public static string Ident = "RANGE";
        public Random Random { get; set; }


        public RangeSetter()
        {
            Random = new Random();
        }

        public string Eval(string xml_data, ExecutionContext ctx)
        {
            var data = RangeSetterData.FromXML(xml_data);
            var value = data.Min + (this.Random.NextDouble() * (data.Max - data.Min));

            return value.ToString();
        }

        public string Describe(string data, ExecutionContext ctx)
        {
            throw new NotImplementedException();
        }
    }
}
