/**
 * Created by knutsi on 27/12/13.
 */

module cbox {

    /* General event that can be used for anonymous events with no sepcial data*/
    export class EmptyEvent { }

    export class EventSubscription {
        handler:any;
        ref:any;

        constructor(handler, ref) {
            this.handler = handler;
            this.ref = ref;
        }
    }

    /***
     * Simple event pattern for subscribing to event emissions
     */
    export class Event<T> {

        private subscriptions:EventSubscription[];

        constructor() {
            this.subscriptions = [];
        }


        /***
         * Creates a subscription with the provided handler, and returns the subscription
         * object.
         * @param handler
         * @param ref
         * @returns {cbox.EventSubscription}
         */
        addHandler(handler:(obj:T) => void, ref=null):EventSubscription {
            var sub = new EventSubscription(handler, ref);
            this.subscriptions.push(sub);

            return sub;
        }

        /***
         * Deletes a subscription using the subscriptio object.
         * @param ref
         */
        removeHandler(sub:EventSubscription) {
            var index = this.subscriptions.indexOf(sub);
            if(index != undefined) {
                this.subscriptions.splice(index, 1);
            }
        }

        /***
         * Removes all subscriptions mathcing the given reference object.
         * @param ref
         */
        removeByReferenceObject(ref:any) {
            var found:any[] = [];

            // find all mathcing refernce:
            this.subscriptions.forEach((sub) => {
                if(sub.ref == ref)
                    found.push(sub);
            })

            // remove all found subscriptions:
            found.forEach((sub) => {
                this.removeHandler(sub);
            })

        }

        fire(obj:T) {
            this.subscriptions.forEach((sub) => {
                sub.handler(obj);
            })
        }

        fireAsync(obj:T) {
            setTimeout((obj) => {this.fire(obj)},1);
        }

        /*dump() {
            console.log("Dumping event subsribers:")
            this.subscriptions.forEach((sub) => {
                console.log(sub);
            })
        }*/

    }

}