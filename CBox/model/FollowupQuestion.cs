using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace cbox.model
{
    public class FollowupQuestion : INotifyPropertyChanged
    {
        public const string TYPE_SINGLE_CHOICE = "TYPE_SINGLE_CHOICE";
        public const string TYPE_MULTIPLE_CHOICE = "TYPE_MULTIPLE_CHOICE";

        private string Question_;
        
        public string Type { get; set; }
        public BindingList<FollowupQuestionAnswer> Answers = new BindingList<FollowupQuestionAnswer>();

        public event PropertyChangedEventHandler PropertyChanged;

        public FollowupQuestion()
        {
            Question = "Enter question";
            Type = TYPE_SINGLE_CHOICE;
        }

        
        public string Question
        {
            get { return Question_; }
            set
            {
                Question_ = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Question"));
            }

        }
    }
}
