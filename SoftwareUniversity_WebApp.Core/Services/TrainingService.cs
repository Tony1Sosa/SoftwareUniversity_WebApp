using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Language;
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
                    TeamId = model.TeamId,
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
    }
}
