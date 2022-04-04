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

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public IActionResult Add()
        {
            return View();
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

                return RedirectToAction("Error", "Home");
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
        public IActionResult Remove(Player model)
        {
            if (_playerService.RemovePlayer(model.Id))
            {
                return RedirectToAction("Home", "Home");
            }

            return RedirectToAction("Error", "Home");
        }
    }
}
