using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftwareUniversity_WebApp.Models;
using WebApp.Core.Interfaces;
using WebApp.Core.Models;

namespace SoftwareUniversity_WebApp.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchService _matchService;
        private readonly IRepository _repository;
        private readonly ITeamService _tenantService;
        private readonly IValidationService _validator;
        private readonly UserManager<IdentityUser> _userManager;

        public MatchController(IMatchService matchService, IRepository repository, UserManager<IdentityUser> userManager, ITeamService tenantService, IValidationService validator)
        {
            _matchService = matchService;
            _repository = repository;
            _userManager = userManager;
            _tenantService = tenantService;
            _validator = validator;
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
            (bool passed1, string error1) = _validator.ValidateModel(model);
            if (ModelState.IsValid)
            {
                if (_matchService.CreateMatch(model))
                {
                    return RedirectToAction("Home", "Home");
                }

                return RedirectToAction("Error", "Home", new { error1 });
            }

            return RedirectToAction("Error", "Home", new { error1 });
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
            (bool passed1, string error1) = _validator.ValidateModel(model);
            if (ModelState.IsValid)
            {
                if (_matchService.EditMatch(model))
                {
                    return RedirectToAction("Home", "Home");

                }
                return RedirectToAction("Error", "Home", new { error1 });

            }
            return RedirectToAction("Error", "Home", new { error1 });
        }

        public IActionResult Remove(string id)
        {
            var match = _matchService.FindMatch(id);

            return View(match);
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
