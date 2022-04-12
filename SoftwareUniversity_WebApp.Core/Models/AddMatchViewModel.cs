using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Core.Models
{
    public class AddMatchViewModel
    {
        public string Id { get; set; }
        public DateTime Time { get; set; }
        public DateTime Date { get; set; }
        public string Team1Id { get; set; }
        public string Team2Id { get; set; }
        public string UserId { get; set; }
    }
}
