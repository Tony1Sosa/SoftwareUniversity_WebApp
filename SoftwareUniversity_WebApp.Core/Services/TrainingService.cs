using WebApp.Core.Interfaces;
using WebApp.Core.Models;
using WebApp.Infrastructure.Data.Models;

namespace WebApp.Core.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly IRepository _repository;

        public TrainingService(IRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<TrainingViewModel> GetTrainings()
        {
            var training = _repository.All<Training>()
                .Select(t => new TrainingViewModel()
                {
                    Id= t.Id,
                    Type = t.Type,
                    Description = t.Description

                }).ToList();
            return training;
        }

        public bool CreateTrainig(AddTrainingViewModel model)
        {
            try
            {
                Training newTraining = new Training()
                {
                    Program = model.Program,
                    Description = model.Description,
                    Type = model.Type
                };

                _repository.Add(newTraining);
                _repository.SaveChanges();

                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public IQueryable<TrainingViewModel> FindTraining(string trainingId)
        {
            var traning = _repository.All<Training>()
                .Where(p => p.Id == trainingId)
                .Select(p => new TrainingViewModel()
                {
                    Id = p.Id,
                    Type = p.Type,
                    Description = p.Description,
                    Program = p.Program
                });

            return traning;
        }

        public bool EditTraining(TrainingViewModel model)
        {
            var training = _repository.All<Training>().FirstOrDefault(t=> t.Id.Equals(model.Id));
            var team = _repository.All<Team>().FirstOrDefault(t => t.Id.Equals(model.TeamId));

            training.Description = model.Description;
            training.Type = model.Type;
            training.Program = model.Program;

            try
            {
                _repository.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveTraining(string modelId)
        {
            var trainings = _repository.All<Training>().Where(t => t.Id == modelId);

            Training foundTrain = null;

            foreach (Training train in trainings)
            {
                foundTrain = train;
            }

            try
            {
                _repository.Remove(foundTrain);
                _repository.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
