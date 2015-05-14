using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.setter
{
    /// <summary>
    /// Choice setters take a list of possible values, and picks one of them.
    /// </summary>
    public class ChoiceSetter : IValueSetter
    {
        Random Random = new Random();

        public static string Ident = "CHOICE";

        public string Eval(string xml_data, ExecutionContext ctx)
        {
            var data = ChoiceSetterData.FromXML(xml_data);

            // ensure we at least have a choice list:
            if (data.Choices == null)
                throw new Exception("ChoiceSetterData with no source list set");

            // pick a value from the choices:
            if (data.Choices.Count == 1)
                return data.Choices.First();
            else if(data.Choices.Count > 1)
                return data.Choices[this.Random.Next(data.Choices.Count)];
            else
            {
                // if no choices, pick directly from list:
                var choices = ctx.System.Ontology.GetChoiceListByIdent(data.SourceListIdent);
                return choices[this.Random.Next(choices.Count)];
            }
        }

        public string Describe(string xml_data, ExecutionContext ctx)
        {
            throw new NotImplementedException();
        }


        public string OutputDatatype { get { return "TEXT"; } }

        public string Ident_
        {
            get { return ChoiceSetter.Ident; }
        }
    }
}
