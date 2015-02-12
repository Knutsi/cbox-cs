module cbox {

    export function cin(tag:string, parent:HTMLElement=null, html:string=null, class_:string=null) {
        var e = document.createElement(tag);
        if (parent != null)
            parent.appendChild(e);

        if (html != null)
            e.innerHTML = html;

        if (class_ != null)
            e.classList.add(class_);

        return e;
    }

} 