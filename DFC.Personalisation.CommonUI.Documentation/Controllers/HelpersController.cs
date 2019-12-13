using Microsoft.AspNetCore.Mvc;

namespace DFC.Personalisation.CommonUI.Documentation.Controllers
{
    public class HelpersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ActiveRoute()
        {
            return View();
        }

        public IActionResult Stylesheet()
        {
            return View();
        }
    }
}
