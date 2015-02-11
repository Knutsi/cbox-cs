module log {

    export var LOG_PREFIX = "CBox"
    export var LOG_OUTPUT_TAGS = ["std", "err", "warn"];

    export function msg(msg: string, tags: string[]= ["std"]) {
        var output = false;

        tags.forEach((tag) => {
            if (LOG_OUTPUT_TAGS.indexOf(tag) != -1)
                output = true;
        });

        if (output)
            console.log(LOG_PREFIX + "(" + tags + ")::" + msg);
    }

    export function err(msg_: string, tags: string[]= ["err"]) { msg(msg_, tags); }
    export function warn(msg_: string, tags: string[]= ["warn"]) { msg(msg_, tags); }
}
