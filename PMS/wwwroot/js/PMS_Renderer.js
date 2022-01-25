
function RequestOptionConfig(actionUrl, requestMethod, generateBody, header) {
    this.actionUrl = actionUrl;
    this.requestMethod = requestMethod;
    this.generateBody = generateBody;
    this.header = header;
}

function GetRender() {

    const getTarget = (targetIdName) => {
        if (document) {
            return document.getElementById(targetIdName);
        }
        return null;
    };


    return {
        AttachEvent: (eventName, eleId) => ({

            Render: async (targetId, actionCallback, { actionUrl, requestMethod, header, generateBody }) => {

                var element = getTarget(eleId);



                element.addEventListener(eventName, function (e) {
                    e.preventDefault();
                    e.stopPropagation();

                    let body = typeof generateBody == "function" ? generateBody() : -1;
                    if (body == null) {
                        return;
                    }


                    fetch(window.location.origin + actionUrl, {
                        method: requestMethod,
                        headers: header == null ? {}:header,
                        body: body == -1 ? null : body
                    }).then((res) => actionCallback(getTarget(targetId), res));

                });

            }
        }),
    };

}


function IframeRender(event, targetId, url, attachTo) {

    let target = getById(targetId);

    
    target.addEventListener(event, function (e) {

        e.preventDefault();

        let attach = getById(attachTo);

        let atr = Array.prototype.forEach.bind(attach.children);
        let check = 0;

        atr(e => {
            if (e.nodeName == "IFRAME") {
                check = 1;
            }
        });
        //found other Iframe
        if (check==1) {
            return;
        }

        const iframe = document.createElement("iframe");

        iframe.src = url;
        iframe.width = "100%";
        iframe.height = "100%";


        attach.style.height = "100vh";

          attach.append(iframe);        

    });

}

