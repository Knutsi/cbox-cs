using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.generation.setter;
using cbox.model;

namespace cbox.generation.setter
{
    public class RangeSetter : IValueSetter
    {
        public const string Ident = "RANGE";
        public Random Random { get; set; }


        public RangeSetter()
        {
            //Random = new Random();
            Random = Tools.Random;
        }

        public string Eval(string xml_data, ExecutionContext ctx, Test test)
        {
            var data = RangeSetterData.FromXML(xml_data);
            var value = data.Min + (this.Random.NextDouble() * (data.Max - data.Min));
            //var value = Tools.Random.NextDouble

            // round value:
            if (test != null)
                value = Math.Round(value, test.Decimals);
            else
                value = Math.Round(value);

            return value.ToString();
        }

        public string Describe(string data, ExecutionContext ctx)
        {
            throw new NotImplementedException();
        }

        public string OutputDatatype { get { return "NUMBER"; } }
        public string Ident_
        {
            get { return RangeSetter.Ident; }
        }
    }
}
