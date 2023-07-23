using GraphQLDemo.DAL.Repositories.Interfaces;
using GraphQLDemo.Domain.DTO.AppSettingsDTO;
using GraphQLDemo.Domain.Entities;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace GraphQLDemo.DAL.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Post> _articlesTable;

        public PostRepository(MongoDBSettings mongoDBSettings)
        {
            _client = new MongoClient(mongoDBSettings.Host);
            _database = _client.GetDatabase(mongoDBSettings.Database);
            _articlesTable = _database.GetCollection<Post>(mongoDBSettings.Collection);
        }

        public async Task<Post> AddAsync(Post article)
        {
            await _articlesTable.InsertOneAsync(article);

            return article;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Post, bool>> expression)
        {
            var deletedArticle = await _articlesTable.DeleteManyAsync(expression);

            return deletedArticle.IsAcknowledged;
        }

        public IQueryable<Post> GetAsync()
        {

            return _articlesTable.AsQueryable();
        }
    }
}
