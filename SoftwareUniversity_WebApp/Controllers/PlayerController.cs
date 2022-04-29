using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SoftwareUniversity_WebApp.Models;
using WebApp.Core.Interfaces;
using WebApp.Core.Models;

namespace SoftwareUniversity_WebApp.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly IRepository _repository;
        private readonly IValidationService _validator;
        private readonly ITeamService _teamService;

        public PlayerController(IPlayerService playerService, IRepository repository, IValidationService validator, ITeamService teamService)
        {
            _playerService = playerService;
            _repository = repository;
            _validator = validator;
            _teamService = teamService;
        }

        public IActionResult Add()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var teams = _repository.GetEntitiesFromDb(userId);
            return View(teams);
        }

        [HttpPost]
        public IActionResult Add(AddPlayerViewModel model)
        {
            (bool passed1, string error1) = _validator.ValidateModel(model);
            if (passed1)
            {
                if (_playerService.CreatePlayer(model))
                {
                    return RedirectToAction("Home", "Home");
                }

                return RedirectToAction("Error", "Home", new{error1});
            }

            return RedirectToAction("Error", "Home", new { error1 });
        }

        public IActionResult ViewInfo(string id)
        {
            var player = _playerService.FindPlayer(id);

            return View(player);
        }

        public IActionResult Edit(string id)
        {
            var player = _playerService.FindPlayer(id);
            ViewData["team"] = _teamService.FindTeamForPlayer(player)
            return View(player);
        }

        [HttpPost]
        public IActionResult Edit(PlayerViewModel model)
        {
            (bool passed1, string error1) = _validator.ValidateModel(model);
            if (ModelState.IsValid)
            {
                if (_playerService.EditPlayer(model))
                {
                    return RedirectToAction("Home", "Home");
                }

                return RedirectToAction("Error", "Home", new { error1 });
            }

            return RedirectToAction("Error", "Home", new { error1 });
        }

        public IActionResult Remove(string id)
        {
            var player = _playerService.FindPlayer(id);

            return View(player);
        }

        [HttpPost]
        public IActionResult Remove(PlayerViewModel model)
        {
            if (_playerService.RemovePlayer(model.Id))
            {
                return RedirectToAction("Home", "Home");
            }

            return RedirectToAction("Error", "Home");
        }
    }
}
