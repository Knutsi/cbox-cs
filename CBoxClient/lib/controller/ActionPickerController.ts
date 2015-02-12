module cbox.client {

    export enum ActionPickerMode {
        AWAIT_LOAD,
        HOME,
        SEARCH,
        FORM
    }

    /* The action picker's main resposibility is to prove a list of actions the user can take,
    and through the view make this list easy to use.  It depends on the client package being 
    loaded, and will */
    export class ActionPickerController extends BaseController {

        // internal state:
        private _mode = ActionPickerMode.AWAIT_LOAD;
        private current_form: Form = null;

        // elements:
        content_div: HTMLElement;
        back_button: HTMLElement;
        search_box: HTMLInputElement;

        actions;
        forms;
        queue;

        constructor(pc:PlayPageController, queue:ActionQueue) {
            super(pc);

            this.queue = queue;

            log.msg("ActionPickerController initialized")

            // build GUI and wire events:
            this.setupUI();

            // wire events to game client.
            // we need to wait for client package before we can do anything
            var game = this.page_controller.game_client;

            game.onClientPackageLoaded.addHandler((ev) => {

                // recieved, so we can finish setting up:
                this.actions = game.client_package.actions;
                this.forms = game.client_package.forms;

                log.msg("ActionPickerController receivd client package - ready")
                this.mode = ActionPickerMode.HOME;
            })
        }

        setupUI() {
            // grab the roleplayers:
            this.content_div = <HTMLElement>this.roleplayer("action-picker-content");
            this.back_button = <HTMLElement>this.roleplayer("action-picker-back");
            this.search_box = <HTMLInputElement>this.roleplayer("action-picker-search");

            // wire events:
            this.search_box.onfocus = () => { this.doSearch();  }
            this.search_box.onclick = () => { this.doSearch(); }

            this.back_button.onclick = () => { this.mode = ActionPickerMode.HOME }

            this.search_box
        }


        get mode():ActionPickerMode { return this._mode; }


        set mode(new_mode:ActionPickerMode) {
            if(this._mode != new_mode) {
                this._mode = new_mode;

                switch (new_mode) {
                    case ActionPickerMode.HOME:
                        this.renderHome();
                        break;

                    case ActionPickerMode.SEARCH:
                        this.renderSearch();
                        break;

                    case ActionPickerMode.FORM:
                        this.renderForm();
                        break;
                }
            }
        }


        private renderHome() {
            this.back_button_enabled = false;
            this.search_box.hidden = false;
            this.search_box.value = "";

            this.content_div.innerHTML = "";
            
            // render each form as a selectable link:
            this.forms.forEach((form:Form) => {
                var a = <HTMLDivElement>cbox.cin("div", this.content_div, form.title);
                a.onclick = () => { this.loadForm(form) }
                a.classList.add("clickable");
                
            })

        }


        private renderSearch() {
            this.back_button_enabled = true;
            this.search_box.hidden = false;

            this.content_div.innerHTML = "Search";
        }


        private renderForm() {
            this.back_button_enabled = true;
            this.search_box.hidden = true;

            this.content_div.innerHTML = "";
            //this.content_div.style.backgroundColor = this.current_form.head_color;

            // TODO update headline of div?:

            // write headlines:
            this.current_form.headlines.forEach((headline) => {
                var clipack = this.page_controller.game_client.client_package;
                var h2 = cbox.cin("div", this.content_div, headline.title);
                
                // make actions under this line:
                headline.action_idents.forEach((ident, i) => {
                    var action = clipack.actionByIdent(ident);

                    if (action) {
                        var div = cbox.cin("div", this.content_div, null, "clickable");
                        var checkbox = <HTMLInputElement>cbox.cin("input", div);
                        checkbox.setAttribute("type", "checkbox");

                        var title = cbox.cin("span", div, action.title);

                        // register action:
                        title.onclick = (ev) => { checkbox.checked = !checkbox.checked;}
                        checkbox.onchange = (ev) => {
                            if (checkbox.checked)
                                this.queue.add(action);
                            else
                                this.queue.remove(action);
                        }
                    }
                })
            }); 
        }


        doSearch() {
            
            this.mode = ActionPickerMode.SEARCH;
            this.renderSearch();
        }


        loadForm(form: Form) {
            this.current_form = form;

            // this will also trigger render:
            this.mode = ActionPickerMode.FORM;
        }


        get back_button_enabled() {
            return this.back_button.hidden == false;
        }


        set back_button_enabled(state:boolean) {
            this.back_button.hidden = !state;
        }

    }

}