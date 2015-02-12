

module cbox {

    /***
    The assets used by the game comes bundled in a "client package" that includes
    actions avauilable to the user and the the forms they are organized into.

    **/
    export class ClientPackage {

        actions: Action[] = []
        forms: Form[] = [];

        static fromObject(obj:{}): ClientPackage {
            var cp = new ClientPackage();

            cp.forms = obj['Forms'].map((form) => { return Form.fromObject(form) })
            cp.actions = obj['Actions'].map((action) => { return Action.fromObject(action) })

            return cp;
        }


        actionByIdent(ident: number) {
            for (var i = 0; i < this.actions.length; i++) 
                if (this.actions[i].ident == ident)
                    return this.actions[i]

            return null;
        }
    }

}