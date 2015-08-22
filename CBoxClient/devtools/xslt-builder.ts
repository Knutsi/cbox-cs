//declare var XSLTProcessor: any;
interface Document { load: any; }

module XSLTBuilder {

    console.log("XSLT Builder debug tool");


    export var xmlTextArea = <HTMLTextAreaElement>document.querySelector("#rawXml");
    export var templateTextArea = <HTMLTextAreaElement>document.querySelector("#templateInput");
    export var outputDiv = <HTMLDivElement>document.querySelector("#outputRender");

    export function load() {
        var url = (<HTMLInputElement>document.querySelector("#urlInput")).value;
        var actions = (<HTMLInputElement>document.querySelector("#actionsInput")).value;

        // send request:
        var req = new XMLHttpRequest();
        req.open("POST", "http://localhost:8008/service/xml/case/random", true);
        req.onreadystatechange = () => {
            if (req.status == 200 && req.readyState == 4) {
                xmlTextArea.value = req.responseText;
            }
        }

        req.send();
    }


    export function render()
    {
        // get data:
        var xsl = templateTextArea.value;
        var xml = xmlTextArea.value;

        var xsl_doc = document.implementation.createDocument("", "test", null);
        xsl_doc.load(xsl);

        var xml_doc = document.implementation.createDocument("", "test", null);
        xml_doc.load(xml);

        // render:
        var processor = new XSLTProcessor();
        processor.importStylesheet(xsl_doc);
        var result = <HTMLDocument>processor.transformToFragment(xml_doc, document);

        // add result:
        outputDiv.innerHTML = "";
        outputDiv.appendChild(result);
    }
    
}