using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace cbox.model
{
    [Serializable]
    [DataContract]
    public class TreatmentCatalogEntry
    {
        [DataMember]
        public string Ident;

        [DataMember]
        public string Class;

        [DataMember]
        public string Title;

        [DataMember]
        public List<String> Modifiers = new List<string>();
        
    }
}
