module cbox.client {

    export class CaseViewController extends BaseController {

        content_div: HTMLDivElement;

        constructor(pc: PlayPageController) {
            super(pc);

            // grab UI-elements:
            this.content_div = <HTMLDivElement>this.roleplayer("case-view-content");

            // wire events:
            var game_client = this.page_controller.game_client;
            game_client.onGameStart.addHandler(() => { this.updateCase() } );

            log.msg("CaseViewController initialized")
        }

        updateCase() {
            this.content_div.innerHTML = JSON.stringify(this.page_controller.game_client.current_case);
        }
    }

}