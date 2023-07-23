using GraphQLDemo.Domain.Entities;

namespace GraphQLDemo.DAL.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        public Task<Account> AddAsync(Account entity);
        public bool Delete(Account entity);
        public IQueryable<Account> GetAsync();
        public Task<bool> SaveAsync();
    }
}
