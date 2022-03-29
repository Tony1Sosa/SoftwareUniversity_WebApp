using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models;
using WebApp.Infrastructure.Data.Models;

namespace WebApp.Core.Interfaces
{
    public interface ITeamService
    {
        (bool Passed, string Error) CreateTeam(AddTeamViewModel model);

        public IEnumerable<TeamViewModel> GetTeams();
    }
}
