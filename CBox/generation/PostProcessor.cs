using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.model;

namespace cbox.generation
{
    /// <summary>
    /// Class that does work on cases after they have been generated. 
    /// </summary>
    public class PostProcessor
    {
        public void Process(Case case_)
        {
            // process all steps:
            AddPreviousDx(case_);
        }


        /// <summary>
        /// Adds names of previous Dx as values in history.past-conditions.
        /// </summary>
        private void AddPreviousDx(Case case_)
        {
            var prev = from d in case_.Diagnosis
                       where d.Group == Diagnosis.PREVIOUS_GROUP
                       select d.Title;

            // did we get any results?
            if (prev.Count() > 0)
            {
                var result = new TestResult()
                {
                    Key = Case.KEY_PAST_CONDITIONS,
                    Values = prev.ToList()
                };

                case_.RootProblem.Add(result);
            }
        }
    }
}
