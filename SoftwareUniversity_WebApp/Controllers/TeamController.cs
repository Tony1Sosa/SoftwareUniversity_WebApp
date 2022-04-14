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
        private readonly IValidationService _validator;
        private readonly UserManager<IdentityUser> _userManager;

        public TeamController(ITeamService teamService, UserManager<IdentityUser> userManager, IPlayerService playerService, IValidationService validator)
        {
            _teamService = teamService;
            _userManager = userManager;
            _playerService = playerService;
            _validator = validator;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddTeamViewModel model)
        {
            (bool passed1, string error1) = _validator.ValidateModel(model);
            if (ModelState.IsValid)
            {
                (bool passed, string error) = _teamService.CreateTeam(model);

                if (passed = true)
                {
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { error1 });
                }
            }
            else
            {
                return RedirectToAction("Error", "Home", new { error1 });
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
            (bool passed1, string error1) = _validator.ValidateModel(model);
            if (ModelState.IsValid)
            {
                if (_teamService.EditTeam(model))
                {
                    return RedirectToAction("Home", "Home");

                }
                return RedirectToAction("Error", "Home", new { error1 });

            }
            return RedirectToAction("Error", "Home", new { error1 });
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
