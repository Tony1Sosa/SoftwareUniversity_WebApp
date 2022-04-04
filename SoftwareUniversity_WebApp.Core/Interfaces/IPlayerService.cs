using WebApp.Core.Models;

namespace WebApp.Core.Interfaces
{
    public interface IPlayerService
    {
        (bool Passed, string Error) CreatePlayer(AddPlayerViewModel model);

        public IEnumerable<PlayerViewModel> GetPlayers();

        public IQueryable<PlayerViewModel> FindPlayer(string modelId);
    }
}
