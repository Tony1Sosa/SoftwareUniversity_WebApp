using WebApp.Infrastructure.Data.Models;

namespace WebApp.Core.Models
{
    public class MatchViewModel
    {
        public string Id { get; set; }

        public DateTime PlayingDate { get; set; }

        public DateTime Time { get; set; }

        public string Team1Id { get; set; }
        public Team? Team1 { get; set; }
        public string Team2Id { get; set; }
        public Team? Team2 { get; set; }
    }
}
