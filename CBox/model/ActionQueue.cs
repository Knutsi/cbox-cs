using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using System.IO;

namespace cbox.model
{
    [DataContract]
    public class ActionQueue
    {
        [DataMember]
        public List<ActionRequest> Entries = new List<ActionRequest>();


        public void Add(string key, string problem_ident)
        {
            var entry = new ActionRequest() { ActionIdent = key, ProblemIdent = problem_ident };
            this.Entries.Add(entry);
        }


        public void ImportAllFrom(ActionQueue additions) {

            foreach (ActionRequest import_entry in additions.Entries)
                this.Entries.Add(import_entry);
        }


        public static ActionQueue FromJSON(string json)
        {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var ser = new DataContractJsonSerializer(typeof(ActionQueue));
                ActionQueue result = (ActionQueue)ser.ReadObject(ms);

                return result;
            }
        }

    }
}
