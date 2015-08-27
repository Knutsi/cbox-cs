using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.ComponentModel;

namespace cbox.model
{
    public class FollowupQuestionAnswer
    {
        public string Text { get; set; }
        public bool Correct { get; set; }

        public FollowupQuestionAnswer()
        {
            Text = "Answer here";
            Correct = true;
        }
    }
}
