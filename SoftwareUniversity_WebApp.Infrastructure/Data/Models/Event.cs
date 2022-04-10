using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Infrastructure.Data.Models
{
    public class Event
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [MaxLength(10)]
        public string Type { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [ForeignKey(nameof(Team))]
        public string TeamId  { get; set; }
        public Team Team { get; set; }

        [ForeignKey(nameof(Training))]
        public string TrainingId { get; set; }
        public Training Training { get; set; }
        
    }
}
