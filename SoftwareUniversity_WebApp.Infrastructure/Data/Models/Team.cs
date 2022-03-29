using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Infrastructure.Data.Models
{
    public class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
        }
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(5)]
        public int AgeSection { get; set; }

        //[ForeignKey(nameof(TeamPlayer))]
        //public string TeamPlayerId { get; set; }
        //public TeamPlayer TeamPlayer { get; set; }


        [ForeignKey(nameof(Training))]
        public string TrainingId { get; set; }
        public Training Training { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
