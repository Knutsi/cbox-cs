module cbox.client {

    export class FollowupController extends BaseController {
        constructor(pc: PlayPageController) {
            super(pc);

            log.msg("FollowupController initialized")
        }
    }

}