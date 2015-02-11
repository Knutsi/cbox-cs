module cbox.client {

    /* The action picker's main resposibility is to prove a list of actions the user can take,
    and through the view make this list easy to use.  It depends on the client package being 
    loaded, and will */
    export class ActionPickerController extends BaseController {

        constructor(pc:PlayPageController) {
            super(pc);

            log.msg("ActionPickerController initialized")
        }

    }

}