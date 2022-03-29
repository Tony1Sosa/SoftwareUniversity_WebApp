using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Infrastructure.Data.Models;

namespace WebApp.Core.Models
{
    public class AddTeamViewModel
    {
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Name { get; set; }

        [Range(4, 80, ErrorMessage = "{0} must be in range from {1} and {2} years.")]
        public int AgeSection { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
