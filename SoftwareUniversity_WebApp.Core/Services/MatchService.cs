using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Language;
using WebApp.Core.Interfaces;
using WebApp.Core.Models;
using WebApp.Infrastructure.Data.Models;

namespace WebApp.Core.Services
{
    public class MatchService : IMatchService
    {
        private readonly IRepository _repository;

        public MatchService(IRepository repository)
        {
            _repository = repository;
        }

        public bool CreateMatch(AddMatchViewModel model)
        {
            try
            {
                Team team1 = _repository.All<Team>().FirstOrDefault(t => t.Id.Equals(model.Team1Id));
                Team team2 = _repository.All<Team>().FirstOrDefault(t => t.Id.Equals(model.Team2Id));

                if (team1.Id.Equals(team2.Id))
                {
                    return false;
                }

                Match newMatch = new Match()
                {
                    PlayingDate = model.Date,
                    Time = model.Time,
                    UserId = model.UserId
                };

                team1.MatchId = newMatch.Id;
                team2.MatchId = newMatch.Id;

                _repository.Add(newMatch);
                _repository.SaveChanges();

                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public MatchViewModel FindMatch(string id)
        {
            var match = _repository.All<Match>().FirstOrDefault(m => m.Id.Equals(id));
            var teams = _repository.All<Team>()
                .Where(t => t.MatchId == match.Id)
                .ToList();

            Team team1 = teams.First();
            Team team2 = teams.Last();

            MatchViewModel model = new MatchViewModel()
            {
                Id = match.Id,
                PlayingDate = match.PlayingDate,
                Team1Id = teams.First().Id,
                Team1 = team1,
                Team2Id = teams.Last().Id,
                Team2 = team2,
                Time = match.Time
            };

            return model;
        }

        public bool EditMatch(AddMatchViewModel model)
        {
            try
            {
                var team1 = _repository.All<Team>().FirstOrDefault(t => t.Id.Equals(model.Team1Id));
                var team2 = _repository.All<Team>().FirstOrDefault(t => t.Id.Equals(model.Team2Id));

                var match = _repository.All<Match>().FirstOrDefault(m => m.Id.Equals(model.Id));

                match.PlayingDate = model.Date;
                match.Time = model.Time;
                team1.MatchId = match.Id;
                team2.MatchId = match.Id;

                _repository.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveMatch(MatchViewModel model)
        {
            try
            {
                var match = _repository.All<Match>().FirstOrDefault(m => m.Id.Equals(model.Id));
                _repository.Remove(match);  
                _repository.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
    }
}
