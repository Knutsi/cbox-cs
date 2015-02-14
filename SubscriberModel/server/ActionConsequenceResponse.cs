using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using cbox.model;

namespace cbox.server
{
    [DataContract]
    public class ActionConsequenceResponse: ServerResponse
    {
        [DataMember]
        public string GameID;

        [DataMember]
        public Case Case = new Case();

        [DataMember]
        public Scorecard Scorecard = new Scorecard();

        [DataMember]
        public bool FirstAction { get; set; }

        public ActionConsequenceResponse()
        {
            FirstAction = false;
        }
    }
}
