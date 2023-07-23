using GraphQLDemo.Domain.DTO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GraphQLDemo.Domain.Entities
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AccountId { get; set; }
        public Account Author { get; set; }

        public Post(PostCreateDTO postCreateDTO) 
        {
            Id = "";
            Title= postCreateDTO.Title;
            Description= postCreateDTO.Description;
            AccountId = postCreateDTO.AccountId;
        }
        public Post() 
        {

        }
    }
}