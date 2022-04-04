using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Core.Models
{
    public class PlayerViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime BD { get; set; }
        public string Foot { get; set; }
        public int Number { get; set; }
        public string Possition { get; set; }
    }
}
