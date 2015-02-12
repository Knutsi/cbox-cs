module cbox.client {

    export class ActionRequest {
        action: Action;
        problem: Problem;

        constructor(action, problem) {
            this.action = action;
            this.problem = problem;
        }
    }
}