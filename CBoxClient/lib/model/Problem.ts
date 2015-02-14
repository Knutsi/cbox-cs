module cbox.client {

    export class Problem {
        ident: string;
        title: string;
        test_results: TestResult[];
        classes: string[];

        public static fromObject(obj:{}):Problem {
            var p = new Problem();

            p.ident = obj['Ident'];
            p.test_results = obj['TestResults'].map((tr) => { return TestResult.fromObject(tr) } )

            return p;
        }

    }

    

}