module cbox.client {

    export class TestResult {

        key: string;
        value: string;

        public static fromObject(obj: {}):TestResult {
            var tr = new TestResult();

            tr.key = obj['Key'];
            tr.value = obj['Value'];

            return tr;
        }

    }
} 