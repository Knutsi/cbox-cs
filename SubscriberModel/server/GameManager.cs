using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.model;

namespace cbox.server
{
    /// <summary>
    /// The game manager holds a series of game sessions and handles requests.
    /// </summary>
    public class GameManager
    {
        Dictionary<string, Game> Games = new Dictionary<string, Game>();

        int _GameID = 0;
        public string NextGameID { get { _GameID += 1; return _GameID.ToString(); } }
        

        public string HandleRequest(ClientRequest request) 
        {
            switch (request.Action)
            {
                case "new_game":
                    return NewSession();

                case "commit_actions":
                    return CommitActions(request);

                case "commit_dnt":
                    return CommitDnT(request);

                case "commit_followup":
                    return CommitFollowup(request);

                default:
                    throw new Exception("Could not parse action: " + request.Action);
            }

        }


        private Case GetDummyCase()
        {
            var test_case = new cbox.model.Case();

            var crp = new cbox.model.TestResult() { Key = "vblood.crp", Value = "183" };
            var sr = new cbox.model.TestResult() { Key = "vblood.sr", Value = "5" };
            var age = new cbox.model.TestResult() { Key = "history.age", Value = "33" };
            var name = new cbox.model.TestResult() { Key = "history.name", Value = "Raquet Badminton" };
            var gender = new cbox.model.TestResult() { Key = "history.gender", Value = "F" };

            test_case[Case.ROOT_PROBLEM_IDENT].add(new cbox.model.TestResult[] { crp, sr, age, name, gender });

            return test_case;
        }

       
        /// <summary>
        /// Handles "new_game" action.  Will generate a new game, and return the first response.
        /// </summary>
        /// <returns></returns>
        string NewSession()
        {
            var game = new Game() { ID = NextGameID, Case = GetDummyCase() };
            Games[game.ID] = game;

            Console.WriteLine("Game created #" + game.ID);

            // initial values:
            var start_queue = new ActionQueue();
            start_queue.Add("history.age", null);
            start_queue.Add("history.gender", null);
            start_queue.Add("history.name", null);
            

            var response = new ActionConsequenceResponse() 
            { 
                GameID = game.ID, 
                Case = game.Case.makeSubset(start_queue, null), 
                Scorecard = game.Scorecard,
                FirstAction = true };



            return response.toJSON();
        }


        private string CommitActions(ClientRequest request)
        {
            // get current game and create the response:
            var game = Games[request.GameID];
            var response = new ActionConsequenceResponse() { GameID = game.ID, FirstAction = false };

            // try to parse the data as an ActionQueue object, and add these to our queue:
            var client_actions = ActionQueue.FromJSON(request.Data);
            game.ActionsTaken.ImportAllFrom(client_actions);

            // get an updated case to send the user:
            //response.Case = game.Case.makeSubset(game.ActionsTaken, null);

            // update scorecard:
            response.Scorecard = game.Scorecard;

            return response.toJSON();
        }


        private string CommitDnT(ClientRequest request)
        {
            throw new NotImplementedException();
        }


        private string CommitFollowup(ClientRequest request)
        {
            throw new NotImplementedException();
        }



        
    }
}
