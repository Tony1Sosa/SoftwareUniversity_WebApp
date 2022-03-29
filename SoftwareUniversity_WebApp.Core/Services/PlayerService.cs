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

            var players = repo.All<Player>();

            Player newPlayer = new Player()
            {
                FirstName = model.name,
                LastName = model.lastName,
                Number = model.number,
                Position = model.position,
                Foot = model.foot,
                BirthDate = DateTime.ParseExact(model.birthdayDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            };

            repo.Add(newPlayer);
            repo.SaveChanges();

            return (passed,error);
        }

        public IEnumerable<PlayerViewModel> GetPlayers()
        {
            var players = repo.All<Player>()
                .Select(p => new PlayerViewModel()
                {
                  Name  = string.Concat(p.FirstName, p.LastName),
                  BD = p.BirthDate,
                  Number = p.Number,
                  Possition = p.Position

                }).ToList();

            return players;
        }
    }
}
