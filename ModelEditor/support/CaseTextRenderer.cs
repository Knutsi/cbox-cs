using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.model;

namespace ModelEditor.support
{
    static class CaseRenderer
    {
        public static string RenderCase(Case case_, Ontology ontology)
        {
            var builder = new StringBuilder();

            // name, gender, age:
            builder.AppendFormat(
                "{0}, {1} {2}. {3}.", 
                case_.RootProblem["history.name"],
                case_.RootProblem["history.gender"],
                case_.RootProblem["history.age"],
                case_.RootProblem["history.presenting-complaint"]);

            // complaints:
            var problem_titles = from p in case_.Problems
                                 select string.Format("({0}) {1}", p.PeerNumber, p.Title);

            builder.AppendFormat("{0}. {1}{2}", 
                string.Join(",", problem_titles),
                Environment.NewLine, 
                Environment.NewLine);

            // render root problem, then details for each problem:
            var history = string.Join(".", from tr in GetResultsByKeyStartingWith(case_.RootProblem, "history.")
                                           select tr.ToString(ontology));

            var clinex = string.Join(".", from tr in GetResultsByKeyStartingWith(case_.RootProblem, "clinex.")
                                              select tr.ToString(ontology));

            var lab = string.Join(".", from tr in GetResultsByKeyStartingWith(case_.RootProblem, "lab.")
                                       select tr.ToString(ontology));


            var study = string.Join(".", from tr in GetResultsByKeyStartingWith(case_.RootProblem, "study.")
                                       select tr.ToString(ontology));


            return builder.ToString();
        }


        public static List<TestResult> GetResultsByKeyStartingWith(Problem prob, string pattern, List<string>skiplist=null)
        {
            var results = new List<TestResult>();

            if (skiplist == null)
                skiplist = new List<string>();

            foreach (var test_result in prob.TestResults)
                if (test_result.Key.StartsWith(pattern) && !skiplist.Contains(test_result.Key))
                    results.Add(test_result);

            return results;
        }
    }
}
