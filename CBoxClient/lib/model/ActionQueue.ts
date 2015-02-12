module cbox.client {

    export class ActionQueue {

        onChange: Event<EmptyEvent> = new Event<EmptyEvent>();
        items: ActionRequest[] = [];

        add(action:Action, problem=null) {
            log.msg("ActionQueue: +" + action.title);

            this.items.push(new ActionRequest(action, problem));

            this.onChange.fire(new EmptyEvent());
        }


        remove(action: Action, problem=null) {
            log.msg("ActionQueue: -" + action.title);

            var entry = this.getEntry(action, problem);
            if(entry == null)
                log.warn("ActionQueue.remove : no such item in queue : " + action.title);

            if (entry)
                this.items.splice(this.items.indexOf(entry), 1);
            

            this.onChange.fire(new EmptyEvent());
        }


        move(f: number, t: number) {

            // remove at index:
            var moved_action = this.items.splice(f, 1)[0];

            // reinsert the item at the new index:
            this.items.splice(t, 0, moved_action);

            log.msg("ActionQueue: moved " + moved_action.action.title + " -> " + f +  " ->" + t);
            this.onChange.fire(new EmptyEvent());
        }


        getEntry(action:Action, problem:Problem) {
            for (var i in this.items)
                if (this.items[i].action == action && this.items[i].problem == problem)
                    return this.items[i];

            return null;
        }


        clear() {
            this.items = [];
            this.onChange.fire(new EmptyEvent());
        }
    }
}