function Login_Submit() {

    var form = document.getElementById("login-form");
    
    form.addEventListener("submit", function (e) {
        e.preventDefault();

        var formData = new FormData(form);

        fetch( form.action,{
            method: "POST",
            body:formData
        }).then(response => {

            if (response.status == 401) {
                alert("User name or password  does not matched.");

            } else {
                
                        window.location.reload();
                }
        });

            
        });

}

Login_Submit();