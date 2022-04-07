using System.ComponentModel.DataAnnotations;

namespace WebApp.Core.Models
{
    public class AddPlayerViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Player {0} must be between {2} and {1}")]
        public string name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Player {0} must be between {2} and {1}")]
        public string lastName { get; set; }

        [Required]
        [Range(1,100, ErrorMessage = "player {0} must be between {1} and {2}")]
        public int number { get; set; }

        [Required]
        public string position { get; set; }

        [Required]
        public string foot { get; set; }

        [Required]
        public string birthdayDate { get; set; }

        [Required]
        public string TeamId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
