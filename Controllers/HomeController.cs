using Microsoft.AspNetCore.Mvc;

namespace Elmah.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Home");
        }
    }
}
