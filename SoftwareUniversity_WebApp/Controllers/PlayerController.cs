using Microsoft.AspNetCore.Mvc;
using SoftwareUniversity_WebApp.Models;
using WebApp.Core.Interfaces;
using WebApp.Core.Models;

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
            var player = _playerService.FindPlayer(id);

            return View(player);
        }
    }
}
