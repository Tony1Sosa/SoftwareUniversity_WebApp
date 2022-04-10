using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Core.Models
{
    public class HomeViewModel
    {
        public IEnumerable<TeamViewModel> TeamViewModels { get; set; }
        public IEnumerable<PlayerViewModel> PlayerViewModels { get; set; }
        public IEnumerable<TrainingViewModel> TrainingViewModels { get; set; }
        public IEnumerable<EventViewModel> EventViewModels { get; set; }
        public string UserId { get; set; }
    }
}
