var cbox;
(function (cbox) {
    function cin(tag, parent, html, class_) {
        if (typeof parent === "undefined") { parent = null; }
        if (typeof html === "undefined") { html = null; }
        if (typeof class_ === "undefined") { class_ = null; }
        var e = document.createElement(tag);
        if (parent != null)
            parent.appendChild(e);

        if (html != null)
            e.innerHTML = html;

        if (class_ != null)
            e.classList.add(class_);

        return e;
    }
    cbox.cin = cin;
})(cbox || (cbox = {}));
//# sourceMappingURL=Tools.js.map
