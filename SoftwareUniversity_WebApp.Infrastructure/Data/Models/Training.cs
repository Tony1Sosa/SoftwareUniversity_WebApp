using System.ComponentModel.DataAnnotations;

namespace WebApp.Infrastructure.Data.Models
{
    public class Training
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        public string Type { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
