using WebApp.Core.Models;

namespace WebApp.Core.Interfaces
{
    public interface ITeamService
    {
        public (bool Passed, string Error) CreateTeam(AddTeamViewModel model);

        public IEnumerable<TeamViewModel> GetTeams(string userId);
    }
}
