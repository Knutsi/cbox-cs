module cbox.client {

    export class ActionQueueContoller extends BaseController {
        constructor(pc: PlayPageController) {
            super(pc);

            log.msg("ActionQueueController initialized")
        }
    }

}