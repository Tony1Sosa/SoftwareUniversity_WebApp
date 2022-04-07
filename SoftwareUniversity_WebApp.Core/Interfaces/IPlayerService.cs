using WebApp.Core.Models;

namespace WebApp.Core.Interfaces
{
    public interface IPlayerService
    {
        (bool Passed, string Error) CreatePlayer(AddPlayerViewModel model);

        public IEnumerable<PlayerViewModel> GetPlayersByTeam(string teamId);

        public IQueryable<PlayerViewModel> FindPlayer(string modelId);

        public bool EditPlayer(PlayerViewModel model);
        public bool RemovePlayer(string modelId);
    }
}
