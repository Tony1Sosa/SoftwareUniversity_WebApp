using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SoftwareUniversity_WebApp.Models;
using WebApp.Core.Interfaces;
using WebApp.Core.Models;
using WebApp.Infrastructure.Data.Models;

namespace SoftwareUniversity_WebApp.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly IRepository _repository;

        public PlayerController(IPlayerService playerService, IRepository repository)
        {
            _playerService = playerService;
            _repository = repository;
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
            if (ModelState.IsValid)
            {
                (bool passed , string error) = _playerService.CreatePlayer(model);
                if (passed = true)
                {
                    return RedirectToAction("Home", "Home");
                }

                return RedirectToAction("Error", "Home", error);
            }

            return RedirectToAction("Error", "Home");
        }

        public IActionResult ViewInfo(string id)
        {
            var player = _playerService.FindPlayer(id);

            return View(player);
        }

        public IActionResult Edit(string id)
        {
            var player = _playerService.FindPlayer(id);

            return View(player);
        }

        [HttpPost]
        public IActionResult Edit(PlayerViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (_playerService.EditPlayer(model))
                {
                    return RedirectToAction("Home", "Home");
                }

                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction("Error", "Home");
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
