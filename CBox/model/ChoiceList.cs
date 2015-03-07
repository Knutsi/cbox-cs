using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.model
{
    /// <summary>
    /// A choice list holds a list of possible values for a test result.  Examples of this
    /// can be "male", "female" for history.gender, or "positive", "negative" for 
    /// "study.urea-breath" and many more. 
    /// </summary>
    public class ChoiceList : List<string>
    {
        public string Ident { get; set; }
        //public List<string> Choices { get; set; }
    }
}
