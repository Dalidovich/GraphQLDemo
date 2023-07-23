using GraphQLDemo.Domain.Entities;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace GraphQLDemo.DAL.Repositories.Interfaces
{
    public interface IPostRepository
    {
        public Task<Post> AddAsync(Post article);
        public Task<bool> DeleteAsync(Expression<Func<Post, bool>> expression);
        public IQueryable<Post> GetAsync();
    }
}
