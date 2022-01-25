
function SetupDashBoardController() {

        var renderer = GetRender();

        if (RegistrationModule)
            renderer.AttachEvent(RegistrationModule.onEvent, RegistrationModule.attachTarget)
                .Render(RegistrationModule.renderTarget, RegistrationModule.onDone,
                    RegistrationModule.requestOptions);


    //if (BoardModule)
    //      renderer.AttachEvent(BoardModule.onEvent, BoardModule.attachTarget)
    //          .Render(BoardModule.renderTarget,
    //                           BoardModule.onDone,
    //              BoardModule.requestOptions)


    if (BoardModule)
        IframeRender(BoardModule.onEvent,
                        BoardModule.attachTarget,
                          BoardModule.requestOptions.actionUrl,
                                BoardModule.renderTarget);

}

function Main() {
    SetupDashBoardController();
}

$(document).ready(Main);
