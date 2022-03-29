using System.ComponentModel.DataAnnotations;

namespace WebApp.Infrastructure.Data.Models
{
    public class Player
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Foot { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

    }
}
