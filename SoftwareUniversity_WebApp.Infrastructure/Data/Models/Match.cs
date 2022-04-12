using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Infrastructure.Data.Models
{
    public class Match
    {
        public Match()
        {
            
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public DateTime PlayingDate { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        
    }
}
