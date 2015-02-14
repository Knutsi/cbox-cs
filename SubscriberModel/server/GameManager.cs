using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.server
{
    /// <summary>
    /// The game manager holds a series of game sessions and handles requests.
    /// </summary>
    public class GameManager
    {
        List<Game> Sessions = new List<Game>();

        int _GameID = 0;
        public string NextGameID { get { _GameID += 1; return _GameID.ToString(); } }
        

        public string HandleRequest(ClientRequest request) 
        {
            switch (request.Action)
            {
                case "new_game":
                    return NewSession();

                default:
                    throw new Exception("Could not parse action: " + request.Action);
            }

        }

        string NewSession()
        {
            var session = new Game() { ID = NextGameID };
            Console.WriteLine("Game created #" + session.ID);

            var response = new ActionConsequenceResponse()
            {
                GameID = session.ID
            };

            return response.toJSON();
        }


        
    }
}
