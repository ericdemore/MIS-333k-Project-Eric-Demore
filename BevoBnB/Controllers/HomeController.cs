﻿//Group 3 BevoBnB Project

using Microsoft.AspNetCore.Mvc;

namespace BevoBnB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}