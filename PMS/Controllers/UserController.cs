using DataLayer.ViewModel.UserAccountViewModel;
using Microsoft.AspNetCore.Mvc;
using PMSServices.UserAccountServices.RoleServices;
using PMSServices.UserAccountServices.UserServices;
using System;
using System.Collections.Generic;

namespace PMS.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserServices userServices;


        private readonly IRoleServices roleServices;
        public UserController(IUserServices usersServices,IRoleServices roleServices)
        {
            if (usersServices is null)
            {
                throw new ArgumentNullException(nameof(usersServices));
            }

            if (roleServices is null)
            {
                throw new ArgumentNullException(nameof(roleServices));
            }

            userServices = usersServices;
            this.roleServices = roleServices;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/GetUsers")]
        public IActionResult GetUsers()
        {
            List<UserView> users=new();

            foreach (var user  in userServices.GetUsers())
            {
                users.Add(new UserView() { 
                  Email    = user.Email,
                  Id       = user.Id,
                  UserName = user.UserName,
                 
                  Role     = roleServices.GetRole(user.CredentialId).Name
                });
            }

            return PartialView(new UserViewModel(users));
        }
    }
}
