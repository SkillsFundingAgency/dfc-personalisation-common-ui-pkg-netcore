﻿using Microsoft.AspNetCore.Mvc;

namespace DFC.Personalisation.CommonUI.Documentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
