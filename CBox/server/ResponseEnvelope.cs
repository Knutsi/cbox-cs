using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace cbox.server
{
    /// <summary>
    /// Outer envelope used to wrap responses to the client.  Useful for adding response metadata.
    /// </summary>
    [DataContract]
    public class ResponseEnvelope<T>
    {
        [DataMember]
        public string type { get; set; }

        [DataMember]
        public T data { get; set; }

        public string ToJSON()
        {
            using (var mstream = new MemoryStream())
            {
                var settings = new DataContractJsonSerializerSettings() { UseSimpleDictionaryFormat = true };
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ResponseEnvelope<T>), settings);

                ser.WriteObject(mstream, this);

                StreamReader reader = new StreamReader(mstream);
                mstream.Position = 0;
                return reader.ReadToEnd();
            }
        }
    }
}
