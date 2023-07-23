using GraphQLDemo.DAL;
using GraphQLDemo.DAL.Repositories.Interfaces;
using GraphQLDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.GraphQL
{
    public class Query
    {
        private readonly IDbContextFactory<AppDBContext> _contextFactory;

        public Query(IDbContextFactory<AppDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        [UseProjection]
        [UseFiltering()]
        [UseSorting]
        public IQueryable<Account> GetAccounts()
        {
            var context = _contextFactory.CreateDbContext();
            return context.Accounts;
        }

        [UseProjection]
        [UseFiltering()]
        [UseSorting]
        public IQueryable<Post> GetPosts([Service] IPostRepository repo) => repo.GetAsync().Where(x => x.Title.StartsWith("p"));

        [UseProjection]
        [UseFiltering()]
        [UseSorting]
        public IQueryable<Statistics> GetStatistics()
        {
            var context = _contextFactory.CreateDbContext();
            return context.Statistics;
        }

        [UseProjection]
        [UseFiltering()]
        [UseSorting]
        public async Task<Post> GetFullPost([Service] IPostRepository repo, string id)
        {
            var context = _contextFactory.CreateDbContext();
            var post = repo.GetAsync().SingleOrDefault(x => x.Id == id);
            if (post != null)
            {
                var athor = await context.Accounts.Include(x => x.Statistics).SingleOrDefaultAsync(x => x.Id == post.AccountId);
                post.Author = athor;
                return post;
            }

            return null;
        }
    }
}