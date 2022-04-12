using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models;

namespace WebApp.Core.Interfaces
{
    public interface IMatchService
    {
        public bool CreateMatch(AddMatchViewModel model);
        public MatchViewModel FindMatch(string id);
        public bool EditMatch(AddMatchViewModel model);
        bool RemoveMatch(string modelId);
    }
}
