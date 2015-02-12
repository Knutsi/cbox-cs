module cbox.client {

    /* Base class from which the other controllers inherit.  It basically just
    keeps track of main controller and provides utilities. */
    export class BaseController {

        page_controller: PlayPageController;

        constructor(page_controller:PlayPageController) {
            this.page_controller = page_controller;
        }

        roleplayer(role:string):HTMLElement {
            return <HTMLElement>document.querySelector("[data-cbox-role=" + role + "]");
        }
    }

}