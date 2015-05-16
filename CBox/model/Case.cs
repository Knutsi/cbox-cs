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
using System.Xml;

namespace cbox.model
{
    /// <summary>
    /// The Case class represents a medical case.  Answers to tests are bundled inside 
    /// problems.  Problems have specific classes. 
    /// 
    /// Cases can be filtered to provide a reduced version that contains only anwsers 
    /// corresponding to the action requests the user has undertaken. 
    /// </summary>
    [DataContract]
    [Serializable]
    public class Case
    {
        [DataMember]
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
            this.AddProblem(new Problem()
            {
                Ident = ROOT_PROBLEM_IDENT,
                Classes = new List<string> { "General" }
            });
        }

        [XmlIgnore]
        public Problem this[string ident]
        {
            get { return problemWithIdent(ident); }
        }

        /// <summary>
        /// The problem that unbound nodes adds their values to.
        /// </summary>
        [XmlIgnore]
        public Problem RootProblem
        {
            get
            {
                return this[ROOT_PROBLEM_IDENT];
            }
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
        public Case makeSubset(ActionQueue tests, Ontology ontology, bool dx=false, bool tx=false, bool followup=false)
        {
            /* FIXME! The client should look up tests in ontology! */

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

                    subcase[problem.Ident].Add(test_result);
                } else {
                    /* if we get here, the case does not have an entry for this test result, so
                     * we will ask the ontology to generate one for us.  We can not add to problems
                     that does not exist in the case, so we first check if the case has the 
                     problem asked for (it should!) */

                    // *FIXME* make this work!!
                    var tr = new TestResult() { Key = action.ActionIdent, Value = "ONTOLOGY QUERY NOT IMPLEMENTED" };
                    subcase[ROOT_PROBLEM_IDENT].Add(tr);
                }
            }


            return subcase;
        }

        /// <summary>
        /// Translates the case to JSON formatted string.
        /// </summary>
        /// <returns></returns>
        public string toJSON() {
            using (var mstream = new MemoryStream())
            {
                var settings = new DataContractJsonSerializerSettings() { UseSimpleDictionaryFormat = true };
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Case), settings);

                ser.WriteObject(mstream, this);
                
                StreamReader reader = new StreamReader(mstream);
                mstream.Position = 0;
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Translates a JSON-formated string to a case.
        /// </summary>
        /// <returns></returns>
        public static Case FromJSON(string json)
        {
            var ser = new DataContractJsonSerializer(typeof(Case));
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            var case_ = (Case)ser.ReadObject(stream);

            case_.UpdateInternalReferences();

            return case_;
        }

        /// <summary>
        /// Fixes references after serialziation.
        /// </summary>
        internal void UpdateInternalReferences() 
        {
            foreach (var prob in this.Problems)
                prob.ParentCase = this;
        }



        public void AddProblem(Problem problem)
        {
            this.Problems.Add(problem);
            problem.ParentCase = this;
        }

        /// <summary>
        /// Creates a deep copy of the case.
        /// </summary>
        /// <returns></returns>
        public Case Clone()
        {
            var json = this.toJSON();
            return Case.FromJSON(json);
        }

        /// <summary>
        /// Looks up values for the action-problem-pairs provided, and adds them to the case
        /// given. 
        /// </summary>
        /// <param name="case_"></param>
        /// <param name="Expantions"></param>
        public void Expand(List<ActionProblemPair> ap_pairs, Ontology ontology)
        {
            foreach (var ap_pair in ap_pairs)
            {
                // get the current action and problem:
                var problem = this.problemWithIdent(ap_pair.ProblemIdent);
                var action = ontology.ActionByIdent(ap_pair.ActionIdent);

                // get keys 
                var keys = action.Yield.ToList();

                // look up each key in ontology, add result to current problem:
                foreach (var key in keys)
                {
                    //problem.Add(new TestResult() { Key = key, Value = "Expanded!" });
                    var result = ontology.Lookup(key, this, problem);
                    problem.Add(result);
                }
            }
        }


    }
}
