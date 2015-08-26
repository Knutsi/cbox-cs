using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace cbox.model
{

    /// <summary>
    /// Represents a diagnosis in a case.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Diagnosis
    {
        public static string DEFAULT_GROUP_NAME = "DEFAULT";
        public static string PREVIOUS_GROUP = "PREVIOUS";

        private string Group_ = Diagnosis.DEFAULT_GROUP_NAME;

        [DataMember]
        public string Group
        {
            get {  return Group_; } 
            set
            {
                if (value.Trim() == string.Empty)
                    Group_ = Diagnosis.DEFAULT_GROUP_NAME;  // this field cannot have empty names
                else
                    Group_ = value;
            }
        }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public bool Major { get; set; }

        [DataMember]
        public bool Specific { get; set; }

        [DataMember]
        public string MissComment { get; set; }

        public Diagnosis()
        {
            Group = Diagnosis.DEFAULT_GROUP_NAME;
            Code = "XXX";
            Title = "Unset diagnosis";
            Major = true;
            Specific = true;
            MissComment = String.Empty;
        }
    }
}
