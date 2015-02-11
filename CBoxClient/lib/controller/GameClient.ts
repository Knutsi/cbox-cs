

module cbox.client {

    /* The various states the game passes through.  Bascally, the game is a very linear
    state machine which moces to "TAKING_ACTIONS", and then cycles back and forth between
    that state and "AWAIT_ACTION_CONSEQUENCE" until the player is ready to diagnose and
    threat at which point it returns to the linearity.  The sequence follows what is 
    declared here. */
    export class GameClientState {
        public static UNINITIALIZED = "UNINITIALIZED";
        public static AWAIT_CLIENTPACKAGE = "AWAIT_CLIENTPACKAGE"
        public static READY = "READY"
        public static AWAIT_CASE = "AWAIT_CASE"
        public static TAKING_ACTIONS = "TAKING_ACTIONS"
        public static AWAIT_ACTION_CONSEQUENCE = "AWAIT_ACTION_CONSEQUENCE"
        public static AWAIT_SCORE_AND_FOLLOWUP = "AWAIT_SCORE_AND_FOLLOWUP"
        public static FOLLOWUP = "FOLLOWUP"
        public static AWAIT_FOLLOWUP_RESULT = "AWAIT_FOLLOWUP_RESULT";
        public static DONE = "DONE"
    }

    export class ServerMessages {
        public static START_GAME = "START_GAME";
        public static COMMIT_ACTIONS = "COMMIT_ACTIONS";
        public static DIGNOSE_AND_TREAT = "DIGNOSE_AND_TREAT";
    }

    // event classes:
    export class ClientPackageLoadedEvent { }

    export class GameStateChangeEvent {
        constructor(f, t) { this.from = f; this.to = t; }
        from: GameClientState;
        to: GameClientState;
    }

    export class FatalErrorEvent { }

    // exceptions:
    export class StateSequenceException { };


    /* Class that encapsulates all game client logic, and talks with the server.  It holds
    an internal state that can be monitored by subscribing to the OnStateChange event
    and controlls can use this to respond to the state of the game at any given moment.
    This class will typically be instance by the page controller. */
    export class GameClient {

        // internal state members:
        public service_url: string; // root of the URLs to communicate w/server
        private state_: GameClientState = GameClientState.UNINITIALIZED;    // what the game is doing now
        public client_package: ClientPackage;   // assets neede to play
        //public case_: Case;

        // events:
        public onStateChange: Event<GameStateChangeEvent> = new Event<GameStateChangeEvent>();
        public onFatalError: Event<FatalErrorEvent> = new Event<FatalErrorEvent>();

        public onLoadStarted: Event<EmptyEvent> = new Event<EmptyEvent>();
        public onClientPackageLoaded: Event<ClientPackageLoadedEvent> = new Event<ClientPackageLoadedEvent>();
        public onGameStart: Event<EmptyEvent> = new Event<EmptyEvent>();

        public onActionsRequested: Event<EmptyEvent> = new Event<EmptyEvent>();
        public onActionConsequenceRecieved: Event<EmptyEvent> = new Event<EmptyEvent>();

        public onDnTSendt: Event<EmptyEvent> = new Event<EmptyEvent>();
        public onScoreReceived: Event<EmptyEvent> = new Event<EmptyEvent>();

        public onFollowupReceived: Event<EmptyEvent> = new Event<EmptyEvent>();
        public onFolloupSendt: Event<EmptyEvent> = new Event<EmptyEvent>();

        public onDone: Event<EmptyEvent> = new Event<EmptyEvent>();

        constructor(service_url: string) {
            this.service_url = service_url;
            log.msg("GameClient initiliazed");
        }


        /* Gets the curreny state */
        get state():GameClientState {
            return this.state_;
        }


        /* Sets the curreny state, and will cause the state change event to fire. */
        set state(new_state: GameClientState) {
            var old_state = this.state_;
            this.state_ = new_state;

            this.onStateChange.fire(new GameStateChangeEvent(old_state, new_state));
            log.msg("GameClient state: " + old_state + " -> " + new_state)
        }

        

