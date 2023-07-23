using GraphQLDemo.Domain.DTO;

namespace GraphQLDemo.Domain.Entities
{
    public class Account
    {
        public Guid? Id { get; set; }
        public string Login { get; set; }
        public Guid StatisticsId { get; set; }
        public Statistics? Statistics { get; set; }

        public Account(AccountCreateDTO DTO)
        {
            Login = DTO.Login;
            StatisticsId = DTO.StatisticsId;
        }

        public Account() 
        {

        }
    }
}