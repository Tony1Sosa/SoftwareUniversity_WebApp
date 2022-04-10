using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models;
using WebApp.Infrastructure.Data.Models;

namespace WebApp.Core.Interfaces
{
    public interface IEventService
    {
        public bool CreateEvent(AddEventViewModel model);
        public EventViewModel FindEvent(string id);

        public bool EditEvent(EventViewModel model);
        bool RemoveEvent(string modelId);
    }
}
