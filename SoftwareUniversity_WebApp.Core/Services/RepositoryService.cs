using Microsoft.EntityFrameworkCore;
using WebApp.Core.Interfaces;
using WebApp.Infrastructure.Data;

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
