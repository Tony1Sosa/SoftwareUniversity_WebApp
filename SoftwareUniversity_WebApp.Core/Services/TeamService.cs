﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Interfaces;
using WebApp.Core.Models;
using WebApp.Infrastructure.Data.Models;

namespace WebApp.Core.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepository _repository;

        public TeamService(IRepository repository)
        {
            _repository = repository;
        }

        public (bool Passed, string Error) CreateTeam(AddTeamViewModel model)
        {
            bool passed = true;
            string error = string.Empty;

            var players = _repository.All<Team>();

            Team newTeam = new Team()
            {
                Name = model.Name,
                AgeSection = model.AgeSection,
                Players = model.Players
            };

            _repository.Add(newTeam);
            _repository.SaveChanges();

            return (passed, error);
        }

        public IEnumerable<TeamViewModel> GetTeams()
        {
            var teams = _repository.All<Team>()
                .Select(t => new TeamViewModel()
                {
                    Name = t.Name,
                    AgeSection = t.AgeSection
                }).ToList();

            return teams;
        }
    }
}