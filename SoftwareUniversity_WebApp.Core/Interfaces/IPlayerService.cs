using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models;

namespace WebApp.Core.Interfaces
{
    public interface IPlayerService
    {
        (bool Passed, string Error) CreatePlayer(AddPlayerViewModel model);

        public IEnumerable<TeamViewModel> GetPlayers();
    }
}
