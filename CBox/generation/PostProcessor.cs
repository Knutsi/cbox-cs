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
            PickFollowup(case_);
        }


        /// <summary>
        /// Adds names of previous Dx as values in history.past-conditions.
        /// </summary>
        private void AddPreviousDx(Case case_)
        {
            var prev_dx = from d in case_.Diagnosis
                       where d.Group == Diagnosis.PREVIOUS_GROUP
                       select d;

            var prev_titles = from d in prev_dx select d.Title;

            // did we get any results?
            if (prev_titles.Count() > 0)
            {
                var result = new TestResult()
                {
                    Key = Case.KEY_PAST_CONDITIONS,
                    Values = prev_titles.ToList()
                };

                case_.RootProblem.Add(result);
            }

            // remove those dx from case:
            foreach (var dx in prev_dx.ToArray())
            {
                case_.Diagnosis.Remove(dx);
            }
        }


        /// <summary>
        /// Chooses randomly a single followup-quesiton from all available.
        /// </summary>
        /// <param name="case_"></param>
        private void PickFollowup(Case case_)
        {
            var chosen = case_.Followup[Tools.Random.Next(case_.Followup.Count)];
            case_.Followup = new List<FollowupQuestion>();
            case_.Followup.Add(chosen);
        }
    }
}
