using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.scoretree
{
    public class Result
    {
        public int Score { get; set; }
        public int MaxScore { get; set; }
        
        public string ScoreExplanation { get; set; }
        public List<string> Comments { get; set; }
        public bool Failed { get; set; }

        public Result()
        {
            Comments = new List<string>();
        }
        public int Percentage { get { return (Score / MaxScore) * 100; } }

    }
}

