using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Interfaces;
using WebApp.Core.Models;
using WebApp.Infrastructure.Data.Models;

namespace WebApp.Core.Services
{
    public class PlayerService : IPlayerService
    {
        private IRepository repo;

        public PlayerService(IRepository repo)
        {
            this.repo = repo;
        }

        public (bool Passed, string Error) CreatePlayer(AddPlayerViewModel model)
        {
            bool passed = true;
            string error = string.Empty;



            Player newPlayer = new Player()
            {
                FirstName = model.name + "_",
                LastName = model.lastName,
                Number = model.number,
                Position = model.position,
                Foot = model.foot,
                TeamId = model.TeamId,
                BirthDate = DateTime.ParseExact(model.birthdayDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            };

            repo.Add(newPlayer);
            repo.SaveChanges();

            return (passed,error);
        }

        public IQueryable<PlayerViewModel> FindPlayer(string modelId)
        {
            var player = repo.All<Player>()
                .Where(p => p.Id == modelId)
                .Select(p => new PlayerViewModel()
                {
                    Id = p.Id,
                    Foot = p.Foot,
                    Name = string.Concat(p.FirstName, p.LastName),
                    BD = p.BirthDate,
                    Number = p.Number,
                    Possition = p.Position,
                    
                });

            return player;
        }

        public bool EditPlayer(PlayerViewModel model)
        {
            string[] name = model.Name.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string firstName = name[0];
            string secondName = name[1];

            var player = repo.All<Player>()
                .FirstOrDefault(p => p.Id.Equals(model.Id));

            player.FirstName = firstName;
            player.LastName = secondName;
            player.BirthDate = model.BD;
            player.Foot = model.Foot;
            player.Number = model.Number;
            player.Position = model.Possition;

            try
            {
                repo.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool RemovePlayer(string modelId)
        {
            var player = repo.All<Player>().Where(p => p.Id == modelId);

            Player foundPlayer = null;

            foreach (Player player1 in player)
            {
                foundPlayer = player1;
            }

            try
            {
                repo.Remove(foundPlayer);
                repo.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public IEnumerable<PlayerViewModel> GetPlayersByTeam(string teamId)
        {
            var players = repo.All<Player>()
                .Where(p=> p.TeamId == teamId)
                .Select(p => new PlayerViewModel()
                {
                    Id = p.Id, 
                    Name  = string.Concat(p.FirstName, p.LastName),
                    BD = p.BirthDate,
                    Number = p.Number,
                    Possition = p.Position

                }).ToList();

            return players;
        }
    }
}
