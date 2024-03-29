﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.model;

namespace cbox.generation.setter
{
    public class MultiRangeSetter : IValueSetter
    {
        Random Random;

        public static string Ident = "MRANGE";

        public MultiRangeSetter()
        {
            //this.Random = new Random();
            this.Random = Tools.Random;
        }

        public string Ident_
        {
            get { return MultiRangeSetter.Ident; }
        }


        /// <summary>
        /// The multi range setter reads the gender and age from the case, picks a range 
        /// that matches from the data, and generates a value from that range's span.
        /// </summary>
        public string Eval(string xml_data, ExecutionContext ctx, Test test)
        {
            // get the values we need:
            var age = double.Parse(ctx.Case.RootProblem["history.age"].Value);
            var gender = ctx.Case.RootProblem["history.gender"].Value;

            // get the data and find a mathcing range:
            var data = MultiRangeSetterData.FromXML(xml_data);
            if (data.Ranges.Count == 0)
                return string.Empty;    // no ranges, no results..

            var range = this.MatchRange(Convert.ToInt32(age), gender, data.Ranges);

            if (range == null)
                throw new Exception("No range found matching current age and gender");

            // generate the value:
            var value = range.Min + (this.Random.NextDouble() * (range.Max - range.Min));
            //value = Math.Round(value, 1);

            // round value:
            if (test != null)
                value = Math.Round(value, test.Decimals);
            else
                value = Math.Round(value);

            return value.ToString();

            
        }

        private MultiRangeSetterDataEntry MatchRange(int age, string gender, List<MultiRangeSetterDataEntry> list)
        {
            foreach (var entry in list)
                if ((entry.Gender == gender | entry.Gender == "B") && entry.AgeStart <= age && entry.AgeEnd >= age)
                    return entry;

            return null;
        }

        public string Describe(string xml_data, ExecutionContext ctx)
        {
            throw new NotImplementedException();
        }

        public string OutputDatatype
        {
            get { return "NUMBER";  }
        }
    }
}
