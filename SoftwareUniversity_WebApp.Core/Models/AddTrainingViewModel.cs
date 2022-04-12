﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Core.Models
{
    public class AddTrainingViewModel
    {
        [Required(ErrorMessage = "Team is required")]
        public string TeamId { get; set; }

        [Required]
        //Its select input
        public string  Program { get; set; }

        [Required]
        //Its select input
        public string Description { get; set; }

        [Required]
        public string Type { get; set; }

        public string UserId { get; set; }
        
    }
}
