using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Interfaces;
using WebApp.Core.Models;

namespace SoftwareUniversity_WebApp.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;
        private readonly UserManager<IdentityUser> _userManager;

        public TeamController(ITeamService teamService, UserManager<IdentityUser> userManager, IPlayerService playerService)
        {
            _teamService = teamService;
            _userManager = userManager;
            _playerService = playerService;
        }
        public IActionResult Add()
        {
            return View();
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

        public IActionResult ViewInfo(string id)
        {
            var team = _teamService.FindTeam(id);
            ViewData["players"] = _playerService.GetPlayersByTeam(id);

            return View(team);
        }

        public IActionResult Edit(string id)
        {
            var team = _teamService.FindTeam(id);
            ViewData["players"] = _playerService.GetPlayersByTeam(id);
            return View(team);
        }

        [HttpPost]
        public IActionResult Edit(TeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_teamService.EdditTeam(model))
                {
                    return RedirectToAction("Home", "Home");

                }
                return RedirectToAction("Error", "Home");

            }
            return RedirectToAction("Error", "Home");
        }

        public IActionResult Remove(string id)
        {
            var team = _teamService.FindTeam(id);
            return View(team);
        }

        [HttpPost]
        public IActionResult Remove(TeamViewModel model)
        {
            if (_teamService.RemoveTeam(model.Id))
            {
                return RedirectToAction("Home", "Home");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}
