using Microsoft.AspNetCore.Mvc;

namespace AdminDemo.Drivers.PageControllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }
    }
}