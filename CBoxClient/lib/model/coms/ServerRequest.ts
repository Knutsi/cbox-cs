module cbox.client {

    export class ServerRequest {

        public static make(client: GameClient, action: string, data: string) {

            return JSON.stringify({
                SessionID: client.current_session_id,
                GameID: client.current_game_id,
                Action: action,
                Data: data
            })
        }

    }

}