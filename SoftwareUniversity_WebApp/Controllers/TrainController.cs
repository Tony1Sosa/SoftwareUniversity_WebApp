﻿using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Interfaces;
using WebApp.Core.Models;

namespace SoftwareUniversity_WebApp.Controllers
{
    public class TrainController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly ITrainingService _trainingService;

        public TrainController(ITeamService teamService, ITrainingService trainingService)
        {
            _teamService = teamService;
            _trainingService = trainingService;
        }
        public IActionResult Add()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var teams = _teamService.GetTeams(userId);
            return View(teams);
        }

        [HttpPost]
        public IActionResult Add(AddTrainingViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_trainingService.CreateTrainig(model))
                {
                    return RedirectToAction("Home", "Home");

                }
                return RedirectToAction("Error", "Home");

            }
            return RedirectToAction("Error", "Home");
        }

        public IActionResult ViewInfo(string id)
        {
            var train = _trainingService.FindTraining(id);
            return View(train);
        }

        public IActionResult Edit(string id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var teams = _teamService.GetTeams(userId);
            ViewData["train"] = _trainingService.FindTraining(id);
            return View(teams);
        }

        [HttpPost]
        public IActionResult Edit(TrainingViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_trainingService.EditTraining(model))
                {
                    return RedirectToAction("Home", "Home");

                }
                return RedirectToAction("Error", "Home");

            }
            return RedirectToAction("Error", "Home");
        }

        public IActionResult Remove(string id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var training = _trainingService.FindTraining(id);

            return View(training);
        }

        [HttpPost]
        public IActionResult Remove(TrainingViewModel model)
        {
            if (_trainingService.RemoveTraining(model.Id))
            {
                return RedirectToAction("Home", "Home");
            }

            return RedirectToAction("Error", "Home");
        }
    }
}
