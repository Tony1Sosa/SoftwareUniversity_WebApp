using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Infrastructure.Data.Models;

namespace WebApp.Core.Models
{
    public class EventViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string TeamId { get; set; }
        public string TrainingId { get; set; }
        public Team Team { get; set; }
        public Training Training { get; set; }  
    }
}