        /* (S1) Starts the client (will load client package first), then set client to state
        READY which indicates the gane is ready for play. */
        startLoading() {
            // *TODO* start client package load:
            this.state = GameClientState.AWAIT_CLIENTPACKAGE;
            this.loadClientPackage();
        }


        /* (S2) Loads the client package from remote server */
        loadClientPackage() { 
            this.onLoadStarted.fire(new Event<EmptyEvent>());
            var cpUrl = this.service_url + "clipack";;

            var req = new XMLHttpRequest();
            req.open("GET", cpUrl, true);

            req.onreadystatechange = () => {
                if (req.status == 200 && req.readyState == 4) {
                    log.msg("Client package recieved from " + cpUrl);

                    var obj = JSON.parse(req.responseText);
                    this.client_package = ClientPackage.fromObject(obj);

                    this.state = GameClientState.READY;
                    this.onClientPackageLoaded.fire(new ClientPackageLoadedEvent());

                }
                else if (req.readyState == 4) {
                    log.err("Could not retrieve client package - error " + req.status);
                }
            }

            req.send();
        }


        /* (S3) Starts the game either after a previous game finishes, or the current one
        has not yet started (states DONE and READY) */
        startGame() {

            // are we starting from the right state?
            this.exceptIfNotInState([GameClientState.READY, GameClientState.DONE])
            if (this.state == GameClientState.DONE)
                this.state = GameClientState.READY;

            // TODO - start case loading, then put game in to TAKING_ACTIONS when case recieved:

            this.state = GameClientState.TAKING_ACTIONS;
            this.onGameStart.fire(new Event<EmptyEvent>());
        }


        /* (S4) Called whenever the user has built the action queue. Will move state back and forth
        between awaiting action consequence, and taking actions  */
        commitActions(queue: ActionQueue) {
            this.exceptIfNotInState([GameClientState.TAKING_ACTIONS]);

            this.state = GameClientState.AWAIT_ACTION_CONSEQUENCE;
            this.onActionsRequested.fire(new Event<EmptyEvent>());

            this.state = GameClientState.TAKING_ACTIONS;
            this.onActionConsequenceRecieved.fire(new Event<EmptyEvent>());
            
        }

        /* (S5) Called when the player has found the Dx and decided on treatment.  This will submit
        the DnT-package to the server, and await a response for score and follow-up questions. */
        commitDnT(dnt: DiagnoseAndTreatment) {
            this.exceptIfNotInState([GameClientState.TAKING_ACTIONS]);

            this.state = GameClientState.AWAIT_SCORE_AND_FOLLOWUP;
            this.onDnTSendt.fire(new Event<EmptyEvent>());

            this.state = GameClientState.FOLLOWUP;
            this.onScoreReceived.fire(new Event<EmptyEvent>());
        }

        /* (S6) Called when the player has answered or read follow-up information. This
        will end the game. */
        commitFollowup(followup: FollowupAnswers) {
            this.exceptIfNotInState([GameClientState.FOLLOWUP]);

            this.state = GameClientState.AWAIT_FOLLOWUP_RESULT;
            this.onFolloupSendt.fire(new Event<EmptyEvent>());
            
            this.state = GameClientState.DONE;
            this.onDone.fire(new Event<EmptyEvent>());
        }


   
        makeServiceRequest():XMLHttpRequest {
            var req = new XMLHttpRequest();
            req.open("POST", this.service_url, true);
            return req;
        }


        /* Utility function that throws an error if the current state is not in the list
        given.  It is used to stop game if the state machine is out of normal sequence */
        exceptIfNotInState(states: GameClientState[]) {
            var ok = false;
            states.forEach((state) => {
                if (state == this.state)
                    ok = true;
            });

            if (!ok)
                throw new StateSequenceException();   
        } 
    }

}