using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace cbox.server.responses
{
    [DataContract]
    public class NewGameData
    {
        public NewGameData(int id)
        {
            session_id = id;
        }

        [DataMember]
        public int session_id { get; set; }
    }
}
