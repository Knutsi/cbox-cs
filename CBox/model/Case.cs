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
        [DataMember]
        public List<Problem> Problems = new List<Problem>();

        [DataMember]
        public Diagnosis Diagnosis { get; set; }

        [DataMember]
        public string Treatments { get; set; }

        public Case()
        {
            // create root problem:
            Problems.Add(new Problem() { Ident = "_root" });
        }

        public Problem this[string ident]
        {
            get { return problemWithIdent(ident); }
            //set { ultraTree[index] = value; }
        }

        public Problem problemWithIdent(string ident) {
            return (from Problem prob in this.Problems
                   where prob.Ident == ident
                   select prob).First();
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
