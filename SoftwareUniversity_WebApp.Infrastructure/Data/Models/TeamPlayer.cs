using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Infrastructure.Data.Models
{
    public class TeamPlayer
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey(nameof(Team))]
        public string TeamId { get; set; }
        public Team Team { get; set; }


        [ForeignKey(nameof(Player))]
        public string PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
