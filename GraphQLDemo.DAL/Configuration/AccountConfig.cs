using GraphQLDemo.DAL.Configuration.DataType;
using GraphQLDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLDemo.DAL.Configuration
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public const string Table_name = "accounts";

        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(e => new { e.Id });
            builder.HasIndex(e => e.Login)
                .IsUnique();

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("pk_account_id");

            builder.Property(e => e.Login)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("login");

            builder.Property(e => e.StatisticsId)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("fk_statistics_id");
        }
    }
}
