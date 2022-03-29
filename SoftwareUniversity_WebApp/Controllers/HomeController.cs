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
        private readonly ITeamService _teamService;

        public HomeController(ILogger<HomeController> logger, ITeamService teamService)
        {
            _logger = logger;
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Home()
        {
            var teams = _teamService.GetTeams();
            return View(teams);
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