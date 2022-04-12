using System.ComponentModel.DataAnnotations;

namespace WebApp.Core.Models
{
    public class AddPlayerViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Players {0} must be between {2} and {1}.")]
        public string name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Players {0} must be between {2} and {1}.")]
        public string lastName { get; set; }

        [Required]
        [Range(1,100, ErrorMessage = "Players {0} must be between {1} and {2}.")]
        public int number { get; set; }

        [Required]
        //its select input
        public string position { get; set; }

        [Required]
        //its select input
        public string foot { get; set; }

        [Required]
        [Range(typeof(DateTime), "1/1/1942", "1/1/2018", ErrorMessage = "Players {0} have to be between {1} and {2}.")]
        public string birthdayDate { get; set; }

        [Required(ErrorMessage = "Team is required.")]
        public string TeamId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
