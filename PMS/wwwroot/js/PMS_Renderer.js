
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

