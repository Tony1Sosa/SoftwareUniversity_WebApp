using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models;

namespace WebApp.Core.Interfaces
{
    public interface ITrainingService
    {
        public IEnumerable<TrainingViewModel> GetTrainings();
        public bool CreateTrainig(AddTrainingViewModel model);
    }
}
