using Microsoft.EntityFrameworkCore;
using WebApp.Core.Interfaces;
using WebApp.Core.Models;
using WebApp.Infrastructure.Data;
using WebApp.Infrastructure.Data.Models;

namespace WebApp.Core.Services
{
    public class RepositoryService:IRepository
    {
        private readonly DbContext dbContext;

        public RepositoryService(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        public void Add<T>(T entity) where T : class
        {
            DbSet<T>().Add(entity);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public HomeViewModel GetEntitiesFromDb()
        {
            var players = All<Player>()
                .Select(p => new PlayerViewModel()
                {
                    Id = p.Id,
                    Name = string.Concat(p.FirstName, p.LastName),
                    BD = p.BirthDate,
                    Number = p.Number,
                    Possition = p.Position

                }).ToList();

            var teams = All<Team>()
                .Select(t => new TeamViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    AgeSection = t.AgeSection
                }).ToList();

            var trainigs = All<Training>()
                .Select(t => new TrainingViewModel()
                {
                    Id = t.Id,
                    Type = t.Type,
                    Description = t.Description

                }).ToList();

            var model = new HomeViewModel()
            {
                PlayerViewModels = players,
                TeamViewModels = teams,
                TrainingViewModels = trainigs
            };

            return model;
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }
    }
}
