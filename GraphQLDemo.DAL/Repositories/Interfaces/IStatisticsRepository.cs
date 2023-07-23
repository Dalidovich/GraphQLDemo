using GraphQLDemo.Domain.Entities;

namespace GraphQLDemo.DAL.Repositories.Interfaces
{
    public interface IStatisticsRepository
    {
        public Task<Statistics> AddAsync(Statistics entity);
        public bool Delete(Statistics entity);
        public IQueryable<Statistics> GetAsync();
        public Task<bool> SaveAsync();
    }
}
