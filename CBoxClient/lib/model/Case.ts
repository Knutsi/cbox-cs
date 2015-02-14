module cbox.client {

    export class Case {

        problems: Problem[] = [];
        diagnosis: string[];
        treatments: string[];

        public static fromObject(data: {}):Case {

            var case_ = new Case();

            case_.problems = data['Problems'].map((p) => { return Problem.fromObject(p) })

            return case_;
        }

    }

}