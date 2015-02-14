using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace cbox.model
{
    /// <summary>
    /// The Case class represents a medical case.  Answeres to tests are bundled inside 
    /// problems.  Problems have specific classes. 
    /// 
    /// Cases can be filtered to provide a reduced version that contains only anwsers 
    /// corresponding to the action requests the user has undertaken. 
    /// </summary>
    [DataContract]
    [Serializable]
    public class Case
    {
        public const string ROOT_PROBLEM_IDENT = "_root";

        [DataMember]
        public List<Problem> Problems = new List<Problem>();

        [DataMember]
        public Diagnosis Diagnosis { get; set; }

        [DataMember]
        public string Treatments { get; set; }

        public Case()
        {
            // create root problem:
            Problems.Add(new Problem() { Ident = ROOT_PROBLEM_IDENT });
        }

        public Problem this[string ident]
        {
            get { return problemWithIdent(ident); }
        }

        public Problem problemWithIdent(string ident) {
            var found = (from Problem prob in this.Problems
                         where prob.Ident == ident
                         select prob);

            if (found.Count() > 0)
                return found.First();
            else
                return null;
        }

        /// <summary>
        /// Makes a subset of the case that only includes test results who's key/problem combo exists in the
        /// action queue provided.  Problems only get included if they include at least a single key.
        /// Dx, Tx and followup is included if the proper flags are set when calling the function.
        /// </summary>
        /// <returns></returns>
        public Case makeSubset(TestList tests, Ontology ontology, bool dx=false, bool tx=false, bool followup=false)
        {
            var subcase = new Case();

            foreach (ActionRequest action in tests.Entries)
            {
                // get problem of this action (can be null - if so, set to root)
                var problem = this[action.ProblemIdent];
                if(action.ProblemIdent == null)
                    problem = this[ROOT_PROBLEM_IDENT];


                // does case have this entry?  If so, get it.  If not, ask ontology:
                var test_result = this[problem.Ident][action.ActionIdent];
                if(test_result != null)
                {
                    // do we also need to add the problem?
                    if(subcase[problem.Ident] == null)
                    {
                        var new_problem = new Problem() { 
                            Ident = problem.Ident, 
                            Title = problem.Title
                        };

                        subcase.Problems.Add(new_problem);
                    }

                    subcase[problem.Ident].add(test_result);
                } else {
                    /* if we get here, the case does not have an entry for this test result, so
                     * we will ask the ontology to generate one for us.  We can not add to problems
                     that does not exist in the case, so we first check if the case has the 
                     problem asked for (it should!) */

                    // *FIXME* make this work!!
                    var tr = new TestResult() { Key = action.ActionIdent, Value = "ONTOLOGY QUERY NOT IMPLEMENTED" };
                    subcase[ROOT_PROBLEM_IDENT].add(tr);
                }
            }


            return subcase;
        }

        public string toJSON() {
            using (var mstream = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Case));

                ser.WriteObject(mstream, this);
                
                StreamReader reader = new StreamReader(mstream);
                mstream.Position = 0;
                return reader.ReadToEnd();
            }
        }
        
    }
}
