namespace GraphQLDemo.Domain.DTO
{
    public class PostCreateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AccountId { get; set; }
    }
}