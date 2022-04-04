using Microsoft.AspNetCore.Mvc;
using SoftwareUniversity_WebApp.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WebApp.Core.Interfaces;
using WebApp.Infrastructure.Data;
using WebApp.Infrastructure.Data.Models;

namespace SoftwareUniversity_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repository;

        public HomeController(ILogger<HomeController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Home()
        {
            var homeModel = _repository.GetEntitiesFromDb();
            return View(homeModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}