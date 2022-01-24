using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using MaleServices.Model;
using MaleServices.Services;

using PMSServices.UserAccountServices.RoleServices;
using PMSServices.UserAccountServices.UserCredentialServices;
using PMSServices.UserAccountServices.UserServices;

using DataLayer.Model.UserAccount;

namespace PMS.Controllers
{
    public class AccountRegistrationController : Controller
    {
        private readonly IUserServices userServices;
        private readonly IRoleServices roleServices;
        private readonly IMailService maileServices;
        private readonly IUserCredentialServices userCredentialsServices;
        public AccountRegistrationController(IUserServices userServices, IRoleServices roleServices,IMailService  maileServices,IUserCredentialServices userCredentialService)
        {
            this.userServices = userServices;
            this.roleServices = roleServices;
            this.maileServices = maileServices;
            userCredentialsServices = userCredentialService;
        }

    

        [HttpPost]
        [Route("/InitRegistration")]
        public IActionResult InitRegistrationProcess(string firstName,string lastName, string userEmail, string userPassword,string confirmPassword)
        {
            User newUser = new User();

            string userName = firstName + " " + lastName;
            string  errormsg="";
            

            if (userPassword!=confirmPassword)
            {
                errormsg = "confirm password does not matched with entered password";
            }else
               if (userServices.GetUsers().Where(user => user.Email.Equals(userEmail)).ToArray().Length != 0)
            {
                errormsg = "A User is already existed in the database with the same email id";
            }
            else
            {
                newUser.RoleId = roleServices.GetAllRoles().Where<Role>(r => r.Name.Equals("User")).ToArray()[0].Id;

                newUser.UserName = userName;
                newUser.Email = userEmail;

                newUser.CredentialId = userCredentialsServices.GenrateCredentials(userPassword);

                /*NOTE: FOR TESTING */
                userServices.InsertUser(newUser);

                MailRequest req = new()
                {
                    Body = $"<h3>" +
                    $"<ul>" +
                    $"<li>User Name:<strong>{userName}    </strong></li>" +
                    $"<li>password:<strong>  {userPassword}</strong></li>" +
                    $"</ul>",
                    Subject = "Welcome To GiniLytics IT Solutions.",
                    ToEmail = userEmail,
                    ContactName=firstName+" "+lastName
                };

                Send(req).Wait();

                ViewBag.errorMsg = "Done";
           
            return View("InitRegistrationProcess");
 
            }

            ViewBag.errorMsg = errormsg;
    
           
            return View("InitRegistrationProcess");
        }
        public async Task Send(MailRequest request)
        {
            try
            {
                await maileServices.SendEmailAsync(request);
               
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        [Route("/Error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
