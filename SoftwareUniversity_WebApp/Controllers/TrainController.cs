﻿using Microsoft.AspNetCore.Mvc;

namespace SoftwareUniversity_WebApp.Controllers
{
    public class TrainController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}