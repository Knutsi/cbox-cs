var cbox;
(function (cbox) {
    function cin(tag, parent, html, class_) {
        if (parent === void 0) { parent = null; }
        if (html === void 0) { html = null; }
        if (class_ === void 0) { class_ = null; }
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