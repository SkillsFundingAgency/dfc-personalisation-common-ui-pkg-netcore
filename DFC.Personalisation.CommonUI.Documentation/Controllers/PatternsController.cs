using Microsoft.AspNetCore.Mvc;

namespace DFC.Personalisation.CommonUI.Documentation.Controllers
{
    public class PatternsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
