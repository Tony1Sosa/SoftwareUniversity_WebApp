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
                UserId = model.UserId
            };

            _repository.Add(newTeam);
            _repository.SaveChanges();

            return (passed, error);
        }

        public IEnumerable<TeamViewModel> GetTeams(string userId)
        {
            var teams = _repository.All<Team>()
                .Where(x=> x.UserId == userId)
                .Select(t => new TeamViewModel()
                {
                    Name = t.Name,
                    AgeSection = t.AgeSection,
                    Id = t.Id
                }).ToList();

            return teams;
        }

        public IQueryable<TeamViewModel> FindTeam(string modelId)
        {
            var team = _repository.All<Team>()
                .Where(t => t.Id == modelId)
                .Select(t => new TeamViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    AgeSection = t.AgeSection,
                });

            return team;
        }

        public bool EdditTeam(TeamViewModel model)
        {
            var team = _repository.All<Team>()
                .FirstOrDefault(t => t.Id.Equals(model.Id));

            team.Name = model.Name;
            team.AgeSection = model.AgeSection;

            try
            {
                _repository.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveTeam(string teamId)
        {
            var team = _repository.All<Team>().FirstOrDefault(t => t.Id == teamId);
            var players = _repository.All<Player>().Where(p => p.TeamId == teamId);

            try
            {
                foreach (Player player in players)
                {
                    _repository.Remove(player);
                }
                _repository.Remove(team);
                _repository.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
