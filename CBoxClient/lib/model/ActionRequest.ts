module cbox.client {

    export class ActionRequest {
        action: Action;
        problem: Problem;

        constructor(action, problem) {
            this.action = action;
            this.problem = problem;
        }

        toObject(): {} {
            var problem_ident = null;
            if (this.problem)
                problem_ident = this.problem.ident;

            return {
                ActionIdent: this.action.ident, 
                ProblemIdent: problem_ident
            }
        }
    }
}