using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Infrastructure.Data.Models
{
    public class Training
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        public string Type { get; set; }

        [Required]
        [MaxLength(15)]
        public string Program { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

    }
}
