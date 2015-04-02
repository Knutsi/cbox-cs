using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.setter
{
    public class StringSetter : IValueSetter
    {
        public static string Ident = "STRING"; 
        public Random Random;

        public StringSetter ()
	    {
            this.Random = new Random();
	    }

        public string Eval(string xml_data, ExecutionContext ctx)
        {
            var data = StringSetterData.FromXML(xml_data);

            // pick a random string:
            int i = this.Random.Next(data.Strings.Count);
            var str = data.Strings[i];

            // expand using thesaurus:
            foreach (var entry in data.Thesaurus)
            {
                var to_replace = "{" + entry.Word + "}";

                var j = this.Random.Next(data.Strings.Count);
                var replacement = entry.Synonyms[j];

                str = str.Replace(to_replace, replacement);
            }

            return str;
        }

        public string Describe(string xml_data, ExecutionContext ctx)
        {
            throw new NotImplementedException();
        }

        public string OutputDatatype { get { return "TEXT"; } }

        public string Ident_
        {
            get { return StringSetter.Ident; }
        }
    }
}
