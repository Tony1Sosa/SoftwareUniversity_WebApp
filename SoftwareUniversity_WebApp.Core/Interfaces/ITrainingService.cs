using WebApp.Core.Models;
using WebApp.Infrastructure.Data.Models;

namespace WebApp.Core.Interfaces
{
    public interface ITrainingService
    {
        public IEnumerable<TrainingViewModel> GetTrainings();
        public bool CreateTrainig(AddTrainingViewModel model);
        public IQueryable<TrainingViewModel> FindTraining(string trainingId);

        public bool EditTraining(TrainingViewModel model);
        public bool RemoveTraining(string modelId);
    }
}
