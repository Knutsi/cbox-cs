module cbox {

    export class Headline {

        title: string;
        action_idents: number[] = [];

        public static fromObject(obj: {}): Headline {
            var h = new Headline();

            h.title = obj['Title'];
            h.action_idents = obj['ActionIdents'].map((i) => { return parseInt(i) } );

            return h;
        }

    }

}