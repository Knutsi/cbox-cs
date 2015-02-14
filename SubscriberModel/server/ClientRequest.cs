using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using System.IO;

namespace cbox.server
{
    [DataContract]
    public class ClientRequest
    {
        [DataMember]
        public string SessionID { get; set; }

        [DataMember]
        public string GameID { get; set; }

        [DataMember]
        public string Action { get; set; }

        [DataMember]
        public string Data { get; set; }


        internal static ClientRequest fromString(string body)
        {
            if (body != string.Empty)
            {
                using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(body)))
                {
                    var ser = new DataContractJsonSerializer(typeof(ClientRequest));
                    ClientRequest result = (ClientRequest)ser.ReadObject(ms);

                    return result;
                }
            }
            else
                return null;

        }
    }
}
