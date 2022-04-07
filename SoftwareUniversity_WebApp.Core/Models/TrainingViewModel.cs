using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Core.Models
{
    public class TrainingViewModel
    {
        public string Id { get; set; }
        public string  Program { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string TeamId { get; set; }
    }
}
