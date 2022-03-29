using Microsoft.AspNetCore.Mvc;

namespace SoftwareUniversity_WebApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
