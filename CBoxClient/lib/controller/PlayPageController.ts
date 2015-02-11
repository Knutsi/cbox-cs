module cbox.client {

    /***
    The play page controller manages a series of sub-controllers for each separate control 
    on the page (which corresponds to the MCV view).  It's main responsibility is to 
    instanciate these controlls.
    
    */
    export class PlayPageController {

        // model
        game_client: GameClient;

        // sub views:
        action_picker_ctrl: ActionPickerController;
        action_queue_ctrl: ActionQueueContoller;
        case_view_ctrl: CaseViewController;
        dnt_view_ctrl: DnTController;
        followup_ctrl: FollowupController;


        constructor() {
            // setup the client, then the controllers so that the subcontrollers and use this and them:
            this.game_client = new GameClient("/asset/dynamic/");

            this.setupControllers();

            // start game immidiately:
            this.game_client.onStateChange.addHandler((ev) => {
                if (ev.to == GameClientState.READY)
                    this.game_client.startGame();
            })


            this.game_client.startLoading();

            log.msg("PlayPageController init done");
        }

        /* Sets up the various controllers used on the page, such as the action picker,
        action queue, case view, score view etc. The actual views (the HTML) is embedded
        in the play.html page, while the code is loaded from external JS.  The model
        in this MCV setup is the GameClient and it's many classes. */
        setupControllers() {
            this.action_picker_ctrl = new ActionPickerController(this);
            this.action_queue_ctrl = new ActionQueueContoller(this);
            this.case_view_ctrl = new CaseViewController(this);
            this.dnt_view_ctrl = new DnTController(this);
            this.followup_ctrl = new FollowupController(this);
        }

    }

}