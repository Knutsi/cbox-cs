using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace BatchExporter
{
    [DataContract]
    public class ExportManifesto
    {
        [DataMember]
        public int CaseCount { get; set; }

        [DataMember]
        public List<ExportManifestoEntry> Cases = new List<ExportManifestoEntry>();

        public string toJSON()
        {
            using (var mstream = new MemoryStream())
            {
                var settings = new DataContractJsonSerializerSettings() { UseSimpleDictionaryFormat = true };
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ExportManifesto), settings);

                ser.WriteObject(mstream, this);

                StreamReader reader = new StreamReader(mstream);
                mstream.Position = 0;
                return reader.ReadToEnd();
            }
        }
    }
}
