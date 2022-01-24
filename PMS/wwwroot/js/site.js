function SetupDashBoardController() {

        var renderer = GetRender();

        if (RegistrationModule)
            renderer.AttachEvent(RegistrationModule.onEvent, RegistrationModule.attachTarget)
                .Render(RegistrationModule.renderTarget, RegistrationModule.onDone,
                    RegistrationModule.requestOptions);
}

function Main() {
    SetupDashBoardController();
}

$(document).ready(Main);
