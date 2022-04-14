using WebApp.Core.Models;

namespace WebApp.Core.Interfaces
{
    public interface IPlayerService
    {
        public bool CreatePlayer(AddPlayerViewModel model);

        public IEnumerable<PlayerViewModel> GetPlayersByTeam(string teamId);
        public IEnumerable<PlayerViewModel> GetPlayers(string UserId);
        public IQueryable<PlayerViewModel> FindPlayer(string modelId);

        public bool EditPlayer(PlayerViewModel model);
        public bool RemovePlayer(string modelId);
    }
}
