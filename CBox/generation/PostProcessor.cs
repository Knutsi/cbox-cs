using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.model;
using cbox.scoretree;

namespace cbox.generation
{
    /// <summary>
    /// Class that does work on cases after they have been generated. 
    /// </summary>
    public class PostProcessor
    {
        public void Process(Case case_, Ontology ontology)
        {
            // process all steps:
            MergeEqualProblems(case_);
            //MergeScoreTreeGroups(case_);
            ClearNonAcumulativeValues(case_, ontology);
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
        /// Walls the score tree consequence nodes, and merges the "higest of" and "sum" nodes with same group names.
        /// </summary>
        /// <param name="case_"></param>
        private void MergeScoreTreeGroups(Case case_)
        {
            var to_remove = new List<ConsequenceNode>();

            // grab "sum of" or "highest" nodes:
            var sum_or_high_modes = from n in case_.ScoreTree
                                    where n.Consequence == ConsequenceNode.TYPE_HIGEST_OF 
                                    || n.Consequence == ConsequenceNode.TYPE_SUM_OF
                                    && n.Group != null
                                    && n.Group != string.Empty
                                    select n;

            foreach (var cqnode in sum_or_high_modes)
            {
                // skip if already processed:
                if (to_remove.Contains(cqnode))
                    continue;

                // get nodes in tree with same group that is not us:
                var in_same_group = from n in sum_or_high_modes
                                    where n != cqnode && n.Group == cqnode.Group 
                                    select n;

                // mode children to cqnode, then assign to be removed:
                foreach (var same_group_node in in_same_group)
                {
                    cqnode.Children.AddRange(same_group_node.Children);
                    to_remove.Add(same_group_node);
                }
            }

            // remove nodes to remove:
            foreach (var node in to_remove)
                case_.ScoreTree.Remove(node);

        }


        /// <summary>
        /// Looks for multi-value results that are not acululative, and clears all but last value.
        /// </summary>
        /// <param name="case_"></param>
        public void ClearNonAcumulativeValues(Case case_, Ontology ontology)
        {
            foreach (var problem in case_.Problems)
            {
                foreach (var result in problem.TestResults)
                {
                    var test = ontology.TestByKey(result.Key);
                    if(result.Values.Count > 1 && !test.Accumulative)
                    {
                        // values are stored in the order they are added, so we can keep the last only:
                        var value = result.Values.Last();
                        result.Values = new List<string>();
                        result.Values.Add(value);
                    }
                }
            }
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
