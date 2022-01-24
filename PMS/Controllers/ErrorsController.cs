using Microsoft.AspNetCore.Mvc;


namespace PMS.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("error/404")]
        public IActionResult Error404()
        {

            return View();
        }


        [HttpGet]
        [Route("/error/504")]
        public IActionResult Error504()
        {
            
            return View();
        }
    }
}
