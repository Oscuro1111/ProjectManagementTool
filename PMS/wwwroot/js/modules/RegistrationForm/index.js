const RegistrationModule = (dom => {


    const attachTarget = "Btn_RegistrationSubmit";
    const onEvent = "click";
    const renderTarget = Views.MainContainer;
    const requestOptions = new RequestOptionConfig(
        "/InitRegistration",
        "Post",
        () => ValidateRegistrationForm(new FormData(getById("RegistrationForm"))),
        null,
    );


    const ValidateRegistrationForm = (form) => {

        if (form instanceof FormData) {

            let firstName = form.get("firstName");
            let lastName = form.get("lastName");

            let email = form.get("userEmail");

            let userPassword = form.get("userPassword");
            let confirmPassword = form.get("confirmPassword");

            if (userPassword != confirmPassword) {
                alert("User password does not matched with confirm password!");
                return null;
            }

            if (lastName.length == 0 || firstName.length == 0) {
                alert("first name or last name canot be null");
                return null;
            }

            if (!(/^[a-zA-Z].[a-z0-9A-Z\.]+@\w+\.[a-zA-Z]{2,5}/g.test(email))) {
                alert("Unvalid email format!");
                return null;
            }


            return form;
        }

        return null;
    }

    const onDone = (target, response) => {

        if (target && response) {

            response.text().then(
                txt => {
                    $(dom).find("button#Btn-CloseRegistration").click();
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
        requestOptions: requestOptions
    };

})(document);

