namespace GraphQLDemo.Domain.Entities
{
    public class Statistics
    {
        public Guid? Id { get; set; }
        public DateTime LastActive { get; set;}
        public double rating { get; set; }
        public int Age { get; set; }
    }
}