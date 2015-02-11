

module cbox {

    /***
    The assets used by the game comes bundled in a "client package" that includes
    actions avauilable to the user and the the forms they are organized into.

    **/
    export class ClientPackage {

        Actions: Action[] = []
        Forms: Form[] = [];

        static fromObject(obj:{}): ClientPackage {
            var cp = new ClientPackage();



            return cp;
        }

    }

}