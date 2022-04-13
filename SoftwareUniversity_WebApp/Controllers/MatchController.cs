using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Interfaces;
using WebApp.Core.Models;

namespace SoftwareUniversity_WebApp.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchService _matchService;
        private readonly IRepository _repository;
        private readonly ITeamService _tenantService;
        private readonly UserManager<IdentityUser> _userManager;

        public MatchController(IMatchService matchService, IRepository repository, UserManager<IdentityUser> userManager, ITeamService tenantService)
        {
            _matchService = matchService;
            _repository = repository;
            _userManager = userManager;
            _tenantService = tenantService;
        }

        public IActionResult Add()
        {
            var user = _userManager.GetUserAsync(User);
            var userId = user.Result.Id;
            var dbEntities = _repository.GetEntitiesFromDb(userId);

            return View(dbEntities);
        }

        [HttpPost]
        public IActionResult Add(AddMatchViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_matchService.CreateMatch(model))
                {
                    return RedirectToAction("Home", "Home");
                }

                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction("Error", "Home");
        }

        public IActionResult ViewInfo(string id)
        {
            var matchModel = _matchService.FindMatch(id);

            return View(matchModel);
        }

        public IActionResult Edit(string id)
        {
            var user = _userManager.GetUserAsync(User);
            var userId = user.Result.Id;

            var match = _matchService.FindMatch(id);
            ViewData["teams"] = _tenantService.GetTeams(userId);

            return View(match);
        }

        [HttpPost]
        public IActionResult Edit(AddMatchViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_matchService.EditMatch(model))
                {
                    return RedirectToAction("Home", "Home");

                }
                return RedirectToAction("Error", "Home");

            }
            return RedirectToAction("Error", "Home");
        }

        public IActionResult Remove(string id)
        {
            var team = _matchService.FindMatch(id);

            return View(team);
        }

        [HttpPost]
        public IActionResult Remove(MatchViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_matchService.RemoveMatch(model))
                {
                    return RedirectToAction("Home", "Home");

                }
                return RedirectToAction("Error", "Home");

            }
            return RedirectToAction("Error", "Home");
        }
    }
}
