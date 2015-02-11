module cbox.client {

    /***
    The role of the play page controller is to instanciate and run the client 
    and a series of independent views.  It also responds to events in the client */
    export class PlayPageController {

        game_client: GameClient;

        constructor() {
            this.game_client = new GameClient("/asset/dynamic/");

            // start game immidiately:
            this.game_client.onStateChange.addHandler((ev) => {
                if (ev.to == GameClientState.READY)
                    this.game_client.startGame();
            })


            this.game_client.startLoading();

            log.msg("PlayPageController init done");
        }

    }

}