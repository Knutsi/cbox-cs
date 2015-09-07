using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.model;

namespace cbox.generation.setter
{
    public class MultiStringSetter : IValueSetter
    {
        Random Random;

        public static string Ident = "MSTRING";


        public string Ident_
        {
            get { return MultiRangeSetter.Ident; }
        }


        /// <summary>
        /// The multi range setter reads the gender and age from the case, picks a range 
        /// that matches from the data, and returns it's value.
        /// </summary>
        public string Eval(string xml_data, ExecutionContext ctx, Test test)
        {
            // get the values we need:
            var age = double.Parse(ctx.Case.RootProblem["history.age"].Value);
            var gender = ctx.Case.RootProblem["history.gender"].Value;

            // get the data and find a mathcing range:
            var data = MultiStringSetterData.FromXML(xml_data);
            if (data.Ranges.Count == 0)
                return string.Empty;    // no ranges, no results..

            var range = this.RandomMatchRange(Convert.ToInt32(age), gender, data.Ranges);

            if (range == null)
                throw new Exception("No range found matching current age and gender");

            return range.Value;
        }

        private MultiStringSetterDataEntry RandomMatchRange(int age, string gender, List<MultiStringSetterDataEntry> list)
        {
            var matching = from r in list
                           where (r.Gender == gender | r.Gender == "B") && r.AgeStart <= age && r.AgeEnd >= age
                           select r;

            if (matching.Count() > 0)
                return Tools.PickRandom<MultiStringSetterDataEntry>(matching.ToList());
            else
                return null;
        }

        public string Describe(string xml_data, ExecutionContext ctx)
        {
            throw new NotImplementedException();
        }

        public string OutputDatatype
        {
            get { return "TEXT"; }
        }
    }
}
