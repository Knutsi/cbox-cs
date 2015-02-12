module cbox.client {


    /* The ActionQueueController renders a up-to-date list of the items currently in the
    user's plan.  They offer drag'n-drop reordering and deletion of items in the list.*/
    export class ActionQueueContoller extends BaseController {

        queue: ActionQueue;
        content_div: HTMLElement;
        message_div: HTMLElement;
        execute_div: HTMLElement;

        welcome_note_done: boolean = false;

        constructor(pc: PlayPageController, queue: ActionQueue) {
            super(pc);

            // get queue, and subscribe to events:
            this.queue = queue;
            this.queue.onChange.addHandler(() => { this.render(); });

            // setup UI:
            this.content_div = this.roleplayer("action-queue-content");
            this.message_div = this.roleplayer("action-queue-message");
            this.execute_div = this.roleplayer("action-queue-execute");

            // wire events:
            this.execute_div.onclick = () => {
                this.page_controller.game_client.commitActions(this.queue);
                this.queue.clear();
            }

            this.render();

            log.msg("ActionQueueController: initialized")
        }


        render() {
            log.msg("ActionQueueController: render")
            this.content_div.innerHTML = "";

            if (this.queue.items.length <= 0) {
                this.message_div.hidden = true;
                if (!this.welcome_note_done)
                    this.content_div.innerHTML = "<p>Pick the tests, procedures and studies you want in the actions panel to add them to your plan.  When done, press \"Perform\".</p>  <p>You can do this as many times as you want - but keep in mindt that each action has a cost in terms of pain, time spent and risk to the patient!</p> <p>When you think you know the diagnosis, and how to treat it - press \"Diagnose and threat\". In the end, you will get a score. Good luck!</p>"
               else
                    this.content_div.innerHTML = "(Plan empty)";
            } else {
                this.welcome_note_done = true;
                this.message_div.hidden = false;
            }

            
            this.queue.items.forEach((entry, i) => {

                var this_iter = i;

                // render div:
                var text = entry.action.title
                if(entry.problem != null)
                    text += " (" + entry.problem.title + ")";
               
                var div = cbox.cin("div", this.content_div, text, "hover_highlight");

                // make div drag and droppable:
                div.setAttribute("draggable", "true");
                
                div.ondrag = (ev: DragEvent) => { ev.dataTransfer.setData("from", this_iter.toString()) }
                div.ondragover = (ev: DragEvent) => {
                    ev.preventDefault();
                    
                }    // need this to be droppable
                div.ondrop = (ev: DragEvent) => {
                    
                    var f = parseInt(ev.dataTransfer.getData("from"));
                    this.queue.move(f, this_iter);
                    log.msg(f + " -> " + this_iter);
                    console.log(ev.dataTransfer.getData('from'));
                }

            })
        }
    }

}