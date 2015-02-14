module cbox.client {

    export class StartGameResponse {

        game_id: string;
        case_: Case;

        constructor(response:string) {
            var data = JSON.parse(response);
            this.game_id = data['GameID'];
            this.case_ = Case.fromObject(data['Case']);
        }
    }

}