using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Interfaces;
using WebApp.Core.Models;
using WebApp.Infrastructure.Data.Models;

namespace WebApp.Core.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository _repository;

        public EventService(IRepository repository)
        {
            _repository = repository;
        }

        public bool CreateEvent(AddEventViewModel model)
        {
            try
            {
                var team = _repository.All<Team>().FirstOrDefault(t => t.Id.Equals(model.TeamId));
                var training = _repository.All<Training>().FirstOrDefault(t => t.Id.Equals(model.TrainingId));

                Event newEvent = new Event()
                {
                    Name = model.Name,
                    Type = model.Type,
                    Description = model.Description,
                    TeamId = model.TeamId,
                    Team = team,
                    TrainingId = model.TrainingId,
                    Training = training
                };

                _repository.Add(newEvent);
                _repository.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public EventViewModel FindEvent(string eventId)
        {
            var foundEvent = _repository.All<Event>().FirstOrDefault(e => e.Id.Equals(eventId));

            var team = _repository.All<Team>().FirstOrDefault(t => t.Id.Equals(foundEvent.TeamId));
            var training = _repository.All<Training>().FirstOrDefault(t => t.Id.Equals(foundEvent.TrainingId));

            if (foundEvent != null)
            {
                EventViewModel eventt = new EventViewModel()
                {
                    Description = foundEvent.Description,
                    Type = foundEvent.Type,
                    TeamId = foundEvent.TeamId,
                    TrainingId = foundEvent.TrainingId,
                    Name = foundEvent.Name,
                    Id = eventId,
                    Team = team,
                    Training = training
                };

                return eventt;
            }

            return default;
        }

        public bool EditEvent(EventViewModel model)
        {
            try
            {
                var eventt = _repository.All<Event>().FirstOrDefault(e => e.Id.Equals(model.Id));

                eventt.Name = model.Name;
                eventt.Type = model.Type;
                eventt.TeamId = model.TeamId;
                eventt.TrainingId = model.TrainingId;
                eventt.Description = model.Description;

                _repository.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool RemoveEvent(string modelId)
        {
            try
            {
                var eventt = _repository.All<Event>().FirstOrDefault(e => e.Id.Equals(modelId));
                _repository.Remove(eventt);
                _repository.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
    }
}
