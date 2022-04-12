using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Core.Models
{
    public class AddEventViewModel
    {
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Event {0} must be between {2} and {1}")]
        public string Name { get; set; }


        [StringLength(10, MinimumLength = 2, ErrorMessage = "Event {0} must be between {2} and {1}")]
        public string Type { get; set; }


        [StringLength(200, MinimumLength = 5, ErrorMessage = "Event {0} must be between {2} and {1}")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Team is required.")]
        public string TeamId { get; set; }

        [Required(ErrorMessage = "Training is required.")]
        public string TrainingId { get; set; }

    }
}
