module cbox.client {

    /* Base class from which the other controllers inherit.  It basically just
    keeps track of main controller. */
    export class BaseController {

        page_controller: PlayPageController;

        constructor(page_controller:PlayPageController) {
            this.page_controller = page_controller;
        }
    }

}