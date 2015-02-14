using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using System.IO;

namespace cbox.server
{
    [DataContract]
    public class ServerResponse
    {
        public string toJSON()
        {
            using (var mstream = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(this.GetType());

                ser.WriteObject(mstream, this);

                StreamReader reader = new StreamReader(mstream);
                mstream.Position = 0;
                return reader.ReadToEnd();
            }
        }
    }
}
