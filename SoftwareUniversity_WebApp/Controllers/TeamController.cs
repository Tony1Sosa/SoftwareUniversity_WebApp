using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Interfaces;
using WebApp.Core.Models;

namespace SoftwareUniversity_WebApp.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
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
    }
}
