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
            MergeEqualProblems(case_);
            AddPreviousDx(case_);
            PickFollowup(case_);

        }


        /// <summary>
        /// Merges problems with the same name.
        /// </summary>
        private void MergeEqualProblems(Case case_)
        {
            var to_remove = new List<Problem>();
            foreach (var problem in case_.Problems)
            {
                // if we have already merged, skip:
                if (to_remove.Contains(problem))
                    continue;

                // look for other problems with same name:
                var equals = from p in case_.Problems
                             where p != problem && p.Title == problem.Title && !to_remove.Contains(p)
                             select p;

                // for each equal problem found that is not already in remove list, add out values:
                // also, add all classes:
                foreach (var equal in equals)
                {
                    var new_classes = from c in equal.Classes where !problem.Classes.Contains(c) select c;
                    problem.Classes.AddRange(new_classes);

                    foreach (var result in equal.TestResults)
                        problem.Add(result);

                }

                to_remove.AddRange(equals);
            }

            // remove problems no longer needed:
            foreach (var removee in to_remove)
                case_.Problems.Remove(removee);
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
            if (case_.Followup.Count > 0)
            {
                var chosen = case_.Followup[Tools.Random.Next(case_.Followup.Count)];
                case_.Followup = new List<FollowupQuestion>();
                case_.Followup.Add(chosen);
            }
        }
    }
}
