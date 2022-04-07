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
        private readonly UserManager<IdentityUser> _userManager;

        public TeamController(ITeamService teamService, UserManager<IdentityUser> userManager)
        {
            _teamService = teamService;
            _userManager = userManager;
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

        public IActionResult ViewInfo()
        {
            return View();
        }
    }
}
