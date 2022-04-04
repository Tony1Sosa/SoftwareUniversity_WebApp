using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Interfaces;

namespace SoftwareUniversity_WebApp.Controllers
{
    public class TrainController : Controller
    {
        private readonly ITeamService _teamService;

        public TrainController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        public IActionResult Add()
        {
            var teams = _teamService.GetTeams();
            return View(teams);
        }
    }
}
