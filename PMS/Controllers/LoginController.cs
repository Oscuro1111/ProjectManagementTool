using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMSServices.UserAccountServices.JWT;
using PMSServices.UserAccountServices.UserCredentialServices;
using PMSServices.UserAccountServices.UserServices;

namespace PMS.Controllers
{
    public class LoginController:Controller
    {

        private readonly IJWTAuth jwtauth;
        private readonly ITokenManager tokenManager; 
        public LoginController(IJWTAuth auth,IUserServices userServices,IUserCredentialServices userCredentialServices, ITokenManager tokenManager)
        {


            this.jwtauth = auth;

            this.jwtauth.setDependency(userServices,userCredentialServices);

            this.tokenManager = tokenManager;

        }


        [HttpGet]
        [Route("/")]
        public IActionResult DashBoard()
        {

            string token;

            try
            {
                token = Request.Cookies["token"];

                if (tokenManager.ValidateToken(token) != null)
                {
                    return Redirect("/DashBoard");
                }

            }
            catch
            {
                //Not Logined Go to form
                goto loginForm;
            }


loginForm:
            return Redirect("/LoginForm");
        }

        [HttpGet]
        [Route("/LoginForm")]
        public IActionResult LoginForm()
        {
            string token;
            try
            {
                token = Request.Cookies["token"];
                if (tokenManager.ValidateToken(token) != null)
                {
                    return Redirect("/DashBoard");
                }

            }
            catch
            {
                //Not Logined Go to form
                goto loginForm;
            }

            
loginForm:
            return View();
        }

        [HttpPost]
        [Route("/Login")]
      public IActionResult LoginInit(string userEmail,string userPassword)
        {
            var token = this.jwtauth.Authentication(userEmail, userPassword);
            CookieOptions option = new CookieOptions();

            if (token==null)
            {
                return Unauthorized();
            }



            option.Expires = DateTime.Now.AddMinutes(60);
            option.HttpOnly = true;

            
            Response.Cookies.Append("token",token,option);

            return Ok(token);
        }


        [HttpGet]
        [Route("/Logout")]
        public IActionResult Logout()
        {
            try
            {
                Response.Cookies.Delete("token");
                
            }
            catch
            {
                goto __LoginForm;
            }

__LoginForm:
            return Redirect("/LoginForm");
        }
    }
}
