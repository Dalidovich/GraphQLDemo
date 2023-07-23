using GraphQLDemo.DAL;
using GraphQLDemo.DAL.Repositories;
using GraphQLDemo.DAL.Repositories.Interfaces;
using GraphQLDemo.Domain.DTO.AppSettingsDTO;
using GraphQLDemo.GraphQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GraphQLDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IStatisticsRepository, StatisticsRepository>();

            builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDbSettings"));
            builder.Services.AddSingleton(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDBSettings>>().Value);

            builder.Services.AddDbContextFactory<AppDBContext>(opt => opt.UseNpgsql(
                builder.Configuration.GetConnectionString("NpgConnectionString")));

            builder.Services
                .AddGraphQLServer()
                .AddProjections()
                .AddFiltering()
                .AddSorting()
                .AddQueryType<Query>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.MapGraphQL("/graphQL");

            app.Run();
        }
    }
}