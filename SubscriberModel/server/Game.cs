using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.model;

namespace cbox.server
{
    public class Game
    {
        public string ID;
        public ActionQueue ActionsTaken { get; set; }
        public Case Case { get; set; }

        public Game()
        {
            ActionsTaken = new ActionQueue();
            this.Case = new Case(); // default to empty case;
        }

        /// <summary>
        /// Scorecard that gets automatically generated based on the action queue.
        /// </summary>
        public Scorecard Scorecard {
            get
            {
                return new Scorecard(); // *FIXME!*

            }
        }
    }
}
