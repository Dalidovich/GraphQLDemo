using GraphQLDemo.DAL.Repositories.Interfaces;
using GraphQLDemo.Domain.Entities;

namespace GraphQLDemo.DAL.Repositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly AppDBContext _db;

        public StatisticsRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<Statistics> AddAsync(Statistics entity)
        {
            var createdEntity = await _db.Statistics.AddAsync(entity);

            return createdEntity.Entity;
        }

        public bool Delete(Statistics entity)
        {
            _db.Statistics.Remove(entity);

            return true;
        }

        public IQueryable<Statistics> GetAsync()
        {

            return _db.Statistics.AsQueryable();
        }

        public async Task<bool> SaveAsync()
        {
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
