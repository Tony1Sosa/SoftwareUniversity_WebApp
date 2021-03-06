using WebApp.Core.Models;

namespace WebApp.Core.Interfaces
{
    public interface ITeamService
    {
        public (bool Passed, string Error) CreateTeam(AddTeamViewModel model);

        public IEnumerable<TeamViewModel> GetTeams(string userId);

        public IQueryable<TeamViewModel> FindTeam(string modelId);
        public IQueryable<TeamViewModel> FindTeamForPlayer(string playerId);

        public bool EditTeam(TeamViewModel model);

        public bool RemoveTeam(string teamId);
    }
}
