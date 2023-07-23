using GraphQLDemo.DAL.Repositories.Interfaces;
using GraphQLDemo.Domain.Entities;

namespace GraphQLDemo.DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDBContext _db;

        public AccountRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<Account> AddAsync(Account entity)
        {
            var createdEntity = await _db.Accounts.AddAsync(entity);

            return createdEntity.Entity;
        }

        public bool Delete(Account entity)
        {
            _db.Accounts.Remove(entity);

            return true;
        }

        public IQueryable<Account> GetAsync()
        {

            return _db.Accounts.AsQueryable();
        }

        public async Task<bool> SaveAsync()
        {
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
