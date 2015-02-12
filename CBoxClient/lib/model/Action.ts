


module cbox {

    export class Action {

        cost: number;
        ident: number;
        pain: number;
        risk: number;
        target_classes: string[] = [];
        time_used_occupied: number;
        time_used_process: number;
        title: string;

        public static fromObject(obj: {}) {
            var a = new Action();

            a.title = obj['Title'];
            a.cost = parseFloat(obj['Cost']);
            a.ident = parseFloat(obj['Ident']);
            a.pain = parseFloat(obj['Pain']);
            a.risk = parseFloat(obj['Risk']);
            a.target_classes = obj['TargetClasses'];
            a.time_used_occupied = parseFloat(obj['TimeUsedOccupied']);
            a.time_used_process = parseFloat(obj['TimeUsedProcess']);

            return a;
        }

    }

}