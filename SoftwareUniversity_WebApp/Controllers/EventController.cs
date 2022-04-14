using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftwareUniversity_WebApp.Models;
using WebApp.Core.Interfaces;
using WebApp.Core.Models;

namespace SoftwareUniversity_WebApp.Controllers
{
    public class EventController : Controller
    {
        private readonly IRepository _repository;
        private readonly IEventService _eventService;
        private readonly ITeamService _tenantService;
        private readonly ITrainingService _trainingService;
        private readonly IValidationService _validator;
        private readonly UserManager<IdentityUser> _userManager;

        public EventController(IRepository repository, IEventService eventService, UserManager<IdentityUser> userManager, IPlayerService playerService, ITrainingService trainingService, ITeamService tenantService, IValidationService validator)
        {
            _repository = repository;
            _eventService = eventService;
            _userManager = userManager;
            _trainingService = trainingService;
            _tenantService = tenantService;
            _validator = validator;
        }

        public IActionResult Add()
        {
            var user = _userManager.GetUserAsync(User);
            var userId = user.Result.Id;
            var dbViewModels = _repository.GetEntitiesFromDb(userId);

            return View(dbViewModels);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel model)
        {
            (bool passed1, string error1) = _validator.ValidateModel(model);
            if (ModelState.IsValid)
            {
                if (_eventService.CreateEvent(model))
                {
                    return RedirectToAction("Home", "Home");
                }

                return RedirectToAction("Error", "Home", new { error1 });
            }

            return RedirectToAction("Error", "Home", new { error1 });
        }

        public IActionResult ViewInfo(string id)
        {
            var eventmodeel = _eventService.FindEvent(id);

            return View(eventmodeel);
        }

        public IActionResult Edit(string id)
        {
            var user = _userManager.GetUserAsync(User);
            var userId = user.Result.Id;

            var eventt = _eventService.FindEvent(id);
            ViewData["teams"] = _tenantService.GetTeams(userId);
            ViewData["trainings"] = _trainingService.GetTrainings();
            return View(eventt);
        }

        [HttpPost]
        public IActionResult Edit(EventViewModel model)
        {
            (bool passed1, string error1) = _validator.ValidateModel(model);
            if (ModelState.IsValid)
            {
                if (_eventService.EditEvent(model))
                {
                    return RedirectToAction("Home", "Home");

                }
                return RedirectToAction("Error", "Home", new { error1 });

            }
            return RedirectToAction("Error", "Home", new { error1 });
        }

        public IActionResult Remove(string id)
        {
            var eventt = _eventService.FindEvent(id);
            return View(eventt);
        }

        [HttpPost]
        public IActionResult Remove(EventViewModel model)
        {
            if (_eventService.RemoveEvent(model.Id))
            {
                return RedirectToAction("Home", "Home");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}
