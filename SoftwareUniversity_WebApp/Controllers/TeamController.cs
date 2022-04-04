using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Interfaces;
using WebApp.Core.Models;

namespace SoftwareUniversity_WebApp.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;

        public TeamController(ITeamService teamService, IPlayerService playerService)
        {
            _teamService = teamService;
            _playerService = playerService;
        }
        public IActionResult Add()
        {
            var players = _playerService.GetPlayers();
            return View(players);
        }

        [HttpPost]
        public IActionResult Add(AddTeamViewModel model)

        {
            if (ModelState.IsValid)
            {
                (bool passed, string error) = _teamService.CreateTeam(model);

                if (passed = true)
                {
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult ViewInfo()
        {
            return View();
        }
    }
}
