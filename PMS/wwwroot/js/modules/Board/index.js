const BoardModule = (dom => {


    const attachTarget = "Btn_Board";
    const onEvent = "click";
    const renderTarget = Views.MainContainer;
    const requestOptions = new RequestOptionConfig(
        "/Board",
        "Get",
        null,
        null,
    );


    const onDone = (target, response) => {

        if (target && response) {

            response.text().then(
                txt => {
                    target.innerHTML = txt;
                    return txt;
                }
            ).catch(err => {
                console.error(err);
            });
        }

    }

    return {
        onEvent: onEvent,
        attachTarget: attachTarget,
        renderTarget: renderTarget,
        onDone: onDone,
        requestOptions: requestOptions,
        
    };

})(document);



